using ListaDeTarefasMVC.Enums;
using ListaDeTarefasMVC.Helper;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefasMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a Senha!")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Selecione o Perfil!")]
        public PerfilUsuario Perfil { get; set; }


        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void setSenhaHash()
        {
           Senha = Senha.GerarHash();
        }


        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();

            return novaSenha;
        }
    }
}
