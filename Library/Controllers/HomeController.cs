using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Library.Models;
using Library.ViewModels;

namespace Library.Controllers;

public class HomeController : Controller
{
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(LibraryContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    public async Task<ActionResult> Index()
    {
        ViewBag.IsLoggedIn = User.Identity.IsAuthenticated;
        if (ViewBag.IsLoggedIn)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
            Person member = _db.Persons.SingleOrDefault(person => person.PersonId == currentUser.PersonId);
            ViewBag.Name = member.FirstName;
        }

        // if (TempData["SpecialError"] != null)
        //     ViewBag.QueryError = TempData["SpecialError"];

        // if (TempData["Matches"] != null)
        //     ViewBag.Matches = TempData["Matches"];
        return View();
    }

    // Search for books by author and title
    // public ActionResult Search(QueryViewModel model)
    // {
    //     if (model.TitleQuery == null && model.AuthorQuery == null)
    //     {
    //         TempData["SpecialError"] = "Search by author and/or title.";
    //         return RedirectToAction("Index");
    //     }

        List<BookMatchViewModel> matches = new List<BookMatchViewModel>();
        // if (model.TitleQuery != null && model.AuthorQuery != null)
        // {
        // }
        // else if (model.TitleQuery != null)
        // {
        // }
        // else if (model.AuthorQuery != null)
        // {
        // }

    //     if (matches.Count == 0)
    //     {
    //         TempData["SpecialError"] = "No matches found.";
    //         return RedirectToAction("Index");
    //     }

    //     TempData["Matches"] = matches;

    //     return RedirectToAction("Index");
    // }

    
}