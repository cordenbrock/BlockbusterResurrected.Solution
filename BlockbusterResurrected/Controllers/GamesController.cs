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
      ViewBag.ConsoleId = new SelectList(_db.Consoles, "ConsoleId", "ConsoleName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Game game, int ConsoleId)
    {
      _db.Games.Add(game);
      if (ConsoleId != 0)
      {
        _db.ConsoleGame.Add(new ConsoleGame() {ConsoleId = ConsoleId, GameId = game.GameId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisGame = _db.Games
        .Include(game => game.Consoles)
        .ThenInclude(join => join.Console)
        .FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }


    public ActionResult Edit(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(games => games.GameId == id);
      ViewBag.ConsoleId = new SelectList(_db.Consoles, "ConsoleId", "ConsoleName");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult Edit(Game game, int ConsoleId)
    {
      if (ConsoleId != 0)
      {
        _db.ConsoleGame.Add(new ConsoleGame() { ConsoleId = ConsoleId, GameId = game.GameId });
      }
      _db.Entry(game).State = EntityState.Modified;
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

  }
}