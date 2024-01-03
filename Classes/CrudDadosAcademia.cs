using System.Data.SqlClient;

namespace ProjetoAcademia_Api.Classes;

public class CrudDadosAcademia
{
	public string? RetornoProcedure { get; set; }

	private string ExecutaComandosNoBanco(string nomeStoredProcedure, SqlParameter[] parametros)
	{
		RetornoProcedure = Db.ExecutarStoredProcedure(nomeStoredProcedure, parametros);
		return RetornoProcedure;
	}

	public string? GetDadosAcademia(string Token)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@Token",Token)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcGetAcademia", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}


	}



}
