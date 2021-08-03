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
        public IContaRepository _ContaRepository { get; }

        public ContaController(IRepository repo, ITipoContaRepository tipoContaRepository, IContaRepository contaRepository )
        {
            _repo = repo;
            _TipoContaRepository = tipoContaRepository;
            _ContaRepository = contaRepository;

        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
             try {
                var result = await _ContaRepository.GetAll();

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
             try {
                var result = await _ContaRepository.GetByCpf(cpf);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

        [HttpGet("{conta}")]
        public async Task<IActionResult> GetByConta(string conta)
        {
             try {
                var result = await _ContaRepository.GetByConta(conta);

                return Ok(result);
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
        }

          [HttpGet("bla/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
             try {
                var result = await _ContaRepository.GetById(id);

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

                var hasTipoConta = _TipoContaRepository.GetTipoContaById(model.TipoContaID);

                if (hasTipoConta.Result == null) {
                    return Ok("Nosso caixa não faz operação com esse tipo de conta");
                }

                Random rand = new Random();
                int numero = rand.Next(1000, 9999);

                var numeroConta = numero + "-" + model.TipoContaID;
                model.Conta.NumeroDaConta = numeroConta;

                _repo.Add(model);

                if (await _repo.SaveChangesAsync()) {
                    return Ok("Conta criada com sucesso, o numero da sua nova conta é :  " + numeroConta);
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

                _repo.Update(model);

                if (await _repo.SaveChangesAsync()) {
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
            try {
               var conta = await _ContaRepository.GetById(id);

                if (conta == null) {
                return NotFound();
                }

                _repo.Delete(conta);

                if (await _repo.SaveChangesAsync()) {
                    return Ok("Exclusão realizada com sucesso");
                }
            } catch {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de conexão com banco de dados");
            }
             return BadRequest();
        }
    }
}