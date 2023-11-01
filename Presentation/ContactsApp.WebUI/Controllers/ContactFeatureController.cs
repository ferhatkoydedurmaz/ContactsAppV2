using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.WebUI.Controllers;
public class ContactFeatureController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
