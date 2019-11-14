using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace TestClient.Listener
{
    public class Program
    {
        private const string HubUrl = "http://localhost:5000/chessEvents";
        // private const string HubUrl = "https://enpassanthub.azurewebsites.net/chessEvents";
        
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        
        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Started test client...");
            
            var connection = new HubConnectionBuilder()
                .WithUrl(HubUrl)
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("BoardUpdate", msg =>
            {
                Console.WriteLine($"Received message from hub: {msg}");
            });

            try
            {
                Console.WriteLine("Starting connection...");
                await connection.StartAsync();
                Console.WriteLine("Connection started successfully");
                
                Console.WriteLine("Starting passive loop. Type \"exit\" to quit");
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input?.Trim() == "exit")
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
            }
            
            Console.WriteLine("Closing test client");
        }
    }
}