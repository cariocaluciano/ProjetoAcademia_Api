using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Classes;

namespace ProjetoAcademia_Api.Controladores;

[Route("api/Adiciona")]
public class AdicionaUsuariosEAcademiasController : Controller
{
	public readonly CrudAcademia _crudAcademia;
	public readonly	CrudAlunos _alunos;

	public AdicionaUsuariosEAcademiasController(CrudAcademia crudAcademia, CrudAlunos alunos)
	{
		_crudAcademia = crudAcademia;
		_alunos = alunos;
	}


	[HttpPost("Academia")]
	public string PostAcademia(string NomeAcademia, string CnpjAcademia, string NomeUsuario, string CpfUsuario,
							 string NomeCompleto, string Email, string Contato, string Senha)
	{
		var retornoProcedure = _crudAcademia.PostAcademia(NomeAcademia,CnpjAcademia,NomeUsuario,CpfUsuario,NomeCompleto,Email,Contato,Senha);
		return retornoProcedure;
	}

	[HttpPost("Aluno")]
	public string PostAluno(int IdAcademia,string NomeCompleto, string Cpf, string Email, string Contato, string Senha)
	{
		var retornoProcedure = _alunos.PostAluno(IdAcademia, NomeCompleto, Cpf, Email, Contato, Senha);
        return retornoProcedure;
	}

}

