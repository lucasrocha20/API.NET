using AutoMapper;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAPI.Profiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<CreateFilmDto, Film>();
            CreateMap<UpdateFilmDto, Film>();
            CreateMap<Film, ReadFilmDto>();
        }
    }
}
