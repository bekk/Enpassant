using System.Threading.Tasks;

namespace Enpassant.ChessEvents
{
    public interface IChessEventsClient
    {
        Task NewBoardState(string updatePayload);
    }
}