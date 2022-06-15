
using MudBlazor.Services;
using Rihal.WebServer.ExceptionsHandlor;
using Rihal.WebServer.Services;
using Rihal.WebServer.Services.Interfaces;

namespace Rihal.WebServer.Registrations
{
    public static class ServicesRegistration
    {
        public static void RihalServicesRegistration(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddMudServices();
            services.AddTransient<ExceptionHandlerMiddleware>();
        }
    }
}
