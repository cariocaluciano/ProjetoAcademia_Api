using ProjetoAcademia_Api.Tabelas;
using System.Data.SqlClient;


namespace ProjetoAcademia_Api.Classes;

public class AdicionaAcademia
{
    public string? RetornoProcedure { get; set;}

    private string ExecutaComandosNoBanco(string nomeStoredProcedure, SqlParameter[] parametros) 
	{
		RetornoProcedure = Db.ExecutarStoredProcedure(nomeStoredProcedure, parametros);
		return RetornoProcedure;
	}

    public string PostAcademia(TbCadAcademia tbCadAcademia , string token)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@NomeAcademia",tbCadAcademia.NomeAcademia ),
			  new SqlParameter("@CnpjAcademia", tbCadAcademia.CnpjAcademia),
			  new SqlParameter("@NomeUsuario", tbCadAcademia.NomeUsuario),
			  new SqlParameter("@CpfUsuario",tbCadAcademia.CpfUsuario ),
			  new SqlParameter("@NomeCompleto",tbCadAcademia.NomeCompleto ),
			  new SqlParameter("@Email", tbCadAcademia.Email),
			  new SqlParameter("@Contato", tbCadAcademia.Contato),
			  new SqlParameter("@Senha",tbCadAcademia.Senha ),
			  new SqlParameter("@EmailValidado","false"),
			  new SqlParameter("@Token",token)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcPostAcademia", parametros);
			return RetornoProcedure;
		}
		catch (Exception ex) 
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
        }
	}

	public string VerificaEmailNoBanco(string email)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
				  new SqlParameter("@Email", email)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("PcVerificaSeExisteEmail", parametros);

			return RetornoProcedure;
		}
		catch (Exception ex) 
		{
		 RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}
	}

	public string VerificaTokenEAtualizaEmailValidado(string token)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
				  new SqlParameter("@Token", token)
			  };

			RetornoProcedure = ExecutaComandosNoBanco("VerificaTokenEAtualizaEmailValidado", parametros);

			return RetornoProcedure;
		}
		catch (Exception ex)
		{
			RetornoProcedure = ex.Message.ToString();
			return RetornoProcedure;
		}
	}

}
