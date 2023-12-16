using System;
using System.Data;
using System.Data.SqlClient;

public static class Db
{
	private static string connectionString = "Data Source=DESKTOP-UUNA063;Initial Catalog=DBAcademia;User ID=sa;Password=33460068;";

	public static string ExecutarStoredProcedure(string nomeStoredProcedure, SqlParameter[] parametros)
	{
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			try
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand(nomeStoredProcedure, connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					if (parametros != null)
					{
						command.Parameters.AddRange(parametros);
					}

					command.ExecuteNonQuery();

					//using (SqlDataReader reader = command.ExecuteReader())
					//{ 
					// while (reader.Read()) 
					//	{
					//		retornoProcedure = reader["Retorno"].ToString();
					//	}
					//}
				}
				return "Sucesso";
			}
			catch (Exception ex)
			{
				return "Erro: " + ex.Message.ToString();
			}
		}
	}
}
