using System;

using Microsoft.Extensions.Logging;

using R5T.Larissa.Configuration;


namespace R5T.Larissa.Default
{
    public class SvnversionOperator : ISvnversionOperator
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
