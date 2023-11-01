using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.WebUI.Controllers;
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
