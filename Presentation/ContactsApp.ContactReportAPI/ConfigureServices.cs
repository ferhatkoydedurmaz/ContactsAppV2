using ContactsApp.ContactReportAPI.Data;
using ContactsApp.QueueService.QueueService.ServiceBus;
using ContactsApp.QueueService.QueueService;
using Microsoft.EntityFrameworkCore;
using ContactsApp.ContactReportAPI.Repositories;
using ContactsApp.ContactReportAPI.Services;

namespace ContactsApp.ContactReportAPI;

public static class ConfigureServices
{
    public static void Configure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContactReportContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("defaultConnStr"));
        });

        services.AddSingleton<IQueueServiceHelper, QueueServiceHelper>();

        services.AddScoped<ContactReportDetailRepository>();
        services.AddScoped<ContactReportRepository>();

        services.AddScoped<ContactReportService>();
        services.AddScoped<ContactReportDetailService>();
    }
}
