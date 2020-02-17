using App.Domain;
using App.Domain.Entities;

namespace App.Application.ApoliceCommands
{
	public class ApoliceNotification : Event
	{
		public int Id { get; set; }

		public double ValorSeguro { get; set; }

		public double ValorRisco { get; set; }

		public double ValorMargem { get; set; }

		public Segurado Cliente { get; set; }

		public Veiculo Veiculo { get; set; }
	}
}
