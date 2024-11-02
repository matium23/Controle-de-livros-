using CadastroLivros.Models;
using System.Text.Json.Serialization;

namespace CadastroLivros.Dto.LivroDto
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }

        
        public AutorModel Autor { get; set; }
    }
}
