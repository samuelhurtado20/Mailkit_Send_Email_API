using Mailkit_Send_Email_API.Interfaces;
using Mailkit_Send_Email_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Mailkit_Send_Email_API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmailController : ControllerBase
	{
		private readonly ILogger<EmailController> _logger;
		private readonly IEmailService _emailService;

		public EmailController(ILogger<EmailController> logger, IEmailService emailService)
		{
			_logger = logger;
			_emailService = emailService;
		}

		/// <summary>
		/// Send a email
		/// </summary>
		/// <param name="request">Email Info</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Send(SendEmailRequest request)
		{
			_logger.LogInformation(request.ToString());
			try
			{
				await _emailService.SendEmailAsync(request);
				return Ok(request);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
