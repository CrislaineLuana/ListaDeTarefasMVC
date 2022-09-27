using ListaDeTarefasMVC.Models;

namespace ListaDeTarefasMVC.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> buscarTodos();
        UsuarioModel CriarUsuario(UsuarioModel usuario);
        UsuarioModel BuscarPorId(int id);
        bool Deletar(int id);
        UsuarioModel Editar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        UsuarioModel BuscarPorLoginEEmail(string login, string email);

    }
}
