using ListaDeTarefasMVC.Models;
using ListaDeTarefasMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefasMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILoginRepositorio _loginRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ILoginRepositorio loginRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _loginRepositorio = loginRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _loginRepositorio.BuscarPorLogin(loginModel.Login);
                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha informados estão invalidos!";
                    return RedirectToAction("Index", "Login", loginModel);
                }

                TempData["MensagemErro"] = $"Preencha todos os campos!";
                return RedirectToAction("Index", "Login", loginModel);

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar logar no sistema. Detalhe erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
