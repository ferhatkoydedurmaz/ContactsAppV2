using AzureFunc.ContactReport;
using AzureFunc.ContactReport.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

[assembly: FunctionsStartup(typeof(Startup))]

namespace AzureFunc.ContactReport
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IDbConnection>(opt => new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=ContactDB;User Id=postgres;Password=123123;"));

            builder.Services.AddHttpClient("");

            builder.Services.AddScoped<GenereteReportResponse>();
        }
    }
}