using ListaDeTarefasMVC.Helper;
using ListaDeTarefasMVC.Models;
using ListaDeTarefasMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefasMVC.Controllers
{
	public class RedefinirSenhaController : Controller
	{
        private readonly ISessao _sessao;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public RedefinirSenhaController(ISessao sessao, IUsuarioRepositorio usuarioRepositorio)
		{
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }

		public IActionResult AlterarSenha()
		{
			return View();
		}


        [HttpPost]
        public IActionResult AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _sessao.BuscarSessaoDoUsuario();

                    alterarSenhaModel.Id = usuario.Id;
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    

                    TempData["MensagemSucesso"] = $"Senha alterada com sucesso!";
                    return RedirectToAction("Index", "Home");
                }

                return View(alterarSenhaModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar alterar a senha do seu usuário. Detalhe erro: {ex.Message}";
                return View(alterarSenhaModel);
            }
        }
    }
}
