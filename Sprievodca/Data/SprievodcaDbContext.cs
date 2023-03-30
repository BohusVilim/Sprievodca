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
        public DbSet<Kraj> Kraj { get; set; } = default!;

        public DbSet<Oblast> Oblast { get; set; }

        public DbSet<PodOblast> PodOblast { get; set; }

        public DbSet<Cesta> Cesta { get; set; }

        public DbSet<Sektor> Sektor { get; set; }
    }
}
