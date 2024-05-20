using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// está é uma classe Anêmica, pois não tem comportamento, apenas propriedades

namespace APICatalogoFinal.Models
{
    [Table("categorias")] //data annotation
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        [Key] //data annotation
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(80)] //data annotation
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)] //data annotation
        public string? ImagemUrl { get; set; }
        // propriedade de navegação (definindo o relacionamento "um para muitos"
        public ICollection<Produto>? Produtos { get; set; }
    }
}
