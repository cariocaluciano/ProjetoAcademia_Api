using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Tabelas;
using System.Data.SqlClient;

namespace ProjetoAcademia_Api.Classes;

public class FazLogOf
{
	public string? RetornoProcedure { get; set; }

	private string ExecutaComandosNoBanco(string nomeStoredProcedure, SqlParameter[] parametros)
	{
		RetornoProcedure = Db.ExecutarStoredProcedure(nomeStoredProcedure, parametros);
		return RetornoProcedure;
	}


	public string PostLogOf(TbLogOfAcademia LogOf)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@Token", LogOf.Token),
			  new SqlParameter("@IdAcademia",LogOf.IdAcademia)
			  };
			RetornoProcedure = ExecutaComandosNoBanco("PcDeslogaUsuarioAcademia", parametros);
			
			return RetornoProcedure;

		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}



	}


}
