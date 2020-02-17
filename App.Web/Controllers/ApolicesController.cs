using App.Application.ApoliceCommands;
using App.Domain;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Domain.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace App.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ApolicesController : AppControllerBase
	{
		private readonly ILogger<ApolicesController> logger;

		public ApolicesController(ILogger<ApolicesController> logger) => this.logger = logger;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Apolice>>> GetList([FromServices] IApoliceRead db)
		{
			var items = await db.GetApolicesAsync();

			return Ok(items);
		}

		[HttpPost]
		public async Task<ActionResult<Apolice>> RegisterApolice(
			[FromServices] IMediator mediator,
			[FromBody] ApoliceViewModel apolice)
		{
			var request = new ApoliceRegisterRequest(apolice);

			var result = await mediator.Send(request, CancellationToken.None);

			if (result.HasValidation) return BadRequest(result);

			return ((Result<Apolice>)result).Data;
		}
	}
}
