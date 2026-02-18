using System.ComponentModel;
using System.Diagnostics;
using Spectre.Console;
using Spectre.Console.Cli;

namespace MjcCli.Commands
{
    public class DotnetWebApiCommand : Command<DotnetWebApiCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            [CommandArgument(0, "<PROJECT_NAME>")]
            [Description("The name of the project to generate")]
            public string ProjectName { get; set; } = string.Empty;
        }

        public override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
        {
            AnsiConsole.MarkupLine("[blue]MJC CLI:[/] Generating Clean Architecture .Net Web API...");

            string templateShortName = "mjc-dotnet-web-api";

            var process = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"new {templateShortName} -n {settings.ProjectName}",
                UseShellExecute = false,
                CreateNoWindow = false
            };

            try
            {
                using var proc = Process.Start(process);
                proc?.WaitForExit();

                if (proc?.ExitCode == 0)
                {
                    AnsiConsole.MarkupLine($"[bold green]Success![/] [white]{settings.ProjectName}[/] created.");
                }
                else
                {
                    AnsiConsole.MarkupLine("[bold red]Error:[/] The template engine failed to generate the project. Make sure the template is installed.");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
                return 1;
            }

            return 0;
        }
    }
}
