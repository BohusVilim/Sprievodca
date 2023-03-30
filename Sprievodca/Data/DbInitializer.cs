using Sprievodca.DataGenerator;

namespace Sprievodca.Data
{
    public static class DbInitializer
    {
        public static void Init(IServiceProvider services, SprievodcaDbContext context)
        {
            MockingGenerator mockingGenerator = new MockingGenerator(context);
            using var transaction = context.Database.BeginTransaction();

            var kraje = mockingGenerator.CreateKraje();
            context.Kraj.AddRange(kraje);
            context.SaveChanges();

            transaction.Commit();
        }
    }
}
