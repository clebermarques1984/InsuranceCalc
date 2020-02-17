using App.Domain;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
	public class AppControllerBase : ControllerBase
	{
		protected IActionResult ValidationHandler(Result result)
		{
			if (!result.HasValidation) return Ok(result);

			return BadRequest(result);
		}

	}
}
