using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FDMToDoListProject.Models;

namespace FDMToDoListProject.DataAccess.Repository.IRepository
{
    public interface IToDoListRepository : IRepository<ToDoList>
    {
        void Update(ToDoList obj);
        public void Save();
    }
}
