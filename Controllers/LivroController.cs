using CadastroLivros.Dto.AutorDto;
using CadastroLivros.Dto.LivroDto;
using CadastroLivros.Models;
using CadastroLivros.Services.Livro;
using Microsoft.AspNetCore.Mvc;

namespace CadastroLivros.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroInterface _repository;
        public LivroController(ILivroInterface repository)
        {
            _repository = repository;
        }

        [HttpGet("ListarTodosLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarTodosLivros()
        {
            var livro = await _repository.ListarTodosLivros();
            return Ok(livro);
        }


        [HttpGet("ListarLivroPorId/{IdAutord}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarAutorPorId(int IdAutor)
        {
            var livro = await _repository.ListarLivroPorId(IdAutor);
            return Ok(livro);
        }

        [HttpGet("ListarLivroPorIdAutor/{IdAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarAutorPorIdLivro(int IdLivro)
        {
            var livro = await _repository.ListarLivroPorIdAutor(IdLivro);
            return Ok(livro);
        }



        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarAutor(LivroCriacaoDto criacaoDto)
        {
            var livro = await _repository.CriarLivro(criacaoDto);
            return Ok(livro);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarAutor(LivroEdicaoDto edicaoDto)
        {
            var livro = await _repository.EditarLivro(edicaoDto);
            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int id)
        {
            var livro = await _repository.ExcluirLivro(id);
            return Ok(livro);
        }



    }
}
