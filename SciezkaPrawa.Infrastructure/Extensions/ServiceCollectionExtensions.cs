using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SciezkaPrawa.Domain.Repositories;
using SciezkaPrawa.Infrastructure.Repositories;

namespace SciezkaPrawa.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IActRepository, ActRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IStageRepository, StageRepository>();
            services.AddScoped<IActReadingVoteRepository, ActReadingVoteRepository>();
            services.AddScoped<IActVersionRepository, ActVersionRepository>();
        }
    }
}
