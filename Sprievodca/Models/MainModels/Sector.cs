using Sprievodca.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Sprievodca.Models.MainModels
{
    public class Sector : BaseIdentity
    {
        [DisplayName("Názov")]
        public string? Name { get; set; }        
        public string? ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; } = null!;

        [DisplayName("Cesta")]
        public IList<Route>? Routes { get; set; }

        [DisplayName("Podblasť")]
        public SubArea? SubArea { get; set; }

        [DisplayName("Podblasť")]
        public long? SubAreaId { get; set; }

        [DisplayName("Oblasť")]
        public Area? Area { get; set; }

        [DisplayName("Oblasť")]
        public long? AreaId { get; set; }
    }
}
