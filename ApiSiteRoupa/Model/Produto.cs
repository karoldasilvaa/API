namespace ApiSiteRoupa.Model
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public int IdCor { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
    }
}
