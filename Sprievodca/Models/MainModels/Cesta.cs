using Sprievodca.Models.Shared;

namespace Sprievodca.Models.MainModels
{
    public class Cesta : BaseIdentity
    {
        public string? Name { get; set; }
        public string Grade { get; set; } = null!;
        public int Lenght { get; set; }
        public string? Style { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; } 
        public int Year { get; set; }

        public Sektor Sektor { get; set; } = null!;
        public long SektorId { get; set; }
       
    }
}
