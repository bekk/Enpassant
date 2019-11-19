using Microsoft.AspNetCore.SignalR;

namespace Enpassant.ChessEvents
{
    // The ChessEventsHub updates all clients (listeners) about new board states
    public class ChessEventsHub : Hub<IChessEventsClient>
    {
        public void PushBoardState(string updatePayload)
        {
            ChessEventsState.LastPayload = updatePayload;
            Clients.All.NewBoardState(updatePayload);
        }
        
        public string LastUpdate()
        {
            return ChessEventsState.LastPayload;
        }
    }
}