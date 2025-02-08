using IUSTConvocation.Application.Abstractions.TemplateRenderer;
using RazorLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Infrastructure.TemplateRenderer
{
    internal sealed class EmailTemplateRenderer : IEmailTemplateRenderer
    {
        public async Task<string> RenderTemplateAsync(string templateName, object model)
        {
            string templateResult = string.Empty;

            try
            {
                var assemblyLocation = Assembly.GetExecutingAssembly().Location;
                string assemblyDirectory = Path.GetDirectoryName(assemblyLocation);

                var templateFolder = Path.Combine(assemblyDirectory, "EmailTemplates");

                var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(templateFolder)
                .UseMemoryCachingProvider()
                .EnableDebugMode()
                .Build();
                templateResult = await engine.CompileRenderAsync(templateName, model);
            }
            catch (Exception)
            {
                throw;
            }

            return templateResult;
        }
    }
}
