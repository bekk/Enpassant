using System.Text.Json;

namespace Enpassant.ChessEvents
{
    public static class ChessEventsState
    {
        public static string LastPayload { get; set; } = JsonSerializer.Serialize(new {pgn = ""});
    }
}