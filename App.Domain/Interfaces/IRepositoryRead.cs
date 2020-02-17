using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
	public interface IRepositoryRead<T> : IDisposable where T : class
	{
		IQueryable<T> GetList();

		IQueryable<T> GetList(Expression<Func<T, bool>> predicate);

		IQueryable<T> GetList(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

		Task<T> GetByIdAsync(int id);

		Task<IEnumerable<T>> GetListAsync();

		Task<T> GetByAsync(Expression<Func<T, bool>> predicate);
	}

}
