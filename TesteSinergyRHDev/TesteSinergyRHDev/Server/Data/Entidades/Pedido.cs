using TesteSinergyRHDev.Server.Data.Entidades.Base;

namespace TesteSinergyRHDev.Server.Data.Entidades
{
    public class Pedido : EntidadeBase
    {
        public Guid ProdutoId { get; set; }        
        public decimal ValorCompra { get; set; }
        public decimal Troco { get; set; }
    }
}
