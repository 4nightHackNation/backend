using Microsoft.AspNetCore.Identity;
using SciezkaPrawa.API.Middlewares;
using SciezkaPrawa.Application.AiClient;
using SciezkaPrawa.Application.Extensions;
using SciezkaPrawa.Application.Files;
using SciezkaPrawa.Application.Pdf;
using SciezkaPrawa.Infrastructure;
using SciezkaPrawa.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.GetConnectionString("ApplicationDb");


var configuration = builder.Configuration;

var fileStorageOptions = new FileStorageOptions
{
    RootPath = configuration["FileStorage:RootPath"] ?? "wwwroot/acts"
};
builder.Services.AddSingleton(fileStorageOptions);

builder.Services.AddScoped<IFileStorageService, FileStorageService>();

var geminiOptions = new GeminiOptions
{
    ApiKey = configuration["Gemini:ApiKey"]!,
    Model = configuration["Gemini:Model"] ?? "gemini-1.5-flash-latest"
};
builder.Services.AddSingleton(geminiOptions);

builder.Services.AddHttpClient<IAiClient, GeminiClient>();

builder.Services.AddScoped<IPdfTextExtractor, PdfPigTextExtractor>();

builder.Services.AddScoped<IActExplanationService, ActExplanationService>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddControllers();
builder.Services.AddInfraStructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("https://localhost:3000", "http://localhost:3000")
            .AllowCredentials();
    });
});

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
