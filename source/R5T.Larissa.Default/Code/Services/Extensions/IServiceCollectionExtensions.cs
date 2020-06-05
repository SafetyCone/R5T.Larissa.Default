using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Caledonia;
using R5T.Dacia;
using R5T.Larissa.Configuration;
using R5T.Lombardy;


namespace R5T.Larissa.Default
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="SvnOperator"/> implementation of <see cref="ISvnOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSvnOperator(this IServiceCollection services,
            IServiceAction<ICommandLineInvocationOperator> commandLineInvocationOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<ISvnExecutableFilePathProvider> svnExecutableFilePathProviderAction,
            IServiceAction<ILogger> loggerAction)
        {
            services
                .AddSingleton<ISvnOperator, SvnOperator>()
                .Run(commandLineInvocationOperatorAction)
                .Run(stringlyTypedPathOperatorAction)
                .Run(svnExecutableFilePathProviderAction)
                .Run(loggerAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SvnOperator"/> implementation of <see cref="ISvnOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISvnOperator> AddSvnOperatorAction(this IServiceCollection services,
            IServiceAction<ICommandLineInvocationOperator> commandLineInvocationOperatorAction,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<ISvnExecutableFilePathProvider> svnExecutableFilePathProviderAction,
            IServiceAction<ILogger> loggerAction)
        {
            var serviceAction = ServiceAction<ISvnOperator>.New(() => services.AddSvnOperator(
                commandLineInvocationOperatorAction,
                stringlyTypedPathOperatorAction,
                svnExecutableFilePathProviderAction,
                loggerAction));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="SvnversionOperator"/> implementation of <see cref="ISvnversionOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSvnversionOperator(this IServiceCollection services,
            IServiceAction<ISvnversionExecutableFilePathProvider> svnversionExecutableFilePathProviderAction,
            IServiceAction<ILogger> loggerAction)
        {
            services
                .AddSingleton<ISvnversionOperator, SvnversionOperator>()
                .Run(svnversionExecutableFilePathProviderAction)
                .Run(loggerAction)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SvnversionOperator"/> implementation of <see cref="ISvnversionOperator"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ISvnversionOperator> AddSvnversionOperatorAction(this IServiceCollection services,
            IServiceAction<ISvnversionExecutableFilePathProvider> svnversionExecutableFilePathProviderAction,
            IServiceAction<ILogger> loggerAction)
        {
            var serviceAction = ServiceAction<ISvnversionOperator>.New(() => services.AddSvnversionOperator(
                svnversionExecutableFilePathProviderAction,
                loggerAction));

            return serviceAction;
        }
    }
}
