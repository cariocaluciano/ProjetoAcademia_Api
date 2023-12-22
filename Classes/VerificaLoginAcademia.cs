using ProjetoAcademia_Api.Tabelas;
using System.Data.SqlClient;

namespace ProjetoAcademia_Api.Classes;

public class VerificaLoginAcademia
{
	public string? RetornoProcedure { get; set; }

	private string ExecutaComandosNoBanco(string nomeStoredProcedure, SqlParameter[] parametros)
	{
		RetornoProcedure = Db.ExecutarStoredProcedure(nomeStoredProcedure, parametros);
		return RetornoProcedure;
	}

	public string Postlogin(TbLoginAcademia tbLoginAcademia)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@Email", tbLoginAcademia.Email),
			  new SqlParameter("@Senha",tbLoginAcademia.Senha )
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcLogaUsuarioAcademia", parametros);
            return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}


}
