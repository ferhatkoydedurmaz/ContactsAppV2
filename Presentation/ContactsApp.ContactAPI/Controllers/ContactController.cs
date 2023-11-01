using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.ContactAPI.Controllers;
[Route("api")]
[ApiController]
public class ContactController : ControllerBase
{
    [HttpGet("contacts")]
    public async Task<IActionResult> GetContact()
    {
        return Ok();
    }
    [HttpPost("contacts")]
    public async Task<IActionResult> AddContact()
    {
        return Ok();
    }
    [HttpPut("contacts")]
    public async Task<IActionResult> UpdateContact()
    {
        return Ok();
    }
    [HttpDelete("contacts")]
    public async Task<IActionResult> DeleteContact()
    {
        return Ok();
    }
}
