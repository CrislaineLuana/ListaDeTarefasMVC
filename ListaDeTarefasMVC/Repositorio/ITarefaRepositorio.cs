using ListaDeTarefasMVC.Models;

namespace ListaDeTarefasMVC.Repositorio
{
    public interface ITarefaRepositorio
    {
        List<TarefaModel> buscarTodos();
        TarefaModel CriarTarefa(TarefaModel tarefa);
        TarefaModel BuscarPorId(int id);

        TarefaModel Editar(TarefaModel tarefa);
    }
}
