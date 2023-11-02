using ContactsApp.ContactAPI.Data;
using ContactsApp.ContactAPI.Repositories;
using ContactsApp.ContactAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.ContactAPI;

public static class ConfigureServices
{
    public static void Configure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContactContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("defaultConnStr"));
        });

        services.AddScoped<ContactRepository>();
        services.AddScoped<ContactFeatureRepository>();

        services.AddScoped<ContactService>();
        services.AddScoped<ContactFeatureService>();
    }

}
