using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDMToDoListProject.DataAccess.Repository.IRepository
{
	internal interface IUnitOfWork
	{
		ICategoryRepository Category { get; }

		void Save();
	}
}
