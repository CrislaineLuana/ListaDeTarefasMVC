using ListaDeTarefasMVC.Helper;
using ListaDeTarefasMVC.Models;
using ListaDeTarefasMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefasMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILoginRepositorio _loginRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ILoginRepositorio loginRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _loginRepositorio = loginRepositorio;
            _sessao = sessao;
            _email = email; 
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");  
        }


        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenha)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLoginEEmail(redefinirSenha.Login, redefinirSenha.Email);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Sitema de controle de tarefas - Redefinição de senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Editar(usuario);
                            TempData["MensagemSucesso"] = "Enviamos uma nova senha para o e-mail cadastrado!";
                            return RedirectToAction("Index", "Login");
                        } else
                        {
                            TempData["MensagemErro"] = "Ocorreu um erro ao encaminhar sua nova senha por e-mail";
                            return View("RedefinirSenha", redefinirSenha);
                        }

                    }
                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Verifique os dados informados!";
                }
                return View("RedefinirSenha", redefinirSenha);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops... Não conseguimos redefinir sua senha. Tente novamente. erro: {ex.Message}";
                return View("RedefinirSenha", redefinirSenha);
            }
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
                            _sessao.CriarSessaoDoUsuario(usuario);
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
