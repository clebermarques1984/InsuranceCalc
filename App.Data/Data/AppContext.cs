using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace App.Data
{
	public class AppContext : DbContext
	{
		public static readonly LoggerFactory _myLoggerFactory =
			new LoggerFactory(new[] { new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() });

		public DbSet<Segurado> Segurados { get; set; }
		public DbSet<Apolice> Apolices { get; set; }
		public DbSet<Veiculo> Veiculos { get; set; }

		public AppContext() { }

		public AppContext(DbContextOptions<AppContext> options) : base(options)
		{
			_ = Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLoggerFactory(_myLoggerFactory);
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			var segurado = builder.Entity<Segurado>();

			segurado.ToTable("Segurado");

			segurado.Property(s => s.CPF).IsRequired();

			segurado.HasData(new Segurado
			{
				Id = 1,
				Nome = "Cleber",
				CPF = "32791318130",
				Idade = 35
			});

			//Configure Remain Entities
			// ...
		}
	}
}
