using ListaDeTarefasMVC.Data;
using ListaDeTarefasMVC.Models;

namespace ListaDeTarefasMVC.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private readonly BancoDbContext _bancoDbContext; 

        public LoginRepositorio(BancoDbContext bancoDbContext)
        {
                _bancoDbContext = bancoDbContext;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            UsuarioModel usuario = _bancoDbContext.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
            return usuario;

        }
    }
}
