using Microsoft.AspNetCore.Mvc;

namespace BlockbusterResurrected.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}