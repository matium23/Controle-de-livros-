using CadastroLivros.Data1;
using CadastroLivros.Dto.LivroDto;
using CadastroLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly DataDbContext _context;
        public LivroService(DataDbContext context)
        {
            _context = context;

        }

        public async Task<ResponseModel<List<LivroModel>>> ListarTodosLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livro.ToListAsync();

                resposta.Dados = livro;
                resposta.Message = "Todos os livros listados com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<LivroModel>> ListarLivroPorId(int IdLivros)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(x => x.Id == IdLivros);

                if (livro == null)
                {
                    resposta.Message = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Message = "livro listado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivroPorIdAutor(int IdAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livro.Include(x => x.Autor)
                    .Where(x => x.Autor.Id == IdAutor).ToListAsync();

                if (livro == null)
                {
                    resposta.Message = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Message = "livro listado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }






        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {

                /*Passa os valores de autor atravez da Propriedade de navegação*/
                var autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == livroCriacaoDto.Autor.Id);
                

                
                if (autor == null) 
                {
                    resposta.Message = "Nenhum autor encontrado para esse registro";
                    return resposta;
                }



                /*Cria o livro Adicionando os valores vindo do parametro e o autor que foi verificado*/
                var livro = new LivroModel()
                {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor
                };


                _context.Add(livro);
                await _context.SaveChangesAsync();


                /*Retorna uma lista com todos os livros*/
                resposta.Dados = await _context.Livro.ToListAsync();
                resposta.Message = "Registro adicionado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
           ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livro.Include(x => x.Autor).
                    FirstOrDefaultAsync(x => x.Id == livroEdicaoDto.Id);

                if (livro == null)
                {
                    resposta.Message = "Nenhum registro encontrado";
                    return resposta;
                }

                var autor = await _context.Autor.FirstOrDefaultAsync(x => x.Id == livroEdicaoDto.Autor.Id);
                if(autor == null)
                {
                    resposta.Message = "Nenhum autor encontrado para esse registro";
                    return resposta;
                }


                
                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = autor;


                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livro.ToListAsync();
                resposta.Message = "Livro atualizado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>>resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(x => x.Id == idLivro);
                if (livro == null)
                {
                    resposta.Message = "Nenhum registro encontrado";
                    return resposta;    
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livro.ToListAsync();
                resposta.Message = "Registro excluido com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }


    }
}
