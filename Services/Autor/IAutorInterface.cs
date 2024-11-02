using CadastroLivros.Dto.AutorDto;
using CadastroLivros.Models;

namespace CadastroLivros.Services.Autor
{
    public interface IAutorInterface
    {
        public Task<ResponseModel<List<AutorModel>>> ListarTodosAutores();
        public Task<ResponseModel<AutorModel>> ListarAutorPorId(int IdAutor);
        public Task<ResponseModel<AutorModel>> ListarAutorPorIdLivro(int IdLivro);


        public Task<ResponseModel<List<AutorModel>>> CriarAutor(CriacaoAutorDto criacaoAutorDto);
        public Task<ResponseModel<List<AutorModel>>> EditarAutor(EdicaoAutorDto edicaoAutorDto);
        public Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int id);
    }
}
