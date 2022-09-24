using ListaDeTarefasMVC.Enums;
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
            return Senha == senha;
        }
    }
}
