using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.WebUI.Controllers;
public class ContactReportController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
