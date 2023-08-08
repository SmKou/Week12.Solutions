using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using ToDoList.Models;

namespace ToDoList.Controllers;

public class HomeController : Controller
{

    private readonly ToDoListContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ToDoListContext db, UserManager<ApplicationUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    [HttpGet("/")]
    public async Task<ActionResult> Index()
    {
        Category[] categories = _db.Categories.ToArray();
        Dictionary<string, object[]> model = new Dictionary<string, object[]>();
        model.Add("Categories", categories);

        string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationUser currentUser = await _userManager.FindByIdAsync(userId);
        if (currentUser != null)
        {
            Item[] items = _db.Items
                .Where(entry => entry.User.Id == currentUser.Id)
                .ToArray();
            model.Add("Items", items);
        }
        return View(model);
    }
}
