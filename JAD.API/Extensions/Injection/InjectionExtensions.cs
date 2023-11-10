
using JADSVC.Intefaces;
using JAD.Core;
using JADSVC.Intefaces.SP;

namespace JAD.API.Extensions.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IServiceLevelRepository, ServiceLevelRepository>();
            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IStateChangeRepository, StateChangeRepository>();
            services.AddScoped<IUserFeatureRepository, UserFeatureRepository>();
            services.AddScoped<ISPUserRelatedRepository, SPUserRelatedRepository>();
            services.AddScoped<IspgetLevelsandFeaturesRepository, spgetLevelsandFeaturesRepository>();
            services.AddScoped<ISPGetFeatureByIdUserRepository, SPGetFeatureByIdUserRepository>();
            services.AddScoped<IspGetServiceOrderByIdUserRepository, spGetServiceOrderByIdUserRepository>();
            services.AddScoped<IServiceOrderFeatureRepository, ServiceOrderFeatureRepository>();
            return services;
        }
    }
}
