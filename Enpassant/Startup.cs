using System;
using System.Threading.Tasks;
using Enpassant.ChessEvents;
using Enpassant.Ingestion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Enpassant
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            
            services.Configure<IISServerOptions>(options => 
            {
                options.AutomaticAuthentication = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", Frontpage.WriteIndexHtml);
                endpoints.MapGet("/signalr.min.js", Frontpage.WriteSignalRJs);
                endpoints.MapGet("/favicon.ico", Frontpage.WriteFavicon);
                
                endpoints.MapGet("/sendTestEvent", Frontpage.SendTestEvent);
                endpoints.MapHub<IngestionHub>("/ingestion");
                endpoints.MapHub<ChessEventsHub>("/chessEvents");
            });
        }
    }
}