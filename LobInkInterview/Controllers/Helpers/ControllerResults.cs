using Microsoft.AspNetCore.Http.HttpResults;

namespace LobInkInterview.Controllers.Helpers
{
    public static class ControllerResults
    {
        public static BadRequest<string> InvalidSignature 
            => TypedResults.BadRequest("Signature error, please use the signature and data of the definition and only select choices.");
    }
}
