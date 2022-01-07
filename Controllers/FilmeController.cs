using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult create([FromBody] FilmeDTO filmeDTO) {

        Filme filme = _mapper.Map<Filme>(filmeDTO);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(getById), new { Id = filme.Id }, filme);
    }

    [HttpGet]
    public IActionResult getAll() {
        return Ok(_context.Filmes);
    }

    [HttpGet("{id}")]
    public IActionResult getById(int id) {
        Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme != null) {
            return Ok(filme);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult update(int id, [FromBody] FilmeDTO filmeDTO) {
        Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) {
            return NotFound();
        }
        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult delete(int id) {
        Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if(filme == null) {
            return NotFound();
        }
        _context.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}
