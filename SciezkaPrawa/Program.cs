using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using SciezkaPrawa.API.Middlewares;
using SciezkaPrawa.Application.AiClient;
using SciezkaPrawa.Application.Extensions;
using SciezkaPrawa.Application.Files;
using SciezkaPrawa.Application.Pdf;
using SciezkaPrawa.Infrastructure;
using SciezkaPrawa.Infrastructure.Extensions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// File Storage
var fileStorageOptions = new FileStorageOptions
{
    RootPath = configuration["FileStorage:RootPath"] ?? "wwwroot/acts"
};
builder.Services.AddSingleton(fileStorageOptions);
builder.Services.AddScoped<IFileStorageService, FileStorageService>();

// Gemini
var geminiOptions = new GeminiOptions
{
    ApiKey = configuration["Gemini:ApiKey"]!,
    Model = configuration["Gemini:Model"] ?? "gemini-1.5-flash-latest"
};
builder.Services.AddSingleton(geminiOptions);
builder.Services.AddHttpClient<IAiClient, GeminiClient>();

builder.Services.AddScoped<IPdfTextExtractor, PdfPigTextExtractor>();
builder.Services.AddScoped<IActExplanationService, ActExplanationService>();

// Identity + Cookie Auth
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".4night.auth";
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; 

    options.Events.OnRedirectToLogin = ctx =>
    {
        ctx.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = ctx =>
    {
        ctx.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

// CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000", "https://localhost:3000",
            "http://localhost:5173", "http://localhost:8080", "http://localhost:8081",
            "http://localhost:5009")
            .AllowCredentials();
    });
});

builder.Services.AddControllers();
builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.Configure<ForwardedHeadersOptions>(opts =>
{
    opts.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    opts.KnownNetworks.Clear();
    opts.KnownProxies.Clear();
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("AllowLocalhost");

//app.UseHttpsRedirection();

app.UseForwardedHeaders();

app.UseRouting();


//app.UseCors("DevCors");

app.UseAuthentication();   
app.UseAuthorization();

app.MapControllers();

app.Run();
