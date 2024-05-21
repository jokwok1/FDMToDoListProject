using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FDMToDoListProject.DataAccess.Data;
using FDMToDoListProject.DataAccess.Repository.IRepository;
using FDMToDoListProject.Models;

namespace FDMToDoListProject.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private ApplicationDbContext _db; // dependency injection
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
			_db = db;
        }

        public void Save()
		{
			_db.SaveChanges();
		}

		public void Update(Category obj)
		{
			_db.Categories.Update(obj);
		}
	}
}
