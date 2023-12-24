using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Classes;
using ProjetoAcademia_Api.Tabelas;

namespace ProjetoAcademia_Api.Controladores;

[Route("api/login")]
public class LoginController : Controller
{
	private readonly VerificaLoginAcademia _verificaLoginAcademia;

public LoginController(VerificaLoginAcademia verificaLoginAcademia)
	{
		_verificaLoginAcademia = verificaLoginAcademia;
	}


	[HttpPost("Academia")]
	public IActionResult LogaAcademia([FromBody] TbLoginAcademia tbLoginAcademia)
	{

        var retornoApi = _verificaLoginAcademia.Postlogin(tbLoginAcademia);

		var resposta = new { Mensagem = $"{retornoApi}" };

		return Ok(resposta);
	}
}
