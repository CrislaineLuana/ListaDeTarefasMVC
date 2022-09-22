using ListaDeTarefasMVC.Data;
using ListaDeTarefasMVC.Models;

namespace ListaDeTarefasMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoDbContext _bancoContext;
        public UsuarioRepositorio(BancoDbContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            if (id == 0) throw new Exception("Id nulo");

            UsuarioModel usuario = _bancoContext.Usuario.FirstOrDefault(x => x.Id == id);

            if (usuario == null) throw new Exception("Usuário nulo");


            return usuario;
        }

        public List<UsuarioModel> buscarTodos()
        {
            List<UsuarioModel> usuarios = _bancoContext.Usuario.ToList();
            return usuarios;
        }

        public UsuarioModel CriarUsuario(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public bool Deletar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

            usuarioDB.Login = usuario.Login;
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;

            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }
    }
}
