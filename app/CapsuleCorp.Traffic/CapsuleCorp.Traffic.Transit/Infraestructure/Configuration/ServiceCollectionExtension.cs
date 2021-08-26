using CapsuleCorp.Traffic.Transit.Application;
using CapsuleCorp.Traffic.Transit.Infraestructure.Persistence;
using CapsuleCorp.Traffic.Transit.Infraestructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CapsuleCorp.Traffic.Transit.Infraestructure.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static void AddCapsuleCorpDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CapsuleCorpContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:CapsuleCorpContext"]));
            services.AddTransient<IMultaApplication, MultaApplication>();
            services.AddTransient<IMultaRepository, MultaRepository>();
            
            
        }
    }
}
