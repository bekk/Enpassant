using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Enpassant
{
    public static class Frontpage
    {
        public static async Task WriteIndexHtml(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            var html = await File.ReadAllTextAsync("Static/index.html");
            await context.Response.WriteAsync(html, Encoding.UTF8);
        }
        
        public static async Task WriteSignalRJs(HttpContext context)
        {
            context.Response.ContentType = "application/javascript";
            var js = await File.ReadAllTextAsync("Static/signalr.min.js");
            await context.Response.WriteAsync(js, Encoding.UTF8);
        }
    }
}