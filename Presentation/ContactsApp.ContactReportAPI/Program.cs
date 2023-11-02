using ContactsApp.ContactReportAPI;
using ContactsApp.ContactReportAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure(builder.Configuration);
var app = builder.Build();

#region database oluþturma
using var scope = app.Services.CreateScope();

var hasMigration = scope.ServiceProvider.GetRequiredService<ContactReportContext>().Database.GetPendingMigrations().Any();
if (hasMigration == true)
    scope.ServiceProvider.GetRequiredService<ContactReportContext>().Database.Migrate();
#endregion

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
