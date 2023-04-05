using JsonApiDotNetCore.Services;
using Microsoft.EntityFrameworkCore;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;

namespace Sprievodca.Repositories.Routes
{
    public class RouteRepository : IRouteRepository, IDisposable
    {
        private bool disposed = false;
        private readonly SprievodcaDbContext _context;
        public RouteRepository(SprievodcaDbContext context) {
            _context = context;
        }

        public IEnumerable<Models.MainModels.Route> GetAll()
        {
            return _context.Routes.Include(a => a.Sector);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
