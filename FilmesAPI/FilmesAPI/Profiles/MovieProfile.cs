using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using AutoMapper;

namespace FilmesAPI.Profiles
{
    public class MovieProfile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDTO, Movie>();
        }
    }
}
