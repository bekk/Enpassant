using System;
using System.Threading.Tasks;
using Enpassant.ChessEvents;
using Microsoft.AspNetCore.SignalR;

namespace Enpassant.Ingestion
{
    // The ingestion hub receives board states from one or many boards
    public class IngestionHub : Hub
    {
        private IHubContext<ChessEventsHub, IChessEventsClient> _chessEventsContext;

        public IngestionHub(IHubContext<ChessEventsHub, IChessEventsClient> chessEventsContext)
        {
            _chessEventsContext = chessEventsContext;
        }
        
        public void BoardUpdate(string updatePayload)
        {
            _chessEventsContext.Clients.All.ChessUpdate(updatePayload);
        }
    }
}