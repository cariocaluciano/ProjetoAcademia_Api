using System;
using System.Data;
using System.Data.SqlClient;

public static class Db
{
	//"Data Source=projacademia-server.database.windows.net;Initial Catalog=projacademia-database;User ID=projacademia-server-admin;Password=33460068@bC;" Conexão com  AZURE
	//"Data Source=DESKTOP-UUNA063;Initial Catalog=DBAcademia;User ID=sa;Password=33460068;"
	private static string connectionString = "Data Source=DESKTOP-UUNA063;Initial Catalog=DBAcademia;User ID=sa;Password=33460068;";

    public static string ExecutarStoredProcedure(string nomeStoredProcedure, SqlParameter[] parametros)
	{
		using (SqlConnection connection = new SqlConnection(connectionString))
		{
			try
			{
				var retornoProcedure = "";

				connection.Open();

				using (SqlCommand command = new SqlCommand(nomeStoredProcedure, connection))
				{
                    command.CommandType = CommandType.StoredProcedure;

					if (parametros != null)
					{
						command.Parameters.AddRange(parametros);
					}
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							retornoProcedure = reader["Retorno"].ToString();

                        }
					}
					//command.ExecuteNonQuery();
				}
				return retornoProcedure.ToString();
			}
			catch (Exception ex)
			{
                Console.WriteLine(	"Erro no BD" + ex.Message);
                return "Erro: " + ex.Message.ToString() ;
			}
		}
	}
}
