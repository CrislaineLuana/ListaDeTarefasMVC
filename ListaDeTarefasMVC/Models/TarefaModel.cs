using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefasMVC.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Digite a sua tarefa!")]
        public string Tarefa { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; } 


    }
}
