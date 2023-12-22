using ProjetoAcademia_Api.Tabelas;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAcademia_Api.Classes;

public class EnviaEmailVerificacao
{
	private readonly IConfiguration _configuration; //Para acessar o Json de configurações 

	public EnviaEmailVerificacao(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public async Task<string> EnviaEmail(TbCadAcademia tbCadAcademia)
	{
		string host = _configuration.GetValue<string>("SMTP:Host");
		string nome = _configuration.GetValue<string>("SMTP:Nome");
		string userName = _configuration.GetValue<string>("SMTP:UserName");
		string senha = _configuration.GetValue<string>("SMTP:Senha");
		int porta = _configuration.GetValue<int>("SMTP:Porta");

		string tokenConfirmacao = Guid.NewGuid().ToString();
		string assunto = "Confirmação de Email";
		string mensagem = "Por favor, clique no link para confirmar seu email:\n\n{0}";
		mensagem = string.Format(mensagem, $"http://127.0.0.1:5500/TelaCadastro_Academia/Valida_Email/index.html?Token={tokenConfirmacao}");

		MailMessage Mail = new MailMessage() 
		{
		 From = new MailAddress(userName, nome),
		};

		Mail.To.Add(tbCadAcademia.Email);
		Mail.Subject = assunto;
		Mail.Body = mensagem;
		Mail.IsBodyHtml = true;
		Mail.Priority = MailPriority.High;

		using (SmtpClient smtp = new SmtpClient(host, porta))
		{
			smtp.Credentials = new NetworkCredential(userName, senha);
			smtp.EnableSsl = true;

			smtp.Send(Mail);


		}
			
		return tokenConfirmacao;
	}
}

