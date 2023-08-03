using TesteSinergyRHDev.Client.ServiceClient.Base;
using TesteSinergyRHDev.Client.ServiceClient.Interfaces;
using TesteSinergyRHDev.Shared.Dto;

namespace TesteSinergyRHDev.Client.ServiceClient
{
    public class PedidoService : BaseService, IPedidoService
    {
        public PedidoService(HttpClient httpClient)
            : base(httpClient) { }


        public async Task<PedidoDto> ComprarProduto(Guid idProduto, decimal valorCompra)
        {
            var pedidoCompra = new PedidoDto { ProdutoId = idProduto, ValorCompra = valorCompra };
            var content = ObterConteudo(pedidoCompra);            
            var response = await httpCliente.PostAsync("api/pedido/ComprarProduto", content);   

            TratarErrosResponse(response);
            return await DeserializarObjeto<PedidoDto>(response);            
        }
    }
}
