namespace CadastroLivros.Dto.AutorDto
{
    public class CriacaoAutorDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}


/*
 * O atributos necessari para criação sao somente Nome e Sobrenome pois o Id e posto atravez do BD
    e o autor e postao quanto e instanciado o Livro
 */