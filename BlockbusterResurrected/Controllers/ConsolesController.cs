using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using BlockbusterResurrected.Models;

namespace BlockbusterResurrected.Controllers
{
  public class ConsolesController : Controller
  {
    private readonly BlockbusterResurrectedContext _db;

    public ConsolesController(BlockbusterResurrectedContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Consoles.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Console console)
    {
      _db.Consoles.Add(console);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisConsole = _db.Consoles
        .Include(console => console.Games)
        .ThenInclude(join => join.Game)
        .FirstOrDefault(console => console.ConsoleId == id);
      return View(thisConsole);
    }

    public ActionResult Delete(int id)
    {
      var thisConsole = _db.Consoles.FirstOrDefault(consoles => consoles.ConsoleId == id);
      return View(thisConsole);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisConsole = _db.Consoles.FirstOrDefault(consoles => consoles.ConsoleId == id);
      _db.Consoles.Remove(thisConsole);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteGame(int joinId)
    {
      var joinEntry = _db.ConsoleGame.FirstOrDefault(entry => entry.ConsoleGameId == joinId);
      _db.ConsoleGame.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}