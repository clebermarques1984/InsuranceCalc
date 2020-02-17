using System;

namespace App.Domain.Interfaces
{
	public interface IRepository<T> : IRepositoryRead<T>, IRepositoryWrite<T>, IDisposable where T : class
	{
	}
}
