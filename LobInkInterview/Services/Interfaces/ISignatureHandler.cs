using LobInkInterview.Contracts;

namespace LobInkInterview.Services.Interfaces
{
    public interface ISignatureHandler
    {
        string CreateSignature(object signMe);
        bool CheckSignature(object signMe, string check);
    }
}
