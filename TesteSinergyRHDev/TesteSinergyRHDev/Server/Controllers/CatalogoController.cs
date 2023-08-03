using Microsoft.AspNetCore.Mvc;
using TesteSinergyRHDev.Server.Base;
using TesteSinergyRHDev.Server.Data;
using TesteSinergyRHDev.Shared.Dto;

namespace TesteSinergyRHDev.Server.Controllers
{
    [ApiController]
    public class CatalogoController : MainController
    {
        private readonly CafeteiraGourmetContext _cafeteiraGourmetContext;
        public CatalogoController(CafeteiraGourmetContext cafeteiraGourmetContext)
        {
            _cafeteiraGourmetContext = cafeteiraGourmetContext;
        }

        [HttpGet]
        [Route("api/catalogo/produtos")]
        public IActionResult Get()
        {
            var produtosDisponiveis = _cafeteiraGourmetContext.Produtos.Select(px => new ProdutoDto
            {
                Id = px.Id,
                Descricao = px.Descricao,
                Valor = px.Valor
            }).ToList();

            return CustomResponse(produtosDisponiveis);
        }
    }
}
