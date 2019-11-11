using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Enpassant
{
    public class ChessHub : Hub<ITypedHubClient>
    {
        // This will receive updates from the client
        public void Update(string foo)
        {
            Console.WriteLine($"Received SignalR update! foo = {foo}");
        }
        
        public string UpdateWithEcho(string foo)
        {
            Console.WriteLine($"Received SignalR update! foo = {foo}. Sending echo.");
            return foo;
        }
        
        // This is mostly for testing. Allows sending a message to a client.
        public async Task SendMessage(string message)
        {
            await Clients.All.MsgFromHub(message);
        }
    }
}