using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Models.MainModels;
using Sprievodca.Data;

namespace Sprievodca.Data
{
    public class SprievodcaDbContext : DbContext
    {
        public SprievodcaDbContext (DbContextOptions<SprievodcaDbContext> options)
            : base(options)
        {
        }
        public DbSet<Region> Regions { get; set; } = default!;

        public DbSet<Area> Areas { get; set; }

        public DbSet<SubArea> SubAreas { get; set; }

        public DbSet<Models.MainModels.Route> Routes { get; set; }

        public DbSet<Sector> Sectors { get; set; }
    }
}
