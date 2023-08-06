using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();

        [HttpPost]
        public void postMovie([FromBody] Movie movie) {
            movies.Add(movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies([FromQuery]int skip = 0, [FromQuery] int take = 50)
        {
            return movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public Movie? GetMovie(int id)
        {
            return movies.FirstOrDefault(el => el.ID == id);
        }
    }
}
