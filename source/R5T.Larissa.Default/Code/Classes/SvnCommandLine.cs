using System;

using R5T.Heraklion;

using R5T.Larissa.Commands;
using R5T.Volos;


namespace R5T.Larissa.Default
{
    public static class SvnCommandLine
    {
        public static ICommandBuilderContext<SvnContext> Start()
        {
            var commandBuilderContext = CommandLine.Start<SvnContext>();
            return commandBuilderContext;
        }
    }
}
