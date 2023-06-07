using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Shyjus.BrowserDetection;
using System.Threading.Tasks;

namespace EFDemo.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, IBrowserDetector detector)
        {
            var browser = detector.Browser;
            if(browser.Name == BrowserNames.Edge)
            {
                httpContext.Response.Redirect("https://www.mozilla.org/pl/firefox/new");
            }
            if (browser.Name == BrowserNames.EdgeChromium)
            {
                httpContext.Response.Redirect("https://www.mozilla.org/pl/firefox/new");
            }
            if (browser.Name == BrowserNames.InternetExplorer)
            {
                httpContext.Response.Redirect("https://www.mozilla.org/pl/firefox/new");
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
