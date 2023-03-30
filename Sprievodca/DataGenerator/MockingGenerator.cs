using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;
using System.Diagnostics;

namespace Sprievodca.DataGenerator
{
    public class MockingGenerator
    {
        private readonly SprievodcaDbContext _context;
        private readonly bool _existDb;
        public MockingGenerator(SprievodcaDbContext context)
        {
            _context = context;
            _existDb = _context.Database.EnsureCreated();
        }

        public List<Kraj> CreateKraje()
        {
            var kraje = new List<Kraj>();

            if (_existDb == true || _context.Kraj.Count() < 1)
            {
                kraje.Add(new Kraj { Nazov = "Bratislavský kraj" });
                kraje.Add(new Kraj { Nazov = "Trnavský kraj" });
                kraje.Add(new Kraj { Nazov = "Trenčiansky kraj" });
                kraje.Add(new Kraj { Nazov = "Nitriansky kraj" });
                kraje.Add(new Kraj { Nazov = "Žilinský kraj" });
                kraje.Add(new Kraj { Nazov = "Banskobystrický kraj" });
                kraje.Add(new Kraj { Nazov = "Prešovský kraj" });
                kraje.Add(new Kraj { Nazov = "Košický kraj" }); 
            }
            return kraje;
        }
    }
}
