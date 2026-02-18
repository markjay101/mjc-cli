# MJC CLI

The command tool designed to scaffold high-performance, enterprise-ready .NET 10 Web APIs. It follows strict **Clean Architecture** principles to ensure your projects are scalable, maintainable, and decoupled.



## 🛠 Features

- **Clean Architecture Scaffolding**: Generates a pre-linked 4-project solution.
- **Automated Refactoring**: Automatically renames namespaces, folder structures, and project references based on your project name.
- **Signature Styling**: Beautiful CLI output powered by Spectre.Console.

---

## 🚀 Installation

To use the MJC Suite on your device, you need to install both the templates and the global CLI tool.

### 1. Install the Global Tool
Run this from the root of the repository to register the Clean Architecture boilerplate:
```bash
dotnet new install src/Templates/DotnetWebApi
```

### 2. Register the Templates
Pack the source code and install the mjc command to your system:
```bash
# Create the package
dotnet pack src/MjcCli/MjcCli.csproj -c Release -o ./nupkg

# Install globally
dotnet tool install -g Mjc.CLI --add-source ./nupkg
```

## 💻 Usage
Once installed, you can generate a new signature project from anywhere in your terminal:
```bash
mjc dotnet-web-api <YourProjectName>
```

## Generated Project Structure
The CLI generates a folder named **YourProjectName** containing:
```bash
.Domain 
.Application
.Infrastructure
.WebApi
```

## 📝 Standards
- **Framework**: .NET 10.0
- **Language**: C# 14
- **CLI Library**: Spectre.Cli