using App.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
	public interface ISeguradoRead : IRepositoryRead<Segurado>
	{
		Task<IEnumerable<Segurado>> GetListByNameAsync(string name);

		Task<Segurado> GetByCPFAsync(string CPF);
	}
}
