using Microsoft.AspNetCore.Mvc;

namespace caixaEletronico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        public ContaController()
        {
            
        }
    
        [HttpGet]
        public IActionResult get()
        {
            return Ok();
        }

         [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

         [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

         [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

         [HttpDelete("{id}")]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}