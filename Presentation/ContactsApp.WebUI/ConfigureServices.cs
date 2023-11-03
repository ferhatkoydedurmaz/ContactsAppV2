using ContactsApp.Core.Utitilies.Contants;
using ContactsApp.WebUI.Services;

namespace ContactsApp.WebUI;

public static class ConfigureServices
{
    public static void Configure(this IServiceCollection services)
    {
        services.AddHttpClient(ApiHttpClientNameConstant.ContactsAPI, opt =>
        {
            opt.BaseAddress = new Uri(ApiEndpointConstant.ContactsAPI);
        });

        services.AddHttpClient(ApiHttpClientNameConstant.ContactsReportAPI, opt =>
        {
            opt.BaseAddress = new Uri(ApiEndpointConstant.ContactsReportAPI);
        });

        services.AddScoped<BaseService>();
        services.AddScoped<IContactService,ContactService>();
        services.AddScoped<IContactFeatureService,ContactFeatureService>();
        services.AddScoped<IContactReportService,ContactReportService>();

    }
}
