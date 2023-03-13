using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.DTO;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace MicroRabbit.MVC.Controller
{
	[ApiController]
	[Route("api/[controller]")]
	public class HomeController : ControllerBase
	{
		private readonly ITransferService _transferService;

        public HomeController(ITransferService transferService)
        {
			_transferService = transferService;   
        }
		[HttpPost]
		public async Task<IActionResult> Transfer(TransferViewModel transferViewModel)
		{
			TransferDto transferDto = new TransferDto()
			{
				FromAccount = transferViewModel.FromAccount,
				ToAccount = transferViewModel.ToAccount,
				TransferAccount = transferViewModel.TransferAmount
			};

			await _transferService.Transfer(transferDto);
			return RedirectToAction("Index");
		}
	}
}
