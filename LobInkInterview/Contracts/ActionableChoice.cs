using System.ComponentModel.DataAnnotations;

namespace LobInkInterview.Contracts
{
    public class ActionableChoice : ChoiceBase<ActionableChoice>, IValidatableObject
    {
        public bool Selected { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //given more time we could do better and check that there is only one path taking to a leaf and everything else has selected = false
            if (Choices?.Count(choice => choice.Selected == true) > 1)
            {
                yield return new ValidationResult(
                    $"Only one choice can be made for each question",
                    new[] { nameof(Choices) });
            }
        }
    }
}
