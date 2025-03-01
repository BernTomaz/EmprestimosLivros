using System.ComponentModel.DataAnnotations;

namespace EmprestimosLivros.Models
{
    public class EmprestimosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O recebedor é obrigatório.")]
        public string Recebedor { get; set; }

        [Required(ErrorMessage = " O fornecedor é obrigatório.")]
        public string Fornecedor { get; set; }

        [Required(ErrorMessage = "O nome do livro é obrigatório.")]
        public string LivroEmprestado { get; set; }

        public DateTime DataEmprestimo { get; set; } = DateTime.Now;


    }
}



