using App.Domain;
using App.Domain.Entities;
using App.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.SeguradoCommands
{
	public class SeguradoHandler :
		IRequestHandler<SeguradoRegisterRequest, Result>,
		IRequestHandler<SeguradoDeleteRequest, Result>,
		IRequestHandler<SeguradoUpdateRequest, Result>
	{
		private readonly IMediator mediator;
		private readonly IMapper mapper;
		private readonly IRepository<Segurado> db;
		private readonly IUnitOfWork uow;

		public SeguradoHandler(IMediator mediator, IMapper mapper, IRepository<Segurado> db, IUnitOfWork uow)
		{
			this.mediator = mediator;
			this.mapper = mapper;
			this.db = db;
			this.uow = uow;
		}

		public async Task<Result> Handle(SeguradoRegisterRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var segurado = mapper.Map<Segurado>(request);

				var result = db.Add(segurado);

				if (uow.Commit())
				{
					await mediator.Publish(new SeguradoNotification()
					{
						EventName = nameof(SeguradoRegisterRequest),
						Id = result.Id,
						Name = result.Nome,
						CPF = result.CPF,
						Idade = result.Idade,
					}, cancellationToken);
				}

				return new Result<Segurado>(result);
			}
			catch (Exception ex)
			{
				var result = new Result();
				result.AddValidation(ex.Message);
				return result;
			}
		}

		public async Task<Result> Handle(SeguradoDeleteRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var segurado = await db.GetByIdAsync(request.Id);

				if (segurado != null)
				{
					var result = db.Remove(segurado);

					if (uow.Commit())
					{
						await mediator.Publish(new SeguradoNotification()
						{
							EventName = nameof(SeguradoRegisterRequest),
							Id = result.Id,
							Name = result.Nome,
							CPF = result.CPF,
							Idade = result.Idade,
						}, cancellationToken);

						return new Result<Segurado>(result);
					}
				}

				return Result.Ok;
			}
			catch (Exception ex)
			{
				var result = new Result();
				result.AddValidation(ex.Message);
				return result;
			}
		}

		public async Task<Result> Handle(SeguradoUpdateRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var segurado = await db.GetByAsync(p => p.Id == request.Id);

				if (segurado == null)
					throw new Exception("Segurado não encontrado");

				var result = mapper.Map<Segurado>(request);

				db.Update(result);

				if (uow.Commit())
				{
					await mediator.Publish(new SeguradoNotification()
					{
						EventName = nameof(SeguradoUpdateRequest),
						Id = result.Id,
						Name = result.Nome,
						CPF = result.CPF,
						Idade = result.Idade,
					}, cancellationToken);

					return new Result<Segurado>(result);
				}

				return Result.Ok;
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
