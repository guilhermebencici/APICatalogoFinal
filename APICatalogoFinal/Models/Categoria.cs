using System.Collections.ObjectModel;

// está é uma classe Anêmica, pois não tem comportamento, apenas propriedades

namespace APICatalogoFinal.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
        // propriedade de navegação (definindo o relacionamento "um para muitos"
        public ICollection<Produto>? Produtos { get; set; }
    }
}
