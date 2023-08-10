using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Library.Models;

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

        if (TempData["Matches"] != null)
            ViewBag.Matches = TempData["Matches"];
        return View();
    }

    // Search for books by author and title
    // public ActionResult Search(string query) { }
}