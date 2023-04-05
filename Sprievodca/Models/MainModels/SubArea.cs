using Sprievodca.Models.Shared;
using System.ComponentModel;

namespace Sprievodca.Models.MainModels
{
    public class SubArea : BaseIdentity
    {
        [DisplayName("Názov")]
        public string Name { get; set; } = null!;

        [DisplayName("Sektor")]
        public IList<Sector>? Sectors { get; set; }

        [DisplayName("Oblasť")]
        public Area Area { get; set; } = null!;

        [DisplayName("Oblasť")]
        public long AreaId { get; set; }
    }
}
