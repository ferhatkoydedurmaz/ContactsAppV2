using ContactsApp.ContactReportAPI.Models;
using ContactsApp.ContactReportAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.ContactReportAPI.Controllers;
[Route("api")]
[ApiController]
public class ContactReportController : ControllerBase
{
    private readonly ContactReportService _contactReportService;
    private readonly ContactReportDetailService _contactReportDetailService;

    public ContactReportController(ContactReportDetailService contactReportDetailService, ContactReportService contactReportService)
    {
        _contactReportDetailService = contactReportDetailService;
        _contactReportService = contactReportService;
    }

    [HttpGet("reports")]
    public async Task<IActionResult> GetReport()
    {
        var result = await _contactReportService.GetReportsAsync();
        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpGet("create-report")]
    public async Task<IActionResult> CreateReport()
    {
        var result = await _contactReportService.CreateReport();
        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("reportdetails")]
    public async Task<IActionResult> GetReportDetails([FromQuery] string id)
    {
        var result = await _contactReportDetailService.GetContactReportDetailsByReportIdAsync(id);

        if(result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("reportdetails")]
    public async Task<IActionResult> CreateReportDetails([FromBody] List<ContactReportDetail> reportDetails)
    {
        await _contactReportDetailService.CreateReportDetailAsync(reportDetails);
        return Ok();
    }

}
