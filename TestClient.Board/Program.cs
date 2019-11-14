using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace TestClient.Board
{
    // Use this to test that the ingestion hub receives messages
    class Program
    {
        private const string HubUrl = "http://localhost:5000/ingestion";
        // private const string HubUrl = "https://enpassanthub.azurewebsites.net/ingestion";
        
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

            try
            {
                Console.WriteLine("Starting connection...");
                await connection.StartAsync();
                Console.WriteLine("Connection started successfully");
                
                // SendAsync just pushes the message, does not wait for an confirmation/ACK from the server
                // If you want an ACK or a response value, use InvokeAsync instead
                await connection.SendAsync("BoardUpdate", "Did you get this update?");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
            }
            
            Console.WriteLine("Closing test client");
        }
    }
}