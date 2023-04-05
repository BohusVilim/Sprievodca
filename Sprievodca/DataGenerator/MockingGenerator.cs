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

        public List<Region> CreateRegions()
        {
            var regions = new List<Region>();

            if (_existDb == true || _context.Regions.Count() < 1)
            {
                regions.Add(new Region { Name = "Bratislavský kraj" });
                regions.Add(new Region { Name = "Trnavský kraj" });
                regions.Add(new Region { Name = "Trenčiansky kraj" });
                regions.Add(new Region { Name = "Nitriansky kraj" });
                regions.Add(new Region { Name = "Žilinský kraj" });
                regions.Add(new Region { Name = "Banskobystrický kraj" });
                regions.Add(new Region { Name = "Prešovský kraj" });
                regions.Add(new Region { Name = "Košický kraj" }); 
            }
            return regions;
        }
    }
}
