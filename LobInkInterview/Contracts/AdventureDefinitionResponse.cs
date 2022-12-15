using System.ComponentModel.DataAnnotations;

namespace LobInkInterview.Contracts
{
    public class AdventureDefinitionResponse:AdventureDefinitionRequest
    {
        public Guid Id { get; set; }

        public string Signature { get; set; } = string.Empty;
    }
}
