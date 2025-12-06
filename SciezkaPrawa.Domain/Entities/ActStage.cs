namespace SciezkaPrawa.Domain.Entities
{
    public class ActStage
    {
        public Guid Id { get; set; }
        public Guid ActId { get; set; }
        public Act Act { get; set; } = default!;
        public string Name { get; set; } = default!;
        public DateTime Date { get; set; }
        public string Status { get; set; } = default!;
        public int Order { get; set; }

    }
}