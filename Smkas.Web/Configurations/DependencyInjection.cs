using Smkas.Core.Settings;
using Smkas.Data;

namespace Smkas.Mvc.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(appSettings);
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();

            services.AddScoped<ApplicationDbContext>();
        }
    }
}