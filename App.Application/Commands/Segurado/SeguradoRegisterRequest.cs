using App.Application.Domain;
using App.Domain;
using App.Domain.ViewModels;
using MediatR;

namespace App.Application.SeguradoCommands
{
	public class SeguradoRegisterRequest : Validatable, IRequest<Result>
	{
		public SeguradoViewModel Segurado { get; set; }

		public SeguradoRegisterRequest(SeguradoViewModel client) => this.Segurado = client;

		public override void Validate()
		{
			if (string.IsNullOrWhiteSpace(Segurado.Nome))
				AddNotification(nameof(Segurado.Nome), "Nome é obrigatório");

			if (string.IsNullOrWhiteSpace(Segurado.Cpf))
				AddNotification(nameof(Segurado.Cpf), "CPF é obrigatório");
		}
	}

	public class SeguradoUpdateRequest : SeguradoRegisterRequest
	{
		public int Id { get; set; }


		public SeguradoUpdateRequest(int id, SeguradoViewModel client) : base(client)
		{
			this.Id = id;
			this.Segurado = client;
		}
	}

	public class SeguradoDeleteRequest : IRequest<Result>
	{
		public SeguradoDeleteRequest(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}