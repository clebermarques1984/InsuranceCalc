using App.Domain.Entities;
using App.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Data.Repository
{
	public class SeguradoRepository : Repository<Segurado>, ISeguradoRead, IRepositoryWrite<Segurado>
	{
		public SeguradoRepository(AppContext context) : base(context) { }

		public async Task<IEnumerable<Segurado>> GetListByNameAsync(string name)
			=> await GetList(p => p.Nome == name).ToListAsync();

		public async Task<Segurado> GetByCPFAsync(string CPF)
			=> await GetList(p => p.CPF == CPF).SingleOrDefaultAsync();
	}
}
