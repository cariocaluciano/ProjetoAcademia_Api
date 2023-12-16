namespace ProjetoAcademia_Api.Tabelas_BancoDados;

public class Login_Academia
{
    public int Id { get; set; }
    public string NomeAcademia { get; set; }
    public string NomeGestor { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }

    public List<Login_Aluno> IdAluno { get; set; }
}
