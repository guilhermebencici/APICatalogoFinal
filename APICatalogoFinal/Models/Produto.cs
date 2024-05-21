using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogoFinal.Models;

// está é uma classe Anêmica, pois não tem comportamento, apenas propriedades
[Table("produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }
    [Required]
    [StringLength(80)] //data annotation
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)] //data annotation
    public string? Descricao { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2")] //data annotation
    public decimal Preco { get; set; }
    [Required]
    [StringLength(300)] //data annotation
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    [JsonIgnore] // com o JsonIgnore, essa propriedade vai ser ignorada na serialização
    public int CategoriaId { get; set; } // essa propriedade mapeia para a chave estrangeira no banco
    public Categoria? Categoria { get; set; }// propriedade de navegação, que indica que um Prduto está relcionado com uma Categoria
}