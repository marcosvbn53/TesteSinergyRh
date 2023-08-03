using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteSinergyRHDev.Server.Base;
using TesteSinergyRHDev.Server.Data;
using TesteSinergyRHDev.Server.Data.Entidades;
using TesteSinergyRHDev.Shared.Dto;

namespace TesteSinergyRHDev.Server.Controllers
{
    public class PedidoController : MainController
    {
        private readonly CafeteiraGourmetContext _cafeteiraGourmetContext;

        public PedidoController(CafeteiraGourmetContext cafeteiraGourmetContext)
        {
            _cafeteiraGourmetContext = cafeteiraGourmetContext;
        }

        [HttpPost]
        [Route("api/pedido/ComprarProduto")]
        public async Task<IActionResult> Post([FromBody] PedidoDto pedidoCompra)
        {
            var produtoEncontrado = await _cafeteiraGourmetContext.Produtos.FirstOrDefaultAsync(px => px.Id == pedidoCompra.ProdutoId);
            if (pedidoCompra.ValorCompra >= produtoEncontrado?.Valor)
            {
                pedidoCompra.Troco = pedidoCompra.ValorCompra - produtoEncontrado.Valor;

                pedidoCompra.SituacaoPedido = Shared.Enum.StatusTransacao.Pago;
                if (pedidoCompra.Troco > 0)
                    pedidoCompra.SituacaoPedido = Shared.Enum.StatusTransacao.PagoContemTroco;
            }
            return CustomResponse(pedidoCompra);
        }
    }
}
