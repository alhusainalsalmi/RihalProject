using Microsoft.Extensions.DependencyInjection;
using Rihal.DataAccess.SeedingData;


namespace Rihal.DataAccess.DbContext
{
    public class RihalDatabaseInitializor
    {
        public static void InitializeDatabase(IServiceScope scope)
        {
            var dataContext = scope.ServiceProvider.GetRequiredService<RihalDbContext>();
            dataContext.Database.EnsureCreated();
            RihalDbSeeder.SeedRihalDb(dataContext);
        }
    }
}
