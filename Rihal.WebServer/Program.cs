
using Microsoft.EntityFrameworkCore;
using Rihal.DataAccess.DbContext;
using Rihal.WebServer.ExceptionsHandlor;
using Rihal.WebServer.Registrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.RihalServicesRegistration();
builder.Services.RihalRepositoriesRegistration();

builder.Services.AddDbContext<RihalDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("RihalDB")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    RihalDatabaseInitializor.InitializeDatabase(scope);
}

// Configure the HTTP request pipeline.

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
