using BlockbusterResurrected.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlockbusterResurrected.Controllers
{
  public class HomeController : Controller
  {
    private readonly BlockbusterResurrectedContext _db;

    public HomeController(BlockbusterResurrectedContext db)
    {
      _db = db;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var consolesgames = from cg in _db.ConsoleGame
                    select cg;

        if (!String.IsNullOrEmpty(searchString))
        {
            consolesgames = consolesgames.Where(s => s.Game.GameTitle.Contains(searchString));
        }

        return View(await consolesgames.ToAsyncEnumerable().ToList());
    }



  }
}








