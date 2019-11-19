using System.Text.Json;

namespace Enpassant.Ingestion
{
    public static class IngestionHubState
    {
        public static string LastPayload { get; set; } = JsonSerializer.Serialize(new {pgn = ""});
    }
}