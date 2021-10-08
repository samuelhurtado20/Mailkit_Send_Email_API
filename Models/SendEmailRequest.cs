namespace Mailkit_Send_Email_API.Models
{
	public class SendEmailRequest
	{
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }

		public override string ToString()
		{
			return $"Email: {Email}. - Subject: {Subject}. - Body: {Body}";
		}
	}
}
