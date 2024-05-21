using FDMToDoListProjectWeb.Data;
using FDMToDoListProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FDMToDoListProjectWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db; // constructor to access to db
        }

        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();
            Console.Write(objCategoryList);
            return View(objCategoryList); // pass the object into the view
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //custom errors
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot exactly match name");
                // put key to assign error under the field in the HTML
            }

            if (!ModelState.IsValid) //tells us if current state of model is valid
            {
                return View(); // if validation check fails, stay on the page
            }

            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Category");
            // create a redirection to reload list, and you can explictly state
            //which controller to use
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }

            Category categoryFromDb = _db.Categories.Find(id); //Find uses primary key
            //Other methods that dont need to work with id
            //Category categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Name == "name");
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{

			_db.Categories.Update(obj); //update method
			_db.SaveChanges();
			return RedirectToAction("Index", "Category");
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category categoryFromDb = _db.Categories.Find(id); 
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(categoryFromDb); //update method
			_db.SaveChanges();
			return RedirectToAction("Index", "Category");
		}
	}
}
