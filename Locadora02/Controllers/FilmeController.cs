using Locadora02.Data;
using Locadora02.Models;
using Microsoft.AspNetCore.Cors;
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

        #region FILME
        //Get Filme
        [EnableCors("Policy1")]
        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            List<Filme> filmes = _context.Filmes.ToList();
            if (filmes.Count == 0) return NotFound();
            return Ok(filmes);
        }

        //Get Filme Buscar Por Id
        [EnableCors("Policy1")]
        [HttpGet("{id}")]
        public IActionResult BuscaFilmesId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme is null) return NotFound();
            return Ok(filme);
        }

        //Post Filme
        [EnableCors("Policy1")]
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaFilmesId), new { id = filme.Id }, filme);

        }

        //Put Edita Filme
        [EnableCors("Policy1")]
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] Filme newfilme)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeEncontrado is null) return NotFound();

            filmeEncontrado.NomeFilme = newfilme.NomeFilme;
            filmeEncontrado.Sinopse = newfilme.Sinopse;
            filmeEncontrado.Duracao = newfilme.Duracao;
            filmeEncontrado.Diretor = newfilme.Diretor;
            filmeEncontrado.Imagem = newfilme.Imagem;
            filmeEncontrado.Genero = newfilme.Genero;

            _context.SaveChanges();

            return Ok();
        }

        //Delete Filme
        [EnableCors("Policy1")]
        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeEncontrado is null) return NotFound();
            _context.Remove(filmeEncontrado);
            _context.SaveChanges();
            return NoContent();

        }
        #endregion


        #region GENEROS
        //Get Genero
        [EnableCors("Policy1")]
        [HttpGet("VerGeneros")]
        public IEnumerable<Genero> RecuperaGeneros()
        {
            return _context.Generos;
        }

        //Get Genero Buscar Por Id
        [EnableCors("Policy1")]
        [HttpGet("BuscaGenerosId/{id}")]
        public IActionResult BuscaGenerosId(int id)
        {
            var genero = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (genero is null) return NotFound();
            return Ok(genero);
        }

        //Post Generos
        [EnableCors("Policy1")]
        [HttpPost("PostarGeneros")]
        public IActionResult AdicionaGenero([FromBody] Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaGenerosId), new { id = genero.Id }, genero);

        }


        //Put edita Genero
        [EnableCors("Policy1")]
        [HttpPut("EditaGeneroID/{id}")]
        public IActionResult AtualizaGenero(int id, [FromBody] Genero newgenero)
        {
            var generoEncontrado = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (generoEncontrado == null) return NotFound();

            generoEncontrado.Nome = newgenero.Nome;

            _context.SaveChanges();
            return NoContent();
        }


        //Delete Genero
        [EnableCors("Policy1")]
        [HttpDelete("DeleteGeneroId/{id}")]
        public IActionResult DeletaGenero(int id)
        {
            var generoEncontrado = _context.Generos.FirstOrDefault(genero => genero.Id == id);
            if (generoEncontrado == null) return NotFound();

            _context.Remove(generoEncontrado);
            _context.SaveChanges();

            return NoContent();
        }
        #endregion


    }
}
