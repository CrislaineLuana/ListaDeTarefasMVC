using ListaDeTarefasMVC.Models;
using ListaDeTarefasMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefasMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.buscarTodos();
            return View(usuarios);
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario =  _usuarioRepositorio.BuscarPorId(id);
            return View(usuario);
        }


        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {

                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Perfil = usuarioSemSenhaModel.Perfil,
                        Email = usuarioSemSenhaModel.Email
                    };


                    usuario = _usuarioRepositorio.Editar(usuario);
                    TempData["MensagemSucesso"] = $"Seu usuário foi editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
                
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar editar o seu usuário. Detalhe erro: {ex.Message}";
                return RedirectToAction("Index");
            }


        }
    }
}
