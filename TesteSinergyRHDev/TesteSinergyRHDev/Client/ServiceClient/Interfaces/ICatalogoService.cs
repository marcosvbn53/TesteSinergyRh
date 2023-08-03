using TesteSinergyRHDev.Shared.Dto;

namespace TesteSinergyRHDev.Client.ServiceClient.Interfaces
{
    public interface ICatalogoService
    {
        Task<List<ProdutoDto>> GetProdutos();
    }
}
