using System.Text.Json.Serialization;

namespace SciezkaPrawa.Domain.Entities
{
    public class ActTag
    {
        public Guid ActId { get; set; }
        [JsonIgnore]
        public Act Act { get; set; } = default!;

        public int TagId { get; set; }
        public Tag Tag { get; set; } = default!;
    }
}