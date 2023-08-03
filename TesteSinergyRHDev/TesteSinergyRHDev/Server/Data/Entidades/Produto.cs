using TesteSinergyRHDev.Server.Data.Entidades.Base;

namespace TesteSinergyRHDev.Server.Data.Entidades
{
    public class Produto : EntidadeBase
    {
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
