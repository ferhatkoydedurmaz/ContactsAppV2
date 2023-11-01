using ContactsApp.Core.Utitilies.Contants;

namespace ContactsApp.WebUI;

public static class ConfigureServices
{
    public static void Configure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient(ApiHttpClientNameConstant.ContactsAPI, opt =>
        {
            opt.BaseAddress = new Uri(ApiEndpointConstant.ContactsAPI);
        });

        services.AddHttpClient(ApiHttpClientNameConstant.ContactsReportAPI, opt =>
        {
            opt.BaseAddress = new Uri(ApiEndpointConstant.ContactsReportAPI);
        });

    }
}
