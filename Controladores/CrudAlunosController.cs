using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Classes;
using ProjetoAcademia_Api.Tabelas;

namespace ProjetoAcademia_Api.Controladores;
[Route("api/academia/aluno")]
public class CrudAlunosController : Controller
{
	private readonly CrudAlunos _crudAlunos;
    public CrudAlunosController(CrudAlunos crudAlunos)
    {
        _crudAlunos = crudAlunos;
    }


    [HttpPost("Adicionar")]
	public IActionResult PostAlunos([FromBody] TbCadAluno CadAluno)
	{
		var retornoApi = _crudAlunos.PostAluno(CadAluno);
		var resposta = new { Mensagem = $"{retornoApi}" };
		return Ok(resposta);
	}

	[HttpPut("AtualizarDados")]
	public IActionResult AtualizaDadosAluno([FromBody]TbCadAluno cadAluno)
	{
		var retornoApi = _crudAlunos.UpdateAluno(cadAluno);
		var resposta = new { Mensagem = $"{retornoApi}" };
		
		return Ok(resposta);
	}

	[HttpGet("ExibirAluno")]
	public IActionResult GetAluno(int IdAluno)
	{
		var retornoApi = _crudAlunos.GetAluno(IdAluno);
		var resposta = new { Mensagem = $"{retornoApi}" };
		return Ok(resposta);
	}

	[HttpGet("ExibirAlunos")]
	public IActionResult GetAlunos(int IdAcademia)
	{
		var retornoApi = _crudAlunos.GetAlunos(IdAcademia);
		var resposta = new { Mensagem = $"{retornoApi}" };
		return Ok(resposta);
	}


	[HttpGet("ExibirAlunosPesquisa")]
	public IActionResult GetAlunosPesquisa(int IdAcademia, string NomePesquisado)
	{
		var retornoApi = _crudAlunos.GetAlunosPesquisa(IdAcademia, NomePesquisado);
		var resposta = new { Mensagem = $"{retornoApi}" };
		return Ok(resposta);
	}


	[HttpDelete("DeleteAluno")]
	public IActionResult DeletaAluno(int IdAluno)
	{
		var retornoApi = _crudAlunos.DeletaAluno(IdAluno);
		var resposta = new { Mensagem = $"{retornoApi}" };
		return Ok(resposta);

	}
}
