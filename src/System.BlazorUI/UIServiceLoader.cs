using Microsoft.Extensions.DependencyInjection;

namespace System.BlazorUI
{
    public static class UIServiceLoader
    {
        /// <summary>
        /// load dashboard
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDashboard(this IServiceCollection services)
        {
            services.AddRazorPages(options => options.RootDirectory = "/Views");
            services.AddServerSideBlazor(options => options.DetailedErrors = true);
            // return services
            return services;
        }



    }
}
