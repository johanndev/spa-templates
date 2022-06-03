using Boxed.DotnetNewTest;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vite_CSharp.Tests;

public class InstallTests : IClassFixture<SpaTemplatesTestFixture>
{
    [Fact]
    public async Task Template_can_be_restored_and_built()
    {
        await using var tempDirectory = TempDirectory.NewTempDirectory();
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
    [InlineData("frontendFramework=lit")]
    [InlineData("frontendFramework=lit", "useTypeScript=true")]
    [InlineData("frontendFramework=svelte")]
    [InlineData("frontendFramework=svelte", "useTypeScript=true")]
    [InlineData("frontendFramework=solid")]
    [InlineData("frontendFramework=solid", "useTypeScript=true")]
    public async Task CLI_parameters_are_supported(params string[] arguments)
    {
        await using var tempDirectory = TempDirectory.NewTempDirectory();

        var argumentDictionary = arguments
            .Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
            .ToDictionary(x => x.First(), x => x.Last());

        var project = await tempDirectory.DotnetNewAsync(
            templateName: "vite",
            arguments: argumentDictionary
        );

        //Ensure that a ClientApp folder was created
        var clientAppFolder = Path.Combine(tempDirectory.DirectoryPath, "ClientApp");
        Assert.True(Directory.Exists(clientAppFolder));

        await project.DotnetRestoreAsync();
        await project.DotnetBuildAsync();
    }
}