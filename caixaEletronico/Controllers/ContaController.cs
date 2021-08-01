using System;
using System.Threading.Tasks;
using caixaEletronico.data;
using caixaEletronico.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caixaEletronico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
       public IRepository _repo { get; }
       public ITipoContaRepository _TipoContaRepository { get; }

        public ContaController(IRepository repo, ITipoContaRepository tipoContaRepository )
        {
            _repo = repo;
            _TipoContaRepository = tipoContaRepository;
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
        public async Task<IActionResult> Post(Pessoa model)
        {
            try {

                var hasTipoConta = _TipoContaRepository.GetTipoContaById(model.TipoContaID);
                
                if (hasTipoConta.Result == null) {
                     return Ok("Nosso caixa não faz operação com esse tipo de conta");
                }
                
                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) {
                  Random rand = new Random();
                  int numero = rand.Next(1000, 9999);     

                  return Ok("Conta criada com sucesso, o numero da sua nova conta é :  " + numero  + "-" + model.TipoContaID);
                }
                
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
            
            return BadRequest();
        }

        private Random Random()
        {
            throw new NotImplementedException();
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