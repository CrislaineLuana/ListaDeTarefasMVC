using ListaDeTarefasMVC.Models;

namespace ListaDeTarefasMVC.Repositorio
{
    public interface ITarefaRepositorio
    {
        List<TarefaModel> buscarTodos();
        TarefaModel CriarTarefa(TarefaModel tarefa);
        TarefaModel BuscarPorId(int id);
        bool Deletar(TarefaModel tarefa);
        TarefaModel Editar(TarefaModel tarefa);
    }
}
