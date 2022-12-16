using System.ComponentModel.DataAnnotations;

namespace LobInkInterview.Contracts
{
    public class AdventureRequest : AdventureBase<ActionableChoice>, IValidatableObject
    {
        [Required]
        public string Signature { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //given more time we could do better and check that there is only one path taking to a leaf and everything else has selected = false
            //another check that we could implement is something on the total size of the tree
            if (Choices.Count(choice => choice.Selected == true) > 1)
            {
                yield return new ValidationResult(
                    $"Only one choice can be made for each question",
                    new[] { nameof(Choices) });
            }
        }
    }
}
