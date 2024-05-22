using System.Collections.Generic;
using FDMToDoListProject.DataAccess.Data;
using FDMToDoListProject.DataAccess.Repository.IRepository;
using FDMToDoListProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FDMToDoListProjectWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ToDoListController : Controller
    {
        private readonly IToDoListRepository _toDoListRepo;
		private readonly ICategoryRepository _categoryRepo;

		public ToDoListController(IToDoListRepository db, ICategoryRepository categoryRepo)
        {
            _toDoListRepo = db; // constructor to access to db
            _categoryRepo = categoryRepo;
		}

        public IActionResult Index()
        {
            var objToDoListList = _toDoListRepo.GetAll().ToList();
            
            return View(objToDoListList); // pass the object into the view
        }

        public IActionResult Create()
        {
		//Returning list of Categories
		    IEnumerable<SelectListItem> CategoryList = _categoryRepo
			    .GetAll().ToList().Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.Id.ToString()
			}); // Convert category into a SelectListTime w name and Category

            ViewBag.CategoryList = CategoryList;
            // name given after ViewBag. is a key value

			return View();
        }
        [HttpPost]
        public IActionResult Create(ToDoList obj)
        {

            if (!ModelState.IsValid) //tells us if current state of model is valid
            {
                return View(); // if validation check fails, stay on the page
            }

            _toDoListRepo.Add(obj);
            _toDoListRepo.Save();
            return RedirectToAction("Index", "ToDoList");
            // create a redirection to reload list, and you can explictly state
            //which controller to use
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            ToDoList toDoListFromDb = _toDoListRepo.Get(u => u.Id == id); //Find uses primary key
            //Other methods that dont need to work with id
            //ToDoList ToDoListFromDb1 = _db.Categories.FirstOrDefault(u => u.Name == "name");
            if (toDoListFromDb == null)
            {
                return NotFound();
            }
            return View(toDoListFromDb);
        }

        [HttpPost]
        public IActionResult Edit(ToDoList obj)
        {

            _toDoListRepo.Update(obj);
            _toDoListRepo.Save();
            return RedirectToAction("Index", "ToDoList");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            ToDoList toDoListFromDb = _toDoListRepo.Get(u => u.Id == id);
            if (toDoListFromDb == null)
            {
                return NotFound();
            }
            return View(toDoListFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            ToDoList toDoListFromDb = _toDoListRepo.Get(u => u.Id == id);
            if (toDoListFromDb == null)
            {
                return NotFound();
            }
            _toDoListRepo.Remove(toDoListFromDb); //update method
            _toDoListRepo.Save();
            return RedirectToAction("Index", "ToDoList");
        }
    }
}
