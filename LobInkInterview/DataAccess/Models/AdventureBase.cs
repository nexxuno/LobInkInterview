namespace LobInkInterview.DataAccess.Models
{
    public abstract class AdventureBaseDAL<T>
    {
        public Guid Id { get; set; }
        public string? Signature { get; set; }
        public string? Title { get; set; }
        public string? FirstQuestion { get; set; }
        public IList<T>? Choices { get; set; }
    }
}
