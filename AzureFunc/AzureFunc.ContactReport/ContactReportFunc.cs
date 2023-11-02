using System;
using System.Threading.Tasks;
using AzureFunc.ContactReport.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunc.ContactReport
{
    public class ContactReportFunc
    {
        private readonly GenereteReportResponse _genereteReportResponse;

        public ContactReportFunc(GenereteReportResponse genereteReportResponse)
        {
            _genereteReportResponse = genereteReportResponse;
        }

        [FunctionName("Function1")]
        public async Task Run([ServiceBusTrigger("contactreport", Connection = "queueConnStr")]string reportId)
        {
            await _genereteReportResponse.GenerateReport(reportId);
        }
    }
}
