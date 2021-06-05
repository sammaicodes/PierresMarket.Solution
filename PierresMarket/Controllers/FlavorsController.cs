using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PierresMarket.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PierresMarket.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly PierresMarketContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public FlavorsController(UserManager<ApplicationUser> userManager, PierresMarketContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
      {
        var allFlavors = _db.Flavors;
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId != null) {
          var currentUser = await _userManager.FindByIdAsync(userId);
          var userFlavors = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).ToList();
          return View(userFlavors);
        }
        else { return View(allFlavors); }
      }
      // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // var currentUser = await _userManager.FindByIdAsync(userId);
      // var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
      // return View(userTreats);
    }

    public ActionResult Create()
    {
      // ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor, int TreatId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      if (TreatId != 0)
      {
          _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, FlavorId = flavor.FlavorId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // [AllowAnonymous]
    // public ActionResult Details(int id)
    // {
    //   var thisTreat = _db.Treats
    //       .Include(treat => treat.JoinEntities)
    //       .ThenInclude(join => join.Flavor)
    //       .FirstOrDefault(treat => treat.TreatId == id);
    //   return View(thisTreat);
    // }

    // public ActionResult Edit(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    //   ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorType");
    //   return View(thisTreat);
    // }

    // [HttpPost]
    // public ActionResult Edit(Treat treat, int FlavorId)
    // {
    //   if (FlavorId != 0)
    //   {
    //     _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
    //   }
    //   _db.Entry(treat).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult AddFlavor(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    //   ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorType");
    //   return View(thisTreat);
    // }

    // [HttpPost]
    // public ActionResult AddFlavor(Treat treat, int FlavorId)
    // {
    //   if (FlavorId != 0)
    //   {
    //   _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
    //   }
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    //   return View(thisTreat);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    //   _db.Treats.Remove(thisTreat);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // [HttpPost]
    // public ActionResult DeleteFlavor(int joinId)
    // {
    //   var joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
    //   _db.TreatFlavor.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}