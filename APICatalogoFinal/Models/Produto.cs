namespace APICatalogoFinal.Models;

// está é uma classe Anêmica, pois não tem comportamento, apenas propriedades
public class Produto
{
    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    public int CategoriaId { get; set; } // essa propriedade mapeia para a chave estrangeira no banco
    public Categoria? Categoria { get; set; }// propriedade de navegação, que indica que um Prduto está relcionado com uma Categoria
}