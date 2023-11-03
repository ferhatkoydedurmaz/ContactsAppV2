using AzureFunc.ContactReport.Entities.Concrete;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureFunc.ContactReport.Services;
public class GenereteReportResponse
{
    private readonly IDbConnection _dbConnection;
    private readonly ILogger<GenereteReportResponse> _logger;
    private readonly IHttpClientFactory _httpClientFactory;

    public GenereteReportResponse(IDbConnection dbConnection, IHttpClientFactory httpClientFactory, ILogger<GenereteReportResponse> logger)
    {
        _dbConnection = dbConnection;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task GenerateReport(string reportId)
    {
        reportId = reportId.Replace("\"", "");
        try
        {
            List<ContactReportDetail> reportDetails = new();
            List<ContactFeature> features = new();

            var contacts = await GetContacts();


            foreach (var contact in contacts)
            {
                var featureResult = await GetContactFeatures(contact.Id.ToString());

                if (featureResult.Any() == true)
                    features.AddRange(featureResult);
            }

            var distinctAddresses = features.Where(w => w.FeatureType == "ADDRESS").DistinctBy(d => d.FeatureInformation);

            foreach (var address in distinctAddresses)
            {
                var contactIds = features.Where(w => w.FeatureInformation == address.FeatureInformation && w.FeatureType == "ADDRESS").Select(s => s.ContactId);

                int phoneCount = 0;


                int contactCount = features.Where(w => w.FeatureType == "ADDRESS").Where(w => w.FeatureInformation == address.FeatureInformation).Select(s => s.ContactId).Distinct().Count();

                foreach (var contactId in contactIds)
                {
                    if (features.Any(w => w.ContactId == contactId && w.FeatureType == "PHONE" && string.IsNullOrEmpty(w.FeatureInformation) == false) == true)
                        phoneCount++;
                }

                ContactReportDetail reportDetail = new()
                {
                    ContactReportId = Guid.Parse(reportId),
                    Address = address.FeatureInformation is null ? "Adresi bulunmayan" : address.FeatureInformation,
                    ContactCount = contactCount,
                    PhoneCount = phoneCount,
                };

                reportDetails.Add(reportDetail);
            }

            await ReportDetailPostAsync(reportDetails);

            _logger.LogInformation("{0}'li rapor oluşturuldu.", reportId);
        }
        catch
        {
            _logger.LogError("Rapor oluşturulurken hata oluştu.");
        }
    }
    private async Task<IEnumerable<Contact>> GetContacts()
    {
        string query = "SELECT * FROM \"Contacts\"";

        var result = await _dbConnection.QueryAsync<Contact>(query);

        return result;
    }

    private async Task<IEnumerable<ContactFeature>> GetContactFeatures(string contactId)
    {
        string query = "SELECT * FROM \"ContactFeatures\" WHERE \"ContactId\" = @ContactId";

        var result = await _dbConnection.QueryAsync<ContactFeature>(query, new { ContactId = Guid.Parse(contactId) });

        return result;
    }
    private async Task ReportDetailPostAsync(List<ContactReportDetail> details)
    {
        try
        {
            using var httpClient = _httpClientFactory.CreateClient("");

            var response = await httpClient.PostAsJsonAsync("https://localhost:6003/api/reportdetails", details);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

}
