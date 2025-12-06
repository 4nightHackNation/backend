namespace SciezkaPrawa.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<ActTag> ActTags { get; set; } = new List<ActTag>();
    }
}