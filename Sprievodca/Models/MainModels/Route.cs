using Sprievodca.Models.Shared;
using System.ComponentModel;

namespace Sprievodca.Models.MainModels
{
    public class Route : BaseIdentity
    {
        [DisplayName("Číslo")]
        public int Number { get; set; }

        [DisplayName("Názov")]
        public string? Name { get; set; }

        [DisplayName("Obtiažnosť")]
        public string Grade { get; set; } = null!;

        [DisplayName("Dĺžka")]
        public int Lenght { get; set; }

        [DisplayName("Štýl")]
        public string? Style { get; set; }

        [DisplayName("Popis")]
        public string? Description { get; set; }

        [DisplayName("Autor")]
        public string? Author { get; set; }

        [DisplayName("Rok")]
        public int Year { get; set; }


        [DisplayName("Sektor")]
        public Sector Sector { get; set; } = null!;

        [DisplayName("Sektor")]
        public long SectorId { get; set; }
       
    }
}
