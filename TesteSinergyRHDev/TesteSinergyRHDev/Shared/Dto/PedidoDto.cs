using TesteSinergyRHDev.Shared.Enum;

namespace TesteSinergyRHDev.Shared.Dto
{
    public class PedidoDto
    {
        public Guid ProdutoId { get; set; }
        public string? DescricaoProduto { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal Troco { get; set; }
        public decimal? Valorfaltante { get; set; } = 0;
        public StatusTransacao SituacaoPedido { get; set; } = StatusTransacao.SemDefinicao;
    }
}
