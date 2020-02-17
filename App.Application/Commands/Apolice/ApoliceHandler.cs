using App.Domain;
using App.Domain.Entities;
using App.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.ApoliceCommands
{
	public class ApoliceHandler :
		IRequestHandler<ApoliceRegisterRequest, Result>
	{
		private readonly IMediator mediator;
		private readonly IRepository<Apolice> db;
		private readonly IApoliceRead read;
		private readonly IUnitOfWork uow;
		private readonly IRepository<Segurado> seguradoDb;

		public ApoliceHandler(
				IMediator mediator,
				IRepository<Apolice> db,
				IApoliceRead read,
				IUnitOfWork uow,
				IRepository<Segurado> seguradoDb)
		{
			this.mediator = mediator;
			this.db = db;
			this.read = read;
			this.uow = uow;
			this.seguradoDb = seguradoDb;
		}

		public async Task<Result> Handle(ApoliceRegisterRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var segurado = await seguradoDb.GetByIdAsync(request.Apolice.SeguradoId);

				if (segurado == null)
					throw new Exception($"SeguradoID {request.Apolice.SeguradoId} não encontrado.");

				var check = await read.GetBySegurado(segurado);
				if (check != null)
				{
					if (check.Veiculo.MarcaModelo == request.Apolice.VeiculoModeloMarca && check.Veiculo.Valor == request.Apolice.VeiculoValor)
						return new Result<Apolice>(check);

					if (check.Veiculo.MarcaModelo == request.Apolice.VeiculoModeloMarca)
					{
						db.Remove(check);
					}
				}

				var vehicle = new Veiculo(request.Apolice.VeiculoModeloMarca, request.Apolice.VeiculoValor);

				var item = new Apolice(segurado, vehicle);

				var result = db.Add(item);

				if (uow.Commit())
				{
					await mediator.Publish(new ApoliceNotification()
					{
						EventName = nameof(ApoliceRegisterRequest),
						Id = result.Id,
						ValorSeguro = result.ValorSeguro,
						ValorRisco = result.ValorRisco,
						ValorMargem = result.ValorMargem,
						Cliente = segurado,
						Veiculo = result.Veiculo
					}, cancellationToken);
				}

				return new Result<Apolice>(result);
			}
			catch (Exception ex)
			{
				var result = new Result();
				result.AddValidation(ex.Message);
				return result;
			}
		}
	}
}
