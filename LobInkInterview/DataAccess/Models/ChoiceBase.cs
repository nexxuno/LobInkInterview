namespace LobInkInterview.DataAccess.Models
{
    public abstract class ChoiceBaseDAL<T>
    {
        public string? Answer { get; set; }
        public string? NextInteraction { get; set; }
        public IList<T>? Choices { get; set; }
    }
}
