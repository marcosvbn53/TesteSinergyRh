using TesteSinergyRHDev.Shared.Dto;

namespace TesteSinergyRHDev.Client.ServiceClient.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoDto> ComprarProduto(Guid idProduto, decimal valorCompra);
    }
}
