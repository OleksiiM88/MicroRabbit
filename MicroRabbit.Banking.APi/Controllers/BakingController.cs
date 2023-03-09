using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MicroRabbit.Banking.APi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BakingController : ControllerBase
	{
		private readonly IAccountService _accountService;
        public BakingController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        //GET api/baking
        [HttpGet]
		public ActionResult<IEnumerable<Account>> Get()
		{
			return Ok(_accountService.GetAccounts());
		}
	}
}
