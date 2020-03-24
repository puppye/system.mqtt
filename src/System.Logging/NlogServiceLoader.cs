using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;

namespace System.Logging
{
    public static class NLogServiceLoader
    {
        public static IServiceCollection AddNLogFactory(this IServiceCollection services)
        {
            //NLogLoggerFactory factory = new NLogLoggerFactory();
            NLog.LogManager.LoadConfiguration("nlog.config");
            //services.AddSingleton(factory);
            services.AddSingleton<ILoggerFactory, NLogLoggerFactory>();
            // return services
            return services;
        }
    }
}
