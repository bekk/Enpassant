using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Enpassant.TestClient
{
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
                .WithUrl("https://localhost:5001/chess")
                .WithAutomaticReconnect()
                .Build();

            connection.On<string>("MsgFromHub", msg =>
            {
                Console.WriteLine($"Received message from hub: {msg}");
            });

            try
            {
                Console.WriteLine("Starting connection...");
                await connection.StartAsync();
                Console.WriteLine("Connection started successfully");
                
                // SendAsync just pushes the message, does not wait for an "ACK" from the server
                await connection.SendAsync("Update", "Did you get this update?");
                // InvokeAsync waits for an "ACK" from the server, and can also return a value
                var response = await connection.InvokeAsync<string>("UpdateWithEcho", "Hello");
                Console.WriteLine($"Got a response: {response}");
                
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