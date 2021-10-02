# ASP.NET Core + Vite = 💖

This repository contains a dotnet project template for creating a ASP.NET Core web applications that integrates with the [Vite](https://vitejs.dev) frontend tooling.

Starting with .NET 6, the integration of ASP.NET Core with SPA-Frameworks was overhauled - more information can be found in this issue: https://github.com/dotnet/aspnetcore/issues/27887

The new, official SPA-templates are now available here: https://github.com/dotnet/spa-templates

## Installation

You can install the latest version via nuget:
```bash
dotnet new --install JohannDev.DotNet.Web.Spa.ProjectTemplates
```

## Install from Source

You can also clone this repository and build the project from source. After cloning, pack the project into a `nupkg` and install it via the dotnet CLI:

```bash
git clone https://github.com/johanndev/spa-templates
cd spa-templates/src/
dotnet restore
dotnet build
dotnet pack -c=Release // Prints the path to the nupkg

dotnet install -i <path/to/the/nupkg>
```

## Usage
This example creates a new project that integrates [Vue.js](https://vuejs.org) (via Vite) and also enables TypeScript support:
```bash
dotnet new vite -o my-vite-project --frontendFramework vue --useTypeScript
# alternative short form:
dotnet new vite -o my-vite-project -f vue -t
```
Afterwards, the project can be compiled and run; node dependencies are automatically restored on first run:
```bash
cd my-vite-project
dotnet build
dotnet run
```
