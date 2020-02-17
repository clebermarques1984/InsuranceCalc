using App.Application.SeguradoCommands;
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
	public class SeguradosController : AppControllerBase
	{
		private readonly ILogger<SeguradosController> logger;

		public SeguradosController(ILogger<SeguradosController> logger) => this.logger = logger;

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Segurado>>> GetList([FromServices] ISeguradoRead db)
		{
			var items = await db.GetListAsync();

			return Ok(items);
		}

		[HttpGet]
		[Route("{id:int}")]
		public async Task<ActionResult<Segurado>> GetById([FromServices] ISeguradoRead db, int id)
		{
			var segurado = await db.GetByIdAsync(id);

			if (segurado == null)
				return NotFound();

			return Ok(segurado);
		}

		[HttpGet]
		[Route("by-name")]
		public async Task<ActionResult<IEnumerable<Segurado>>> GetByName(
			[FromServices] ISeguradoRead db,
			[FromQuery] string name)
		{
			var client = await db.GetListByNameAsync(name);

			if (client == null)
				return NotFound();

			return Ok(client);
		}

		[HttpPost]
		public async Task<ActionResult<Segurado>> SeguradoRegister(
			[FromServices] IMediator mediator,
			[FromBody] SeguradoViewModel segurado)
		{
			var request = new SeguradoRegisterRequest(segurado);

			var result = await mediator.Send(request, CancellationToken.None);

			if (result.HasValidation) return BadRequest(result);

			return ((Result<Segurado>)result).Data;
		}

		[HttpDelete]
		[Route("{id:int}")]
		public async Task<IActionResult> SeguradoDelete([FromServices] IMediator mediator, int id)
		{
			var request = new SeguradoDeleteRequest(id);

			var result = await mediator.Send(request, CancellationToken.None);

			if (result.HasValidation) return BadRequest(result);

			return Ok(result);

		}

		[HttpPut]
		[Route("{id:int}")]
		public async Task<ActionResult<Segurado>> SeguradoUpdate(
			[FromServices] IMediator mediator,
			[FromBody] SeguradoViewModel segurado,
			int id)
		{
			var request = new SeguradoUpdateRequest(id, segurado);

			var result = await mediator.Send(request, CancellationToken.None);

			if (result.HasValidation) return BadRequest(result);

			return ((Result<Segurado>)result).Data;
		}
	}
}
