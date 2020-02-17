using App.Application.ApoliceCommands;
using App.Domain;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Domain.ViewModels;
using MediatR;
using Moq;
using System;
using System.Threading;
using Xunit;
using Xunit.Abstractions;


namespace App.Application.Tests
{
	public class ApoliceHandlersTests : IClassFixture<StandartFixture>
	{
		private readonly ITestOutputHelper output;
		private readonly StandartFixture fixture;

		public ApoliceHandlersTests(ITestOutputHelper output, StandartFixture fixture)
		{
			this.output = output;
			this.fixture = fixture;
		}

		[Fact]
		public void Should_Create_New()
		{
			Log($"Verifica se o objeto {nameof(ApoliceHandler)} é criado");

			//arrange
			var mediator = new Mock<IMediator>();
			IRepository<Apolice> db = fixture.ApoliceRepository;
			IApoliceRead read = fixture.ApoliceRepository;
			IUnitOfWork uow = fixture.UnitOfWork;
			IRepository<Segurado> seguradoDb = fixture.SeguradoRepository;

			//act
			var sut = new ApoliceHandler(mediator.Object, db, read, uow, seguradoDb);

			//assert
			Assert.NotNull(sut);
		}

		[Fact]
		public void Should_Register_Apolice()
		{
			Log($"Verifica se o handle para  {nameof(ApoliceRegisterRequest)} é executado");

			//arrange
			var mediator = new Mock<IMediator>();
			IRepository<Apolice> db = fixture.ApoliceRepository;
			IApoliceRead read = fixture.ApoliceRepository;
			IUnitOfWork uow = fixture.UnitOfWork;
			IRepository<Segurado> seguradoDb = fixture.SeguradoRepository;
			var sut = new ApoliceHandler(mediator.Object, db, read, uow, seguradoDb);
			var aplRegister = new ApoliceRegisterRequest(new ApoliceViewModel
			{
				SeguradoId = 1,
				VeiculoModeloMarca = "Meriva/Chevrolet",
				VeiculoValor = 10000
			});

			//act
			var result = sut.Handle(aplRegister, CancellationToken.None).Result;

			//assert
			Log("Verifica se o retorno é do tipo Result<Apolice>");
			Assert.IsAssignableFrom<Result<Apolice>>(result);

			var obj = (Result<Apolice>)result;
			Log("Verifica se existe alguma validação no retorno");
			Assert.True(!obj.HasValidation);
			Log("Verifica se o Id do segurado registrado na apolice confere com o enviado na requisição");
			Assert.Equal(aplRegister.Apolice.SeguradoId, obj.Data.Segurado.Id);
			Log("Verifica se o valor do seguro calculado está de acordo com o esperado");
			Assert.Equal(270.375, obj.Data.ValorSeguro);
		}

		private void Log(string msg)
			=> output.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff")}\t{msg}");
	}
}
