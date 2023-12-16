namespace ProjetoAcademia_Api.Tabelas_BancoDados;

public class Login_Aluno
{
	public int Id { get; set; }
	public string Nome { get; set; }	
	public string Email { get; set; }
    public string Senha { get; set; }

    public Login_Academia IdAcademia { get; set; }

}
