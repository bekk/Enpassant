using System.Threading.Tasks;

namespace Enpassant
{
    public interface ITypedHubClient
    {
        Task MsgFromHub(string message);
    }
}