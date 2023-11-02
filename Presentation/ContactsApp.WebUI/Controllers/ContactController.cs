using ContactsApp.WebUI.Models;
using ContactsApp.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.WebUI.Controllers;
[Route("contact")]
public class ContactController : Controller
{
    private readonly ContactService _contactService;
    private readonly ContactFeatureService _contactFeatureService;
    private readonly ContactReportService _contactReportService;

    public ContactController(ContactReportService contactReportService, ContactFeatureService contactFeatureService, ContactService contactService)
    {
        _contactReportService = contactReportService;
        _contactFeatureService = contactFeatureService;
        _contactService = contactService;
    }

    [HttpPost("add-contact")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddContact(Contact model)
    {
        if (ModelState.IsValid == false)
            return BadRequest();

        var result = await _contactService.AddContactAsync(model);

        return Json(result);
    }
   
    [HttpDelete("delete-contact")]
    public async Task<IActionResult> DeleteContact([FromBody] string id)
    {
        var result = await _contactService.DeleteContactAsync(id);
        return Json(result);
    }

    [HttpPut("update-contact")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateContact(Contact model)
    {
        if (ModelState.IsValid == false)
            return BadRequest();

        var result = await _contactService.UpdateContactAsync(model);

        return Json(result);
    }

    [HttpPut("update-contact-feature")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateContactFeature(ContactFeatureList model)
    {
        
        var result = await _contactFeatureService.AddOrUpdateContactFeaturesAsync(model);

        return Json(result);
    }

    #region Get Methods

    [HttpGet("add-contact")]
    public IActionResult Contact()
    {
        return View("Contact");
    }
    [HttpGet("contact-detail")]
    public async Task<IActionResult> ContactDetail([FromQuery] string id)
    {
        var result = (await _contactService.GetContactById(id))?.Data;
        return View("ContactDetail", result);
    }
    [HttpGet("contact-feature-detail")]
    public async Task<IActionResult> ContactFeatureDetail([FromQuery] string id)
    {
        var result = (await _contactFeatureService.GetContactFeaturesByContactIdAsync(id))?.Data;
        return View("ContactFeatureDetail", result);
    }

    [HttpGet("contacts-listing")]
    public async Task<IActionResult> ContactListing()
    {
        var result = (await _contactService.GetAllContactAsync())?.Data;
        return View("ContactListing", result);
    }

    [HttpGet("contact-report-listing")]
    public async Task<IActionResult> ReportListing()
    {
        var result = (await _contactReportService.GetAllReportAsync())?.Data;
        return View("ContactReportListing", result);
    }

    [HttpGet("generate-contact-report")]
    public async Task<IActionResult> GenerateContactReport()
    {
        var result = await _contactReportService.CreateContactReportAsync();
        return Json(result);
    }
    [HttpGet("get-contact-report-detail")]
    public async Task<IActionResult> GetContactReportDetail([FromQuery] string reportId)
    {
        var result = (await _contactReportService.GetContactReportDetailAsync(reportId)).Data;
        return View("ContactReportDetail", result);
    }

    #endregion
}
