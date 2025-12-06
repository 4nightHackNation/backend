using Microsoft.Extensions.DependencyInjection;
using SciezkaPrawa.Application.Acts;
using SciezkaPrawa.Application.ReadingVotes;
using SciezkaPrawa.Application.Stages;
using SciezkaPrawa.Application.Tags;
using SciezkaPrawa.Application.Versions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciezkaPrawa.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {   
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IActService, ActService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IActStagesService, ActStagesService>();
            services.AddScoped<IActReadingVotesService, ActReadingVotesService>();
            services.AddScoped<IActVersionsService, ActVersionsService>();
            // rejestrujesz serwisy z Application, np. IActService
            return services;
        }
    }
}
