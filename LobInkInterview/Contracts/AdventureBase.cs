using System.ComponentModel.DataAnnotations;

namespace LobInkInterview.Contracts
{
    public abstract class AdventureBase<T>
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string FirstQuestion { get; set; } = string.Empty;

        [Required]
        public IList<T> Choices { get; set; } = new List<T>();
    }
}
