using System.ComponentModel.DataAnnotations;

namespace LobInkInterview.Contracts
{
    public abstract class ChoiceBase<T>
    {
        [Required]
        [MaxLength(50)]
        public string Answer { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string? NextInteraction { get; set; }
        
        public IList<T>? Choices { get; set; }
    }
}
