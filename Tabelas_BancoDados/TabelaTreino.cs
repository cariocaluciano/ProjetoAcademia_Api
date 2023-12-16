namespace ProjetoAcademia_Api.Tabelas_BancoDados;

public class TabelaTreinoMontadoParaAluno
{
    public int Id { get; set; }

    public List<TabelaDeExercicios> IdTabelaExercicios { get; set; }

}