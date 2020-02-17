using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Data.Repository
{
	public class ApoliceRepository : Repository<Apolice>, IApoliceRead, IRepositoryWrite<Apolice>
	{
		public ApoliceRepository(AppContext context) : base(context) { }

		public async Task<IEnumerable<Apolice>> GetApolicesAsync()
		{
			return await GetList()
				.Include(v => v.Veiculo)
				.Include(c => c.Segurado)
				.ToListAsync();
		}

		public async Task<Apolice> GetBySegurado(Segurado segurado)
		{
			return await GetList(p => p.Segurado == segurado)
							.Include(v => v.Veiculo)
							.AsNoTracking().SingleOrDefaultAsync();
		}
	}
}
