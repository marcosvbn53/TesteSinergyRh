using Microsoft.EntityFrameworkCore;
using TesteSinergyRHDev.Server.Data.Entidades;

namespace TesteSinergyRHDev.Server.Data
{
    public class CafeteiraGourmetContext : DbContext
    {
        public CafeteiraGourmetContext(DbContextOptions<CafeteiraGourmetContext> options)
            :base(options)
        {

        }


        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
