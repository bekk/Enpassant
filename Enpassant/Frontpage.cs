using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Enpassant.ChessEvents;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Enpassant
{
    public static class Frontpage
    {
        private const string KasparovsImmortalStart =
            "1. e4 d6 2. d4 Nf6 3. Nc3 g6 4. Be3 Bg7 5. Qd2 c6 6. f3 b5 7. Nge2 Nbd7 8. Bh6 Bxh6 9. Qxh6 Bb7 10. a3 e5 11. O-O-O Qe7 12. Kb1 a6 13. Nc1 O-O-O 14. Nb3 exd4 15. Rxd4 c5 16. Rd1 Nb6 17. g3 Kb8 18. Na5 Ba8 19. Bh3 d5";
        
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
        
        public static async Task SendTestEvent(HttpContext context)
        {
            Console.WriteLine("Sending message to SignalR clients...");
            
            var payloadObject = new
            {
                pgn = KasparovsImmortalStart
            };
            var payload = JsonSerializer.Serialize(payloadObject);
            
            var hubContext = context.RequestServices.GetRequiredService<IHubContext<ChessEventsHub, IChessEventsClient>>();
            await hubContext.Clients.All.BoardUpdate(payload);
        }
        
        public static async Task WriteFavicon(HttpContext context)
        {
            context.Response.ContentType = "image/x-icon";
            var favicon = await File.ReadAllBytesAsync("Static/favicon.ico");
            await context.Response.BodyWriter.WriteAsync(favicon);
        }
    }
}