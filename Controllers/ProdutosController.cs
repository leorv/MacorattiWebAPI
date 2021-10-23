using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPI.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        static readonly IProdutoRepositorio repositorio = new ProdutoRepositorio();

        [HttpGet]
        public IEnumerable<Produto> GetTodos()
        {
            return repositorio.GetAll();
        }

        [HttpGet("id", Name = "GetProduto")]
        public IActionResult GetProdutoPorId(int id)
        {
            Produto produto = repositorio.Get(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto); // Pode tbm new ObjectResult(produto);
        }

        [HttpPost]
        public IActionResult CriarProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            produto = repositorio.Add(produto);

            return CreatedAtRoute("GetProduto", new { id = produto.Id }, produto);
        }

        [HttpPut]
        public IActionResult AtualizaProduto (int id, [FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            produto.Id = id;

            if (!repositorio.Update(produto))
            {
                return NotFound();
            }

            return new NoContentResult(); // 204
        }

        [HttpDelete]
        public IActionResult DeletaProduto(int id)
        {
            Produto produto = repositorio.Get(id);

            if (produto == null)
            {
                return BadRequest();
            }

            repositorio.Remove(id);

            return new NoContentResult();
        }

    }
}
