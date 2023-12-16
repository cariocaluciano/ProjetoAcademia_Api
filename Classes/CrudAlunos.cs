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

	public string PostAluno(int IdAcademia, string NomeCompleto, string Cpf, string Email, string Contato, string Senha)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@IdAcademia",IdAcademia ),
			  new SqlParameter("@NomeCompleto", NomeCompleto),
			  new SqlParameter("@Cpf", Cpf),
			  new SqlParameter("@Email",Email ),
			  new SqlParameter("@Contato",Contato ),
			  new SqlParameter("@Senha", Senha),
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

}
