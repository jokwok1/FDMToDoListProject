using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDMToDoListProject.DataAccess.Data;
using FDMToDoListProject.DataAccess.Repository.IRepository;
using FDMToDoListProject.Models;

namespace FDMToDoListProject.DataAccess.Repository
{
    public class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
    {
        private ApplicationDbContext _db; // dependency injection
        public ToDoListRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ToDoList obj)
        {
            _db.ToDoLists.Update(obj);
        }
    }
}
