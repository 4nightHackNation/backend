namespace SciezkaPrawa.Domain.Entities
{
    public class ActVersion
    {
        public Guid Id { get; set; }
        public Guid ActId { get; set; }
        public Act Act { get; set; } = default!;
        public int VersionNumber { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = default!;
        public string FilePath { get; set; } = default!;
    }
}