using Sprievodca.Data;
using Sprievodca.Models.Shared;
using System.ComponentModel;

namespace Sprievodca.Models.MainModels
{
    public class Oblast : BaseIdentity
    {
        [DisplayName("Názov")]
        public string Name { get; set; } = null!;

        [DisplayName("Podoblasť")]
        public IList<PodOblast>? PodOblast { get; set; }

        [DisplayName("Má podoblasť?")]
        public bool ExistPodOblast { get; set; }

        public IList<Sektor>? Sektor { get; set; }

        public Kraj Kraj { get; set; } = null!;

        [DisplayName("Kraj")]
        public long KrajId { get; set; }
    }
}
