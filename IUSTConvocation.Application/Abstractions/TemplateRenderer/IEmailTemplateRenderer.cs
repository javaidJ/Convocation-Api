using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUSTConvocation.Application.Abstractions.TemplateRenderer
{
    public interface IEmailTemplateRenderer
    {
        Task<string> RenderTemplateAsync(string templateName, object model);
    }
}
