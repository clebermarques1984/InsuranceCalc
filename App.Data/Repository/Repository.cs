using App.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Data.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppContext _context;

		protected DbSet<T> Items { private get; set; }

		public Repository(AppContext context)
		{
			_context = context;
			Items = context.Set<T>();
		}

		public async Task<T> GetByIdAsync(int id) => await Items.FindAsync(id);

		public IQueryable<T> GetList() => Items;

		public IQueryable<T> GetList(Expression<Func<T, bool>> predicate)
			=> Items.Where(predicate);

		public IQueryable<T> GetList(
			Expression<Func<T, bool>> predicate,
			params Expression<Func<T, object>>[] includes)
		{
			var result = Items.AsQueryable();

			if (includes.Any())
				foreach (var include in includes)
					result = result.Include(include);

			return result.Where(predicate);
		}

		public T Add(T entity) => Items.Add(entity).Entity;

		public T Remove(T entity) => Items.Remove(entity).Entity;

		public void Update(T entity)
			=> _context.Entry(entity).State = EntityState.Modified;

		public async Task<IEnumerable<T>> GetListAsync()
			=> await GetList().AsNoTracking().ToListAsync();

		public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate)
			=> await GetList(predicate).AsNoTracking().FirstOrDefaultAsync();

		public void Dispose()
		{
			Items = null;
			GC.SuppressFinalize(this);
		}
	}
}
