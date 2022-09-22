using ListaDeTarefasMVC.Enums;
using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefasMVC.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Perfil!")]
        public PerfilUsuario Perfil { get; set; }

    }
}
