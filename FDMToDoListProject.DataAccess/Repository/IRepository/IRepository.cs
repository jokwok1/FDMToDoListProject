using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FDMToDoListProject.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class //generics
	{
		//T - Category
		IEnumerable<T> GetAll();
		T Get(Expression<Func<T,bool>> filter); // run a function and return boolean
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity);
	}
}
