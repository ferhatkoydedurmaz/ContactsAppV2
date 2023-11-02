using ContactsApp.ContactAPI.Models;
using ContactsApp.ContactAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.ContactAPI.Controllers;
[Route("api")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly ContactService _contactService;

    public ContactController(ContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet("contacts")]
    public async Task<IActionResult> GetContact()
    {
        var result = await _contactService.GetContactsAsync();

        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpGet("contactbyid")]
    public async Task<IActionResult> GetContactById([FromQuery] string id)
    {
        var result = await _contactService.GetContactAsync(id);

        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("contacts")]
    public async Task<IActionResult> AddContact(Contact model)
    {
        var result = await _contactService.AddContactAsync(model);

        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpPut("contacts")]
    public async Task<IActionResult> UpdateContact(Contact model)
    {
        var result = await _contactService.UpdateContactAsync(model);
        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }
    [HttpDelete("contacts")]
    public async Task<IActionResult> DeleteContact([FromQuery] string id)
    {
        var result = await _contactService.DeleteContactAsync(id);

        if (result.Success == false)
            return BadRequest(result);

        return Ok(result);
    }
}
