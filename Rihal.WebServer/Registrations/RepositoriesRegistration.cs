using Rihal.DataAccess.Repositories;
using Rihal.Domain.Repositories;

namespace Rihal.WebServer.Registrations
{
    public static class RepositoriesRegistration
    {
        public static void RihalRepositoriesRegistration(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
