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
	private string GeraToken()
	{
		string tokenConfirmacao = Guid.NewGuid().ToString();
		return tokenConfirmacao;
	}

	public string InsereTokenNoLoginDoUsuario(string idAcademia, string token)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
					  {
			  new SqlParameter("@IdAcademia", idAcademia),
			  new SqlParameter("@Token",token )
					  };

			RetornoProcedure = ExecutaComandosNoBanco("PcAtualizaTbLoginEInsereToken", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}
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
            if (RetornoProcedure.Contains("Sucesso"))
			{
				string separador = "Código:";
				int indiceSeparador = RetornoProcedure.IndexOf(separador);
				string IdAcademia = RetornoProcedure.Substring(indiceSeparador + separador.Length);

				string Token = GeraToken();

				InsereTokenNoLoginDoUsuario(IdAcademia, Token);
				RetornoProcedure = $"Sucesso: {Token}";
			}
			
			return RetornoProcedure;

		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}

	}



}
