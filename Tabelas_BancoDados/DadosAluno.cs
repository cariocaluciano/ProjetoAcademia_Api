namespace ProjetoAcademia_Api.Tabelas_BancoDados;

public class DadosAluno
{
	public Login_Aluno Id { get; set; }
	public string NomeCompleto { get; set;}
    public DateTime DataPagamento { get; set; }
	public Decimal ValorMensalidade { get; set; }
	public string Contato { get; set;}
	public string Email { get; set;}


    public TabelaTreinoMontadoParaAluno IdTreino { get; set; }


}
