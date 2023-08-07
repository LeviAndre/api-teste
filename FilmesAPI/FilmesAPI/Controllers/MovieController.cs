using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IEnumerable<ReadMovieDTO> GetMovies([FromQuery]int skip = 0, [FromQuery] int take = 50)
        {
            return _mapper.Map<List<ReadMovieDTO>>(_db.Movies.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = _db.Movies.FirstOrDefault(el => el.ID == id);
            if (movie == null) return NotFound();

            var movieDto = _mapper.Map<ReadMovieDTO>(movie);
            return Ok(movieDto);

        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
        {
            var movie = _db.Movies.FirstOrDefault(el => el.ID == id);
            if (movie == null) return NotFound();

            _mapper.Map(movieDTO, movie);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchMovie(int id, JsonPatchDocument<UpdateMovieDTO> patch)
        {
            var movie = _db.Movies.FirstOrDefault(el => el.ID == id);
            if (movie == null) return NotFound();

            var moviePatch = _mapper.Map<UpdateMovieDTO>(movie);

            patch.ApplyTo(moviePatch, ModelState);

            if (!TryValidationModel(moviePatch)) return ValidationProblem();

            _mapper.Map(movieDTO, movie);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _db.Movies.FirstOrDefault(el => el.ID == id);
            if (movie == null) return NotFound();

            _db.Movies.Remove(movie);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
