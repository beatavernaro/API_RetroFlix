using Locadora02.Data;
using Locadora02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Locadora02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        
        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        //Post Filme
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaFilmesId), new { id = filme.Id }, filme);

        }


        //Post Generos
        [HttpPost("PostarGeneros")]
        public IActionResult AdicionaGenero([FromBody] Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaGenerosId), new { id = genero.Id }, genero);
            
        }


        //Get Filme
        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes() //IEnymerable enumerados de numeros
        {
            return _context.Filmes;
        }


        //Get Genero
        [HttpGet("VerGeneros")]
        public IEnumerable<Genero> RecuperaGeneros()
        {
            return _context.Generos;
        }


        //Get Filme Buscar Por Id
        [HttpGet("{id}")]
        public IActionResult BuscaFilmesId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }


        //Get Genero Buscar Por Id
        [HttpGet("BuscaGenerosId {id}")]
        public IActionResult BuscaGenerosId(int id)
        {
            var genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (genero == null) return NotFound();
            return Ok(genero);
        }


        //Put Edita Filme
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] Filme newfilme)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeEncontrado == null) return NotFound();

            filmeEncontrado.NomeFilme = newfilme.NomeFilme;
            filmeEncontrado.Sinopse = newfilme.Sinopse;
            filmeEncontrado.Duracao = newfilme.Duracao;
            filmeEncontrado.Diretor = newfilme.Diretor;
            filmeEncontrado.Imagem = newfilme.Imagem; 
            //filmeEncontrado.Genero = newfilme.Genero;

            _context.SaveChanges();

            return NoContent();
        }


        //Put edita Genero
        [HttpPut("EditaGeneroID {id}")]
        public IActionResult AtualizaGenero(int id, [FromBody] Genero newgenero)
        {
            var generoEncontrado = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (generoEncontrado == null) return NotFound();

            generoEncontrado.Nome = newgenero.Nome;

            _context.SaveChanges();
            return NoContent();
        } 


        //Delete Filme
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id, [FromBody] Filme delfilme)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeEncontrado == null) return NotFound();
            _context.Remove(filmeEncontrado);
            _context.SaveChanges();
            return NoContent();
            
        }


        //Delete Genero
        [HttpDelete("DeleteGeneroId {id}")]
        public IActionResult DeletaGenero(int id, [FromBody] Genero delgenero)
        {
            var generoEncontrado = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (generoEncontrado == null) return NotFound();
            _context.Remove(generoEncontrado);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
