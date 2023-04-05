using JsonApiDotNetCore.Services;
using Sprievodca.Data;
using Sprievodca.Models.MainModels;

namespace Sprievodca.Repositories.Roads
{

    public interface IRoadRepository : IDisposable
    {
        public IEnumerable<Cesta> GetAll();
    }


    public class RoadRepository : IRoadRepository, IDisposable
    {
        private bool disposed = false;
        private readonly SprievodcaDbContext _context;
        public RoadRepository(SprievodcaDbContext context) {
            _context = context;
        }

        public IEnumerable<Cesta> GetAll()
        {
            return _context.Cesta;
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
