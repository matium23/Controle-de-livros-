using CadastroLivros.Dto.AutorDto;
using CadastroLivros.Models;
using CadastroLivros.Services.Autor;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CadastroLivros.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorInterface _AutorRepository;

        public AutorController(IAutorInterface livroRepository)
        {
            _AutorRepository = livroRepository;
        }


        /*Para que nao de erro na hora de implementar os metodos e preciso colocalos dentro do metodo (ActionResult) e retornar um (OK)*/



        [HttpGet("ListarTodosAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarTodosLivros()
        {
            var autor = await _AutorRepository.ListarTodosAutores();
            return Ok(autor);
        }


        [HttpGet("ListarAutorPorId/{IdAutord}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ListarAutorPorId(int IdAutor)
        {
            var autor = await _AutorRepository.ListarAutorPorId(IdAutor);
            return Ok(autor);
        }

        [HttpGet("ListarAutorPorIdLivro/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ListarAutorPorIdLivro(int IdLivro)
        {
            var autor = await _AutorRepository.ListarAutorPorIdLivro(IdLivro);
            return Ok(autor);
        }



        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(CriacaoAutorDto criacaoAutorDto)
        {
            var autor = await _AutorRepository.CriarAutor(criacaoAutorDto);
            return Ok(autor);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(EdicaoAutorDto edicaoAutorDto)
        {
            var autor = await _AutorRepository.EditarAutor(edicaoAutorDto);
            return Ok(autor);
        }

        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int id)
        {
            var autor = await _AutorRepository.ExcluirAutor(id);
            return Ok(autor);
        }

    }
}
