using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Classes;
using ProjetoAcademia_Api.Tabelas;

namespace ProjetoAcademia_Api.Controladores;

[Route("api/Adiciona")]
public class AdicionaUsuarioAcademiaController : Controller
{
	public readonly AdicionaAcademia _adicionaAcademia;
	public readonly CrudAlunos _alunos;
	public readonly EnviaEmailVerificacao _enviaEmailVerificacao;

	public AdicionaUsuarioAcademiaController(AdicionaAcademia crudAcademia, CrudAlunos alunos, EnviaEmailVerificacao enviaEmailVerificacao)
	{
		_adicionaAcademia = crudAcademia;
		_alunos = alunos;
		_enviaEmailVerificacao = enviaEmailVerificacao;
	}

	[HttpPost("VerificaEmail")]
	public IActionResult VerificaEmailNoBanco(string email) 
	{
        var retornoApi = _adicionaAcademia.VerificaEmailNoBanco(email);
		var resposta = new { Mensagem = $"{retornoApi}" };
        return Ok(resposta);
	}


	[HttpPost("Academia")]
	public async Task<IActionResult> PostAcademia([FromBody] TbCadAcademia tbCadAcademia)
	{
		var Token = await _enviaEmailVerificacao.EnviaEmail(tbCadAcademia);

		var retornoApi = _adicionaAcademia.PostAcademia(tbCadAcademia , Token );
		var resposta = new { Mensagem = $"{retornoApi}" };
		return Ok(resposta);
	}


	[HttpPost("confirmartoken")]
	public IActionResult RetornoTokenVerificacaoEmail([FromBody]TbToken Token)
	{
		var retornoApi = _adicionaAcademia.VerificaTokenEAtualizaEmailValidado(Token.Token);
		var resposta = new { Mensagem = $"{retornoApi}" };

		return Ok(resposta);
	}


	//[HttpPost("Aluno")]
	//public string PostAluno(int IdAcademia, string NomeCompleto, string Cpf, string Email, string Contato, string Senha)
	//{
	//	var retornoProcedure = _alunos.PostAluno(IdAcademia, NomeCompleto, Cpf, Email, Contato, Senha);
	//	return retornoProcedure;
	//}

}

