using IUSTConvocation.Application.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IUSTConvocation.Api.Middlewares
{
    internal class ExtendedProblemDetails : ProblemDetails
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; }
        public string Instance { get; set; }
        public List<APIError> Errors { get; set; }
    }
}