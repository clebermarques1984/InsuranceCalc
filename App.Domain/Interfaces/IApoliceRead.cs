using App.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
	public interface IApoliceRead : IRepositoryRead<Apolice>
	{
		Task<Apolice> GetBySegurado(Segurado segurado);

		Task<IEnumerable<Apolice>> GetApolicesAsync();
	}
}
