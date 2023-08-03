using TesteSinergyRHDev.Client.ServiceClient.Base;
using TesteSinergyRHDev.Client.ServiceClient.Interfaces;
using TesteSinergyRHDev.Shared.Dto;

namespace TesteSinergyRHDev.Client.ServiceClient
{
    public class CatalogoService : BaseService, ICatalogoService
    {
        public CatalogoService(HttpClient httpClient)
            : base(httpClient) { }


        public async Task<List<ProdutoDto>> GetProdutos()
        {
            var response = await httpCliente.GetAsync("api/catalogo/produtos");

            TratarErrosResponse(response);

            return await DeserializarObjeto<List<ProdutoDto>>(response);
        }
    }
}
