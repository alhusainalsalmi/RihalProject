using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Rihal.WebServer.ExceptionsHandlor
{
    public class CustomErrorBoundry : ErrorBoundary  
    {
        [Inject]
        private IWebHostEnvironment environment { get; set; }
        protected override Task OnErrorAsync(Exception exception)
        {
            if (environment.IsDevelopment())
            {
                return base.OnErrorAsync(exception);
            }

            return Task.CompletedTask;
        }
    }
}
