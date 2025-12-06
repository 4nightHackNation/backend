namespace SciezkaPrawa.Domain.Entities
{
    public class ActReadingVote
    {
        public Guid Id { get; set; }
        public Guid ActId { get; set; }
        public Act Act { get; set; } = default!;
        public string ReadingName { get; set; } = default!;
        public int For { get; set; }
        public int Against { get; set; }
        public int Abstain { get; set; }
        public DateTime? Date { get; set; }
    }
}