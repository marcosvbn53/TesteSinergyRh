using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteSinergyRHDev.Server.Migrations
{
    /// <inheritdoc />
    public partial class SedProdutosBasicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                   table: "Produtos",
                   columns: new[] {"Id", "Descricao", "Valor", "DataCriacao" },
               values: new object[,]
               {
                    { Guid.NewGuid(),"Cappuccino", 3.5m, DateTime.Now },
                    { Guid.NewGuid(),"Café com Leite", 3.0m, DateTime.Now },
                    { Guid.NewGuid(),"Mocha", 4.00m, DateTime.Now }                    
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
