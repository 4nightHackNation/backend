using System.Text.Json.Serialization;

namespace SciezkaPrawa.Domain.Entities
{
    public class ActVersion
    {
        public Guid Id { get; set; }
        public Guid ActId { get; set; }
        [JsonIgnore]    
        public Act Act { get; set; } = default!; 
        public int VersionNumber { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = default!;
        public string FilePath { get; set; } = default!;
    }
}