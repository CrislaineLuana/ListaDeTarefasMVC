using ListaDeTarefasMVC.Models;
using ListaDeTarefasMVC.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefasMVC.Controllers
{
    public class TarefaController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        //Injeção de dependencias
        public TarefaController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }
        
        //Métodos Get
        public IActionResult Index()
        {
            List<TarefaModel> tarefas = _tarefaRepositorio.buscarTodos();
            return View(tarefas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.BuscarPorId(id);
            return View(tarefa);
        }

        public IActionResult ConfirmarExclusao(int id)
        {
            TarefaModel tarefa = _tarefaRepositorio.BuscarPorId(id);
            return PartialView("_ConfirmarExclusao",tarefa);
        }

        //Métodos Post
        
        [HttpPost]
        public IActionResult Criar(TarefaModel tarefaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tarefaModel.DataCriacao = DateTime.Now;
                    TarefaModel tarefa = _tarefaRepositorio.CriarTarefa(tarefaModel);
                    TempData["MensagemSucesso"] = $"Sua mensagem foi adicionada com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(tarefaModel);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar adicionar a sua tarefa. Detalha erro: {ex.Message}";
                return RedirectToAction("Index");
            }
            
        }


        [HttpPost]
        public IActionResult Editar(TarefaModel tarefaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _tarefaRepositorio.Editar(tarefaModel);
                    return RedirectToAction("Index");
                }

                return View(tarefaModel);

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao tentar editar a sua tarefa. Detalha erro: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
        
    }
}
