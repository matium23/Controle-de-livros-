using CadastroLivros.Data1;
using CadastroLivros.Dto.AutorDto;
using CadastroLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroLivros.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly DataDbContext _dbContext;
        public AutorService(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<ResponseModel<List<AutorModel>>> ListarTodosAutores()
        {
            

            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _dbContext.Autor.ToListAsync();

                resposta.Dados = autor;
                resposta.Message = "Todos os Registros foram listados";
                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<AutorModel>> ListarAutorPorId(int IdAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _dbContext.Autor.FirstOrDefaultAsync(x => x.Id == IdAutor);
                if(autor == null)
                {
                    resposta.Message = "Registro Não encontrado";
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Message = "Registro Encontrado";
                return resposta;

            }
            catch(Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> ListarAutorPorIdLivro(int IdLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                /*O metodo Include entra na tabela livro atraves da propriedade de navegação Livros na tabela Autor, a partir dai e possivel pegar todos os livros registrados com ID do Autor*/
                var livro = await _dbContext.Livro.Include(x => x.Autor).FirstOrDefaultAsync(a => a.Id == IdLivro);
                
                if(livro == null)
                {
                    resposta.Message = "Registro não encontrado";
                    return resposta;
                }

                /*Como a variavel Resposta retorna um Autor, e preciso acessar a propriedade de navegação Autor da tabela Livros  */
                resposta.Dados = livro.Autor;
                resposta.Message = "Todos os Livros do Autor soliciatado encontrado";
                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }




        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(CriacaoAutorDto criacaoAutorDto)
        {
            ResponseModel<List<AutorModel>>resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = new AutorModel()
                {
                    Name = criacaoAutorDto.Name,
                    LastName = criacaoAutorDto.LastName,
                };
                

                _dbContext.Add(autor);
                await _dbContext.SaveChangesAsync();

                resposta.Dados = await _dbContext.Autor.ToListAsync();
                resposta.Message = "Registro criado com sucesso";
                return resposta;
                
            }
            catch(Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(EdicaoAutorDto edicaoAutorDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _dbContext.Autor.FirstOrDefaultAsync(x => x.Id == edicaoAutorDto.Id);
                if (autor == null)
                {
                    resposta.Message = "Registro não encontrado";
                    return resposta;
                }

                autor.Name = edicaoAutorDto.Name;
                autor.LastName = edicaoAutorDto.LastName;

                _dbContext.Update(autor);
                await _dbContext.SaveChangesAsync();

                resposta.Dados = await _dbContext.Autor.ToListAsync();
                resposta.Message = "Registro alterado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Message = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int id)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {
                var autor = await _dbContext.Autor.FirstOrDefaultAsync(x => x.Id == id);

                if(autor == null)
                {
                    resposta.Message = "Nenhum registro encontrado";
                    return resposta;
                }
                _dbContext.Remove(autor);
                await _dbContext.SaveChangesAsync();

                resposta.Dados = await _dbContext.Autor.ToListAsync();
                resposta.Message = "Registro removido com sucesso";
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

