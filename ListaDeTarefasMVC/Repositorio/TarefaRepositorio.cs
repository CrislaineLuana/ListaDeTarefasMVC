using ListaDeTarefasMVC.Data;
using ListaDeTarefasMVC.Models;

namespace ListaDeTarefasMVC.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly BancoDbContext _dbContext;
        public TarefaRepositorio(BancoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TarefaModel BuscarPorId(int id)
        {      
           TarefaModel tarefa =  _dbContext.Tarefas.FirstOrDefault(x => x.Id == id);
           return tarefa;
        }

        public List<TarefaModel> buscarTodos()
        {
            return _dbContext.Tarefas.ToList();                
        }

        public TarefaModel CriarTarefa(TarefaModel tarefa)
        {
            _dbContext.Tarefas.Add(tarefa);
            _dbContext.SaveChanges();

            return tarefa;
        }

        public bool Deletar(TarefaModel tarefa)
        {
            _dbContext.Tarefas.Remove(tarefa);
            _dbContext.SaveChanges();
            return true;
        }

        public TarefaModel Editar(TarefaModel tarefa)
        {
            TarefaModel tarefaBD = BuscarPorId(tarefa.Id);

            tarefaBD.DataAlteracao = DateTime.Now;
            tarefaBD.Tarefa = tarefa.Tarefa;

            _dbContext.Tarefas.Update(tarefaBD);
            _dbContext.SaveChanges();

            return tarefa;
        }
    }
}
