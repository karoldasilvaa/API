using ApiSiteRoupa.BancoDados;
using ApiSiteRoupa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSiteRoupa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public List<Produto> Listar()
        {
            ProdutoDal produtodal = new ProdutoDal();
            List<Produto> produtos = produtodal.Listar();
            return produtos;
        }

        [HttpPost]
        public string Salvar(Produto produto)
        {
            ProdutoDal produtodal = new ProdutoDal();
            return produtodal.Salvar(produto);

        }

        [HttpDelete]
        public string Excluir(int id)
        {
            ProdutoDal produtodal = new ProdutoDal();
            return produtodal.Excluir(id);
        }

        [HttpPut]
        public string Atualizar(Produto produto)
        {
            ProdutoDal produtodal = new ProdutoDal();
            return produtodal.Atualizar(produto);
        }
    }
}
