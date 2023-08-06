using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "O título é um campo obrigatório!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O gênero é um campo obrigatório!")]
        [MaxLength(50, ErrorMessage = "O tamanho do título não pode ser superior a 50 caracteres")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "A duração do filme é um campo obrigatório!")]
        [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos!")]
        public int Duration { get; set; }

        [Required]
        public int Score { get; set; }
    }
}
