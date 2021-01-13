using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using BlockbusterResurrected.Models;

namespace BlockbusterResurrected.Controllers
{
  public class GConsolesController : Controller
  {
    private readonly BlockbusterResurrectedContext _db;

    public GConsolesController(BlockbusterResurrectedContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.GConsoles.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(GConsole console)
    {
      _db.GConsoles.Add(console);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisConsole = _db.GConsoles
        .Include(console => console.Games)
        .ThenInclude(join => join.Game)
        .FirstOrDefault(console => console.GConsoleId == id);
      return View(thisConsole);
    }

    public ActionResult Delete(int id)
    {
      var thisConsole = _db.GConsoles.FirstOrDefault(consoles => consoles.GConsoleId == id);
      return View(thisConsole);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisConsole = _db.GConsoles.FirstOrDefault(consoles => consoles.GConsoleId == id);
      _db.GConsoles.Remove(thisConsole);
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

    public ActionResult Edit(int id)
    {
      var thisConsole = _db.GConsoles.FirstOrDefault(consoles => consoles.GConsoleId == id);
      return View(thisConsole);
    }

    [HttpPost]
    public ActionResult Edit(GConsole gConsole)
    {
      _db.Entry(gConsole).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}