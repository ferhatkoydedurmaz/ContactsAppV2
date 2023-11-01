using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.ContactReportAPI.Controllers;
[Route("api")]
[ApiController]
public class ContactReportController : ControllerBase
{
    [HttpGet("reports")]
    public async Task<IActionResult> GetReport()
    {
        return Ok();
    }
    [HttpPost("reports")]
    public async Task<IActionResult> AddReport()
    {
        return Ok();
    }

}
