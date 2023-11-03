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

        services.AddSingleton<IContactReportContext, ContactReportContext>();
        services.AddSingleton<IQueueServiceHelper, QueueServiceHelper>();

        services.AddScoped<IContactReportDetailRepository,ContactReportDetailRepository>();
        services.AddScoped<IContactReportRepository,ContactReportRepository>();

        services.AddScoped<IContactReportService,ContactReportService>();
        services.AddScoped<IContactReportDetailService,ContactReportDetailService>();
    }
}
