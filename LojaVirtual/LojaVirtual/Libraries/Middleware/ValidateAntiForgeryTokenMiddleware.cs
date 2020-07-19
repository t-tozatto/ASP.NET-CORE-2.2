using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Middleware
{
    public class ValidateAntiForgeryTokenMiddleware
    {
        private RequestDelegate _next;
        private IAntiforgery _antiforgery;

        public ValidateAntiForgeryTokenMiddleware(RequestDelegate next, IAntiforgery antiforgery)
        {
            _next = next;
            _antiforgery = antiforgery;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (HttpMethods.IsPost(httpContext.Request.Method) && !(httpContext.Request.Form.Files.Count == 1 && httpContext.Request.Headers["x-requested-with"].Equals("XMLHttpRequest")))
                await _antiforgery.ValidateRequestAsync(httpContext);

            await _next(httpContext);
        }
    }
}
