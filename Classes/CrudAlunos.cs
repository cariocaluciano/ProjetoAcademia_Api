using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Tabelas;
using System.Data.SqlClient;
using System.Globalization;

namespace ProjetoAcademia_Api.Classes;

public class CrudAlunos
{
	public string? RetornoProcedure { get; set; }

	private string ExecutaComandosNoBanco(string nomeStoredProcedure, SqlParameter[] parametros)
	{
		RetornoProcedure = Db.ExecutarStoredProcedure(nomeStoredProcedure, parametros);
		return RetornoProcedure;
	}

	public string PostAluno(TbCadAluno tbCad)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@IdAcademia",tbCad.IdAcademia ),
			  new SqlParameter("@NomeCompleto", tbCad.NomeCompleto),
			  new SqlParameter("@Cpf", tbCad.Cpf),
			  new SqlParameter("@Email",tbCad.Email ),
			  new SqlParameter("@Contato",tbCad.Contato ),
			  new SqlParameter("@Senha", tbCad.Senha),
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcPostAluno", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}

	public string UpdateAluno(TbCadAluno tbCad)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@IdAluno" , tbCad.IdAluno),
			  new SqlParameter("@IdAcademia",tbCad.IdAcademia ),
			  new SqlParameter("@NomeCompleto", tbCad.NomeCompleto),
			  new SqlParameter("@Cpf", tbCad.Cpf),
			  new SqlParameter("@Email",tbCad.Email ),
			  new SqlParameter("@Contato",tbCad.Contato ),
			  new SqlParameter("@Senha", tbCad.Senha),
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcAtualizaAluno", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}

	public string GetAluno(int Id)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@IdAluno" , Id)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcGetAluno", parametros);
            return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}


	public string GetAlunos(int Id)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@IdAcademia" , Id)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcGetAlunos", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}


	public string GetAlunosPesquisa(int Id, string AlunoPesquisa, int TipoPesquisa)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@IdAcademia" , Id),
			  new SqlParameter("@NomeAluno", AlunoPesquisa),
			  new SqlParameter("@TipoPesquisa", TipoPesquisa)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("GetAlunosPesquisa", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}



	public string DeletaAluno(int Id)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@IdAluno" , Id)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcDeletaAluno", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}
}
