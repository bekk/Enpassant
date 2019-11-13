using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace TestClient.Board
{
    // Use this to test that the ingestion hub receives messages
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        
        private static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Started test client...");
            
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/ingestion")
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