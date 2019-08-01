using Microsoft.AspNetCore.Mvc;

namespace FluentIdentity.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestApiController : ControllerBase
	{
		[HttpGet]
		public IActionResult TestGet()
		{
			return Ok();
		}
	}
}
