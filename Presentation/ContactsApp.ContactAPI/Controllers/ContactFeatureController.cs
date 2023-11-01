using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.ContactAPI.Controllers;
[Route("api")]
[ApiController]
public class ContactFeatureController : ControllerBase
{

    [HttpGet("contact-details")]
    public async Task<IActionResult> GetContact()
    {
        return Ok();
    }
    [HttpPost("contact-details")]
    public async Task<IActionResult> AddOrUpdateContact()
    {
        return Ok();
    }
}
