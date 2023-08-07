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
        public IActionResult postMovie([FromBody] Movie movie) {
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.ID }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies([FromQuery]int skip = 0, [FromQuery] int take = 50)
        {
            return movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = movies.FirstOrDefault(el => el.ID == id);
            if (movie == null) return NotFound();
            return Ok(movie);

        }
    }
}
