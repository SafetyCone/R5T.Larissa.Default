using System;

using R5T.Caledonia;
using R5T.Heraklion;
using R5T.Heraklion.Default;

using R5T.Larissa.Configuration;
using R5T.Larissa.Commands;


namespace R5T.Larissa.Default
{
    public class SvnOperator : ISvnOperator
    {
        private ICommandLineInvocationOperator CommandLineInvocationOperator { get; }
        private ISvnExecutableFilePathProvider SvnExecutableFilePathProvider { get; }


        public SvnOperator(ICommandLineInvocationOperator commandLineInvocationOperator, ISvnExecutableFilePathProvider svnExecutableFilePathProvider)
        {
            this.CommandLineInvocationOperator = commandLineInvocationOperator;
            this.SvnExecutableFilePathProvider = svnExecutableFilePathProvider;
        }

        private void Execute(ICommandBuilderContext command)
        {
            var gitExecutableFilePath = this.SvnExecutableFilePathProvider.GetSvnExecutableFilePath();

            this.CommandLineInvocationOperator.Execute(gitExecutableFilePath, command);
        }
    }
}
