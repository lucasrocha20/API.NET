using AutoMapper;
using FilmsAPI.Data;
using FilmsAPI.Data.Dtos;
using FilmsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private FilmContext _context;
        private IMapper _mapper;
        public FilmController(FilmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddFilm([FromBody] CreateFilmDto filmDto)
        {
            Film film = _mapper.Map<Film>(filmDto);

            _context.Films.Add(film);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmById), new { Id = film.Id }, film);
        }

        [HttpGet]
        public IActionResult getFilms()
        {
            return Ok(_context.Films);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilmById(int id)
        {
            Film film = _context.Films.FirstOrDefault(film => film.Id == id);

            if(film != null)
            {
                ReadFilmDto filmDto = _mapper.Map<ReadFilmDto>(film);

                return Ok(filmDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult PutFilm(int id, [FromBody] UpdateFilmDto filmDto)
        {
            Film film = _context.Films.FirstOrDefault(film => film.Id == id);

            if(film == null)
            {
                return NotFound();
            }

            _mapper.Map(filmDto, film);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilm(int id)
        {
            Film film = _context.Films.FirstOrDefault(film => film.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            _context.Remove(film);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
