using ListaDeTarefasMVC.Models;

namespace ListaDeTarefasMVC.Repositorio
{
    public interface ILoginRepositorio
    {

        UsuarioModel BuscarPorLogin(string login);


    }
}
