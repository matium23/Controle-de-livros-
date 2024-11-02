using CadastroLivros.Dto.AutorDto;
using CadastroLivros.Dto.LivroDto;
using CadastroLivros.Models;

namespace CadastroLivros.Services.Livro
{
    public interface ILivroInterface
    {
        public Task<ResponseModel<List<LivroModel>>> ListarTodosLivros();
        public Task<ResponseModel<LivroModel>> ListarLivroPorId(int IdLivros);
        public Task<ResponseModel<List<LivroModel>>> ListarLivroPorIdAutor(int IdAutor);


        public Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
        public Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);
        public Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
