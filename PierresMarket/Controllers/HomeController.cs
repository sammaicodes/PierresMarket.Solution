// using Microsoft.AspNetCore.Mvc;

// namespace PierresMarket.Controllers
// {
//     public class HomeController : Controller
//     {

//       [HttpGet("/")]
//       public ActionResult Index()
//       {
//         return View();
//       }

//     }
// }

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PierresMarket.Models;

namespace PierresMarket.Controllers
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