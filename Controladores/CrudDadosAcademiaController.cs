using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Classes;

namespace ProjetoAcademia_Api.Controladores;

[Route("api/DadosAcademia")]
public class CrudDadosAcademiaController : Controller
{
	private readonly CrudDadosAcademia _crudDadosAcademia;
		public CrudDadosAcademiaController(CrudDadosAcademia crudDadosAcademia)
	{
		_crudDadosAcademia = crudDadosAcademia;
	}

	[HttpGet("GetAcademia")]
	public IActionResult GetDadosAcademia(string Token)
	{
		var retornoApi = _crudDadosAcademia.GetDadosAcademia(Token);
		var resposta = new { Mensagem = $"{retornoApi}" };

		return Ok(resposta);
	}
}
