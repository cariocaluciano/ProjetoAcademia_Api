using System.Data.SqlClient;


namespace ProjetoAcademia_Api.Classes;

public class CrudAcademia
{
    public string? RetornoProcedure { get; set;}

    private string ExecutaComandosNoBanco(string nomeStoredProcedure, SqlParameter[] parametros) 
	{
		RetornoProcedure = Db.ExecutarStoredProcedure(nomeStoredProcedure, parametros);
		return RetornoProcedure;
	}

    public string PostAcademia(string NomeAcademia, string CnpjAcademia, string NomeUsuario, string CpfUsuario,
							 string NomeCompleto, string Email, string Contato, string Senha)
	{
		try
		{
			SqlParameter[] parametros = new SqlParameter[]
			  {
			  new SqlParameter("@NomeAcademia",NomeAcademia ),
			  new SqlParameter("@CnpjAcademia", CnpjAcademia),
			  new SqlParameter("@NomeUsuario", NomeUsuario),
			  new SqlParameter("@CpfUsuario",CpfUsuario ),
			  new SqlParameter("@NomeCompleto",NomeCompleto ),
			  new SqlParameter("@Email", Email),
			  new SqlParameter("@Contato", Contato),
			  new SqlParameter("@Senha",Senha )
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


}
