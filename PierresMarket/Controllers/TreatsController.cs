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
  public class TreatsController : Controller
  {
    private readonly PierresMarketContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public TreatsController(UserManager<ApplicationUser> userManager, PierresMarketContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userTreats);
    }

    public ActionResult Create()
    {
      // ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat treat, int FlavorId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      treat.User = currentUser;
      _db.Treats.Add(treat);
      _db.SaveChanges();
      if (FlavorId != 0)
      {
          _db.TreatFlavor.Add(new TreatFlavor() { FlavorId = FlavorId, TreatId = treat.TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // [AllowAnonymous]
    // public ActionResult Details(int id)
    // {
    //   var thisTreat = _db.Treats
    //       .Include(treat => treat.JoinEntities)
    //       .ThenInclude(join => join.Treat)
    //       .FirstOrDefault(treat => treat.TreatId == id);
    //   return View(thisTreat);
    // }

    // public ActionResult Edit(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    //   ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
    //   return View(thisTreat);
    // }

    // [HttpPost]
    // public ActionResult Edit(Treat treat, int TreatId)
    // {
    //   if (TreatId != 0)
    //   {
    //     _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, TreatId = treat.TreatId });
    //   }
    //   _db.Entry(treat).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult AddTreat(int id)
    // {
    //   var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
    //   ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
    //   return View(thisTreat);
    // }

    // [HttpPost]
    // public ActionResult AddTreat(Treat treat, int TreatId)
    // {
    //   if (TreatId != 0)
    //   {
    //   _db.TreatFlavor.Add(new TreatFlavor() { TreatId = TreatId, TreatId = treat.TreatId });
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
    // public ActionResult DeleteTreat(int joinId)
    // {
    //   var joinEntry = _db.TreatFlavor.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
    //   _db.TreatFlavor.Remove(joinEntry);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }
  }
}