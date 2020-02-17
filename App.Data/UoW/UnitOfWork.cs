using App.Domain.Interfaces;

namespace App.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppContext _context;

		public UnitOfWork(AppContext context)
		{
			_context = context;
		}

		public bool Commit()
		{
			return _context.SaveChangesAsync().Result > 0;
		}
	}
}
