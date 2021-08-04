using System;
using System.Threading.Tasks;
using caixaEletronico.data;
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

          [HttpGet("bla/{id}")]
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
        public IActionResult Post(Pessoa model)
        {
            try
            {
                var result = _ContaService.AdicionarConta(model);

                return Ok(result);
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Pessoa model)
        {
            try
            {
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
        public IActionResult Delete(int id)
        {
            try
            {
                _ContaService.DeleteConta(id);
            }
            catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
            return BadRequest();
        }
    }
}