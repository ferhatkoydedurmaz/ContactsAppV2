using ContactsApp.ContactAPI;
using ContactsApp.ContactAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

#region database oluþturma
using var scope = app.Services.CreateScope();

var hasMigration = scope.ServiceProvider.GetRequiredService<ContactContext>().Database.GetPendingMigrations().Any();
if (hasMigration == true)
    scope.ServiceProvider.GetRequiredService<ContactContext>().Database.Migrate();
#endregion

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
