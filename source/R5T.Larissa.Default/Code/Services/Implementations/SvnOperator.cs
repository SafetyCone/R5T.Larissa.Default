using System;

using Microsoft.Extensions.Logging;

using R5T.Caledonia;
using R5T.Heraklion;
using R5T.Heraklion.Default;
using R5T.Heraklion.Extensions;
using R5T.Lombardy;

using R5T.Larissa.Configuration;
using R5T.Larissa.Commands;


namespace R5T.Larissa.Default
{
    public class SvnOperator : ISvnOperator
    {
        private ICommandLineInvocationOperator CommandLineInvocationOperator { get; }
        private ISvnExecutableFilePathProvider SvnExecutableFilePathProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }
        private ILogger Logger { get; }


        public SvnOperator(
            ICommandLineInvocationOperator commandLineInvocationOperator,
            ISvnExecutableFilePathProvider svnExecutableFilePathProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator,
            ILogger<SvnOperator> logger)
        {
            this.CommandLineInvocationOperator = commandLineInvocationOperator;
            this.SvnExecutableFilePathProvider = svnExecutableFilePathProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
            this.Logger = logger;
        }

        private void Execute(ICommandBuilderContext command, bool suppressConsoleOutput = false)
        {
            var gitExecutableFilePath = this.SvnExecutableFilePathProvider.GetSvnExecutableFilePath();

            this.CommandLineInvocationOperator.Execute(gitExecutableFilePath, command, suppressConsoleOutput);
        }

        public OutputAndError ExecuteAndGetOutput(ICommandBuilderContext command, bool suppressConsoleOutput = false)
        {
            var gitExecutableFilePath = this.SvnExecutableFilePathProvider.GetSvnExecutableFilePath();

            var outputAndError = this.CommandLineInvocationOperator.ExecuteAndGetOutput(gitExecutableFilePath, command, suppressConsoleOutput);
            return outputAndError;
        }

        public Version GetVersion()
        {
            var command = SvnCommandLine.Start()
                .Version(true)
                ;

            var outputAndError = this.ExecuteAndGetOutput(command, true);

            var versionString = outputAndError.Output;

            var version = Version.Parse(versionString);
            return version;
        }

        public void Checkout(string repositoryUrl, string localDirectoryPath, string username, string password)
        {
            var adjustedLocalDirectoryPath = this.StringlyTypedPathOperator.EnsureNotDirectoryIndicatedPath(localDirectoryPath);

            var command = SvnCommandLine.Start()
                .Checkout(repositoryUrl, adjustedLocalDirectoryPath)
                .Username(username)
                .Password(password)
                ;

            this.Execute(command);
        }

        public void Add(string path)
        {
            var command = SvnCommandLine.Start()
                .Add(path)
                ;

            this.Execute(command);
        }

        public void Commit(string path, string message, bool directoryOnly = false)
        {
            var command = SvnCommandLine.Start()
                .Commit(path, message)
                .Condition(directoryOnly, context =>
                {
                    context.SetDepthEmpty();
                })
                ;

            this.Execute(command);
        }

        public void Update(string path)
        {
            var command = SvnCommandLine.Start()
                .Update(path)
                ;

            this.Execute(command);
        }

        public string GetRemoteRepositoryUrl(string path)
        {
            var command = SvnCommandLine.Start()
                .Info(path)
                .SetShowItemUrl();

            var output = this.ExecuteAndGetOutput(command);

            var remoteRepositoryUrl = output.Output.Trim();
            return remoteRepositoryUrl;
        }
    }
}
