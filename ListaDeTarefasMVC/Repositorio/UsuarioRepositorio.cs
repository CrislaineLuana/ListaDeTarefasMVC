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

		public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
		{
            UsuarioModel usuarioDB = BuscarPorId(alterarSenhaModel.Id);
            if (usuarioDB == null) throw new Exception("Houve um erro na atualização da Senha");
            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere");
            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova senha deve ser diferente da senha atual");

            usuarioDB.alterarSenha(alterarSenhaModel.NovaSenha);

            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }

		public UsuarioModel BuscarPorId(int id)
        {
            if (id == 0) throw new Exception("Id nulo");

            UsuarioModel usuario = _bancoContext.Usuario.FirstOrDefault(x => x.Id == id);

            if (usuario == null) throw new Exception("Usuário nulo");


            return usuario;
        }

        public UsuarioModel BuscarPorLoginEEmail(string login, string email)
        {


            UsuarioModel usuario = _bancoContext.Usuario.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == x.Login.ToUpper()) ;


            return usuario;


        }

        public List<UsuarioModel> buscarTodos()
        {
            List<UsuarioModel> usuarios = _bancoContext.Usuario.ToList();
            return usuarios;
        }

        public UsuarioModel CriarUsuario(UsuarioModel usuario)
        {
            usuario.setSenhaHash();
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario; 
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuario = BuscarPorId(id);

            _bancoContext.Usuario.Remove(usuario);
            _bancoContext.SaveChanges();

            return true;
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
