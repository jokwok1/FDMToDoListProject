using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDMToDoListProject.DataAccess.Data;
using FDMToDoListProject.DataAccess.Repository.IRepository;

namespace FDMToDoListProject.DataAccess.Repository
{
	internal class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db; // dependency injection
		public ICategoryRepository Category { get; private set; }
		public UnitOfWork(ApplicationDbContext db) 
		{
			_db = db;
			Category = new CategoryRepository(_db);
		}
		

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
