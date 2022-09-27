using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefasMVC.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a senha atual!")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite a nova senha!")]
        public string NovaSenha { get; set; }
        [Compare("NovaSenha", ErrorMessage = "A nova senha e a confirmar senha devem ser iguais!")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
