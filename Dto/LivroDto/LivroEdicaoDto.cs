using CadastroLivros.Models;
using System.Text.Json.Serialization;

namespace CadastroLivros.Dto.LivroDto
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

       
        public AutorModel Autor { get; set; }
    }
}
