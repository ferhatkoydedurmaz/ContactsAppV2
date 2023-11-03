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

        services.AddScoped<IContactContext, ContactContext>();

        services.AddScoped<IContactRepository, ContactRepository>();
        services.AddScoped<IContactFeatureRepository, ContactFeatureRepository>();

        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IContactFeatureService, ContactFeatureService>();
    }

}
