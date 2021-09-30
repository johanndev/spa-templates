using Boxed.DotnetNewTest;
using System.Threading.Tasks;
using Xunit;

namespace Vite_CSharp.Tests
{
    public class SpaTemplatesTestFixture : IAsyncLifetime
    {
        private const string TemplateProject = "JohannDev.DotNet.Web.Spa.ProjectTemplates.csproj";

        public async Task InitializeAsync()
        {
            await DotnetNew.InstallAsync<InstallTests>(TemplateProject);
        }

        public Task DisposeAsync()
        {
            // Nothing to dispose
            return Task.CompletedTask;
        }
    }
}
