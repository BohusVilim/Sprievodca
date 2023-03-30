using Sprievodca.Models.Shared;
using System.ComponentModel;

namespace Sprievodca.Models.MainModels
{
    public class PodOblast : BaseIdentity
    {
        [DisplayName("Názov")]
        public string Name { get; set; } = null!;

        public IList<Sektor>? Sektor { get; set; }

        [DisplayName("Oblasť")]
        public Oblast Oblast { get; set; } = null!;

        [DisplayName("Oblasť")]
        public long OblastId { get; set; }
    }
}
