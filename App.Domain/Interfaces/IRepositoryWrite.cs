using System;

namespace App.Domain.Interfaces
{
	public interface IRepositoryWrite<T> : IDisposable where T : class
	{
		T Add(T entity);

		T Remove(T entity);

		void Update(T entity);
	}
}
