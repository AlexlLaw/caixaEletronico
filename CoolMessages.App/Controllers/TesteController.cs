using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CoolMessages.App.Services;

namespace CoolMessages.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : Controller
    {
        public IConsumerService _ContaService { get; }
        
        public TesteController(IConsumerService contaService)
        {
            _ContaService = contaService;
        }

       [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try {
                var result = await _ContaService.GetContaById(id);
                

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }
    }
}