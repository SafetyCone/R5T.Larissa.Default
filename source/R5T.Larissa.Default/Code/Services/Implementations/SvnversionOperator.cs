using System;

using Microsoft.Extensions.Logging;

using R5T.Larissa.Configuration;using R5T.T0064;


namespace R5T.Larissa.Default
{[ServiceImplementationMarker]
    public class SvnversionOperator : ISvnversionOperator,IServiceImplementation
    {
        private ISvnversionExecutableFilePathProvider SvnversionExecutableFilePathProvider { get; }
        private ILogger Logger { get; }


        public SvnversionOperator(
            ISvnversionExecutableFilePathProvider svnversionExecutableFilePathProvider,
            ILogger<SvnversionOperator> logger)
        {
            this.Logger = logger;
        }
    }
}
