using FDMToDoListProjectWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace FDMToDoListProjectWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
