using System;

using Microsoft.Extensions.Logging;


namespace R5T.Larissa.Default
{
    public class SvnversionOperator : ISvnversionOperator
    {
        private ILogger Logger { get; }


        public SvnversionOperator(ILogger<SvnversionOperator> logger)
        {
            this.Logger = logger;
        }
    }
}
