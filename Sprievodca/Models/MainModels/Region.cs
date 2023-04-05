using Microsoft.AspNetCore.Mvc.Rendering;
using Sprievodca.Models.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprievodca.Models.MainModels
{
    public class Region : BaseIdentity
    {
        [DisplayName("Názov")]
        public string Name { get; set; } = null!;


        [DisplayName("Oblasť")]
        public IList<Area>? Areas { get; set; }
    }

}
