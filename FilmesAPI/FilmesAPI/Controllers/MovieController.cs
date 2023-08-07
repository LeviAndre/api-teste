using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _db;
        private IMapper _mapper;

        public MovieController(MovieContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult postMovie([FromBody] CreateMovieDTO movieDTO) {
            Movie movie = _mapper.Map<Movie>(movieDTO);
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.ID }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies([FromQuery]int skip = 0, [FromQuery] int take = 50)
        {
            return _db.Movies.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _db.Movies.FirstOrDefault(el => el.ID == id);
            if (movie == null) return NotFound();
            return Ok(movie);

        }
    }
}
