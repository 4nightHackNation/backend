using Microsoft.Extensions.DependencyInjection;
using SciezkaPrawa.Application.Acts;
using SciezkaPrawa.Application.Tags;
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
            // rejestrujesz serwisy z Application, np. IActService
            return services;
        }
    }
}
