using Microsoft.AspNetCore.Mvc;
using System.Linq;
// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Threading.Tasks;

using PierresMarket.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
      private readonly PierresMarketContext _db;
      public HomeController(PierresMarketContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        ViewBag.Treats = _db.Treats.ToList();
        ViewBag.Flavors = _db.Flavors.ToList();
        return View();
      }

    }
}