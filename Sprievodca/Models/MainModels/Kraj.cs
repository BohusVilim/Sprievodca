using Microsoft.AspNetCore.Mvc.Rendering;
using Sprievodca.Models.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprievodca.Models.MainModels
{
    public class Kraj : BaseIdentity
    {
        [DisplayName("Názov")]
        public string Nazov { get; set; } = null!;


        [DisplayName("Oblasť")]
        public IList<Oblast>? Oblast { get; set; }
    }

}
