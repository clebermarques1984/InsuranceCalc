using App.Data;
using App.Data.Repository;
using App.Data.UoW;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Tests
{

	public class StandartFixture
	{
		public App.Data.AppContext Context { get; private set; }

		public ApoliceRepository ApoliceRepository { get; private set; }
		public SeguradoRepository SeguradoRepository { get; private set; }

		public UnitOfWork UnitOfWork { get; private set; }

		public StandartFixture()
		{
			var options = new DbContextOptionsBuilder<AppContext>()
			   .UseInMemoryDatabase(databaseName: "test_database")
			   .Options;

			Context = new App.Data.AppContext(options);
			ApoliceRepository = new ApoliceRepository(Context);
			SeguradoRepository = new SeguradoRepository(Context);
			UnitOfWork = new UnitOfWork(Context);
		}

	}
}
