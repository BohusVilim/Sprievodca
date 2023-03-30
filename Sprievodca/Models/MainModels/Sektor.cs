using Sprievodca.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Sprievodca.Models.MainModels
{
    public class Sektor : BaseIdentity
    {
        public string? Name { get; set; }        
        public string? ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; } = null!;

        public IList<Cesta>? Cesta { get; set; }

        [DisplayName("Podblasť")]
        public PodOblast? PodOblast { get; set; }

        [DisplayName("Podblasť")]
        public long? PodOblastId { get; set; }

        [DisplayName("Oblasť")]
        public Oblast? Oblast { get; set; }

        [DisplayName("Oblasť")]
        public long? OblastId { get; set; }
    }
}
