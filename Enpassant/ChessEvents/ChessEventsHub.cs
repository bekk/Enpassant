using System.Threading.Tasks;
using Enpassant.Ingestion;
using Microsoft.AspNetCore.SignalR;

namespace Enpassant.ChessEvents
{
    // The ChessEventsHub updates all clients (listeners) about new board states
    public class ChessEventsHub : Hub<IChessEventsClient>
    {
        public string LastUpdate()
        {
            return IngestionHubState.LastPayload;
        }
    }
}