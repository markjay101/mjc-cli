using MjcCli.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(config =>
{
    config.SetApplicationName("mjc");

    config.AddCommand<DotnetWebApiCommand>("dotnet-web-api")
          .WithDescription("Generates a .NET Web API with Clean Architecture (Domain, Application, Infrastructure)");
});

return app.Run(args);