using Mailkit_Send_Email_API.Models;
using System.Threading.Tasks;

namespace Mailkit_Send_Email_API.Interfaces
{
	public interface IEmailService
	{
		Task SendEmailAsync(SendEmailRequest request);
	}
}
