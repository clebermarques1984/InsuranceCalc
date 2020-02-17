using App.Application.Domain;
using App.Domain;
using App.Domain.ViewModels;
using MediatR;

namespace App.Application.ApoliceCommands
{
	public class ApoliceRegisterRequest : Validatable, IRequest<Result>
	{
		public ApoliceViewModel Apolice { get; set; }

		public ApoliceRegisterRequest(ApoliceViewModel apolice) => this.Apolice = apolice;

		public override void Validate()
		{
			if (Apolice.SeguradoId <= 0)
				AddNotification(nameof(Apolice.SeguradoId), "SeguradoID é obrigatório");

			if (string.IsNullOrWhiteSpace(Apolice.VeiculoModeloMarca))
				AddNotification(nameof(Apolice.VeiculoModeloMarca), "Modelo/Marca do veiculo é obrigatório");

			if (Apolice.VeiculoValor <= 0)
				AddNotification(nameof(Apolice.VeiculoValor), "Valor do veículo deve ser um valor positivo");
		}
	}


}
