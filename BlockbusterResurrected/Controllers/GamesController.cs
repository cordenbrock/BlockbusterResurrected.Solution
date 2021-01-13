using BlockbusterResurrected.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlockbusterResurrected.Controllers
{
  public class GamesController : Controller
  {
    private readonly BlockbusterResurrectedContext _db;
    public GamesController(BlockbusterResurrectedContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Game> model = _db.Games.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.GConsoleId = new SelectList(_db.GConsoles, "GConsoleId", "GConsoleName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Game game, int GConsoleId)
    {
      _db.Games.Add(game);
      if (GConsoleId != 0)
      {
        _db.ConsoleGame.Add(new ConsoleGame() {GConsoleId = GConsoleId, GameId = game.GameId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisGame = _db.Games
        .Include(game => game.GConsoles)
        .ThenInclude(join => join.GConsole)
        .FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }


    public ActionResult Edit(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      ViewBag.GConsoleId = new SelectList(_db.GConsoles, "GConsoleId", "GConsoleName");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult Edit(Game game, int GConsoleId)
    {
      if (GConsoleId != 0)
      {
        _db.ConsoleGame.Add(new ConsoleGame() { GConsoleId = GConsoleId, GameId = game.GameId });
      }
      _db.Entry(game).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddGConsole(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      ViewBag.GConsoleId = new SelectList(_db.GConsoles, "GConsoleId", "GConsoleName");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult AddGConsole(Game game, int GConsoleId)
    {
      if (GConsoleId != 0)
      {
        _db.ConsoleGame.Add(new ConsoleGame() { GConsoleId = GConsoleId, GameId = game.GameId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      return View(thisGame);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      _db.Games.Remove(thisGame);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteGConsole(int joinId)
    {
      var joinEntry = _db.ConsoleGame.FirstOrDefault(entry => entry.ConsoleGameId == joinId);
      _db.ConsoleGame.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}