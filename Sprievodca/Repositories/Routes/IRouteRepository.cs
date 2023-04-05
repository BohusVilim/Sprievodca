namespace Sprievodca.Repositories.Routes
{
    public interface IRouteRepository : IDisposable
    {
        public IEnumerable<Models.MainModels.Route> GetAll();
    }
}