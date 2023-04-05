using Sprievodca.Data;
using Sprievodca.Models.Shared;
using System.ComponentModel;

namespace Sprievodca.Models.MainModels
{
    public class Area : BaseIdentity
    {
        [DisplayName("Názov")]
        public string Name { get; set; } = null!;

        [DisplayName("Podoblasť")]
        public IList<SubArea>? SubArea { get; set; }

        [DisplayName("Má podoblasť?")]
        public bool ExistSubArea { get; set; }

        [DisplayName("Sektor")]
        public IList<Sector>? Sector { get; set; }

        [DisplayName("Kraj")]
        public Region Region { get; set; } = null!;

        [DisplayName("Kraj")]
        public long RegionId { get; set; }
    }
}
