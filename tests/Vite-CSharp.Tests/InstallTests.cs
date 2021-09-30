using Boxed.DotnetNewTest;
using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Vite_CSharp.Tests;

public class InstallTests : IClassFixture<SpaTemplatesTestFixture>
{
    [Fact]
    public async Task Template_can_be_restored_and_built()
    {
        await using var tempDirectory = TempDirectory.NewShortTempDirectory();
        var project = await tempDirectory.DotnetNewAsync("vite");
        await project.DotnetRestoreAsync();
        await project.DotnetBuildAsync();
    }

    [Theory]
    [InlineData("frontendFramework=vanilla")]
    [InlineData("frontendFramework=vanilla", "useTypeScript=true")]
    [InlineData("frontendFramework=vue")]
    [InlineData("frontendFramework=vue", "useTypeScript=true")]
    [InlineData("frontendFramework=react")]
    [InlineData("frontendFramework=react", "useTypeScript=true")]
    [InlineData("frontendFramework=preact")]
    [InlineData("frontendFramework=preact", "useTypeScript=true")]
    [InlineData("frontendFramework=lit-element")]
    [InlineData("frontendFramework=lit-element", "useTypeScript=true")]
    [InlineData("frontendFramework=svelte")]
    [InlineData("frontendFramework=svelte", "useTypeScript=true")]
    public async Task CLI_parameters_are_supported(params string[] arguments)
    {
        await using var tempDirectory = TempDirectory.NewShortTempDirectory();

        var argumentDictionary = arguments
            .Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(x => x.First(), x => x.Last());

        var project = await tempDirectory.DotnetNewAsync(
            templateName: "vite",
            arguments: argumentDictionary
        );
        await project.DotnetRestoreAsync();
        await project.DotnetBuildAsync();
    }
}