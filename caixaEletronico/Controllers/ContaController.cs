using System.Threading.Tasks;
using caixaEletronico.model;
using caixaEletronico.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace caixaEletronico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        public IContaService _ContaService { get; }
        
        public ContaController(IContaService contaService)
        {
            _ContaService = contaService;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            try {
                var result = await _ContaService.GetAll();

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
             try {
                var result = await _ContaService.GetByCpf(cpf);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpGet("{conta}")]
        public async Task<IActionResult> GetByConta(string conta)
        {
             try {
                var result = await _ContaService.GetByConta(conta);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try {
                var result = await _ContaService.GetById(id);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pessoa model)
        {
            try
            {
                var hasTipoConta = _ContaService.GetTipoContaById(model.TipoContaID);

                if (hasTipoConta.Result == null) {
                    return Ok("Nosso caixa não faz operação com esse tipo de conta");
                }

                  _ContaService.AdicionarConta(model);

                if (await _ContaService.SaveChangesAsync()) {
                    return Created($"/api/conta/{model.PessoaId}", "Conta aberta com sucesso, Numero da sua conta é: " +  model.Conta.NumeroDaConta);
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Pessoa model)
        {
            try
            {
                var pessoa = await _ContaService.GetById(model.PessoaId);

                if (pessoa == null) {
                    return NotFound("Usuario não encontrado!");
                }

                _ContaService.UpdateConta(model);

                if (await _ContaService.SaveChangesAsync()) {
                    return Ok("Alteração realizada com sucesso");
                }
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pessoa = await _ContaService.GetById(id);

                if (pessoa == null) {
                    return Ok("Este usuario não encontrado");
                }
                _ContaService.DeleteConta(pessoa);

                if (await _ContaService.SaveChangesAsync()) {
                    return Ok("Exlusão realizada com sucesso");
                }
            }
            catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
            return BadRequest();
        }
    }
}