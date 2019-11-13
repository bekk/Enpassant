using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Enpassant.ChessEvents
{
    // The ChessEventsHub updates all clients (listeners) about new board states
    public class ChessEventsHub : Hub<IChessEventsClient>
    {
    }
}