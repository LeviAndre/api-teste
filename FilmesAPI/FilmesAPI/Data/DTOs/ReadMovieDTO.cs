using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class ReadMovieDTO
    {
        public string Title { get; set; }

        public string Gender { get; set; }

        public int Duration { get; set; }

        public int Score { get; set; }

        public DateTime getDate { get; set; } = DateTime.Now;
    }
}
