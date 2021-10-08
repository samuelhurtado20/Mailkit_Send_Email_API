using MailKit.Net.Smtp;
using MailKit.Security;
using Mailkit_Send_Email_API.Interfaces;
using Mailkit_Send_Email_API.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Threading.Tasks;

namespace Mailkit_Send_Email_API.Services
{
	public class EmailService : IEmailService
	{
		public readonly SmtpSettings _smtpSettings;

		public EmailService(IOptions<SmtpSettings> smtpSettings)
		{
			_smtpSettings = smtpSettings.Value;
		}

		/// <summary>
		/// Service to Send an email
		/// </summary>
		/// <param name="request">Email Info</param>
		/// <returns></returns>
		public async Task SendEmailAsync(SendEmailRequest request)
		{
			try
			{
				MimeMessage msg = new();
				//
				msg.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
				msg.To.Add(new MailboxAddress(@"", request.Email));
				msg.Subject = request.Subject;
				msg.Body = new TextPart("html") { Text = request.Body };
				//
				using var client = new SmtpClient(); 
				await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, SecureSocketOptions.StartTls);
				await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password);
				await client.SendAsync(msg);
				await client.DisconnectAsync(true);
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}
