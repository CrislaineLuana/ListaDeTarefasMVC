using ListaDeTarefasMVC.Helper;
using ListaDeTarefasMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefasMVC.ViewComponents
{
	public class Menu : ViewComponent
	{
		private readonly ISessao _sessao;
		public Menu(ISessao sessao)
		{
			_sessao = sessao;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			UsuarioModel usuario = _sessao.BuscarSessaoDoUsuario();
			return View(usuario);
		}


	}
}
