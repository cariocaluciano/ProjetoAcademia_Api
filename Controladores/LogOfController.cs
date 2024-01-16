using Microsoft.AspNetCore.Mvc;
using ProjetoAcademia_Api.Classes;
using ProjetoAcademia_Api.Tabelas;

namespace ProjetoAcademia_Api.Controladores;

[Route("Api/LogOf")]
public class LogOfController : Controller
{
    public readonly FazLogOf _deslogaUsuario;
    public LogOfController(FazLogOf deslogaUsuario)
    {
        _deslogaUsuario = deslogaUsuario;
    }


	[HttpPost]
	public IActionResult DeslogaAcademia([FromBody] TbLogOfAcademia LogOf)
	{
     
        var retornoApi = _deslogaUsuario.PostLogOf(LogOf);
		var resposta = new { Mensagem = $"{retornoApi}" };
        return Ok(resposta);

	}
}
