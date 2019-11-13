using System.Threading.Tasks;

namespace Enpassant.ChessEvents
{
    public interface IChessEventsClient
    {
        Task BoardUpdate(string updatePayload);
    }
}