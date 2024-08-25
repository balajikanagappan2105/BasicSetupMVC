using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EffortEntry.Repository.Interfaces.Base
{
	public interface IRepository<T>
	   where T : class
	{
		IEnumerable<T> All();
		T FindByKey(int Id);
		T Create(T entity);
		void Delete(T entity);
		void Update(T entity);
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate, string[] includes = null);
		IEnumerable<T> FindByNoTracking(Expression<Func<T, bool>> predicate, string[] includes = null);
		void Save();
		void Attach(T entity);		
	}
}
