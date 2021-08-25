using System;
using System.Threading.Tasks;
using caixaEletronico.data;
using caixaEletronico.DTO;
using caixaEletronico.model;
using Microsoft.AspNetCore.Mvc;

namespace caixaEletronico.services
{
    public class ContaService : IContaService
    {
        public IRepository _repo { get; }
        public ITipoContaRepository _TipoContaRepository { get; }
        public IContaRepository _ContaRepository { get; }

        public ContaService(IRepository repo, ITipoContaRepository tipoContaRepository, IContaRepository contaRepository)
        {
            _repo = repo;
            _TipoContaRepository = tipoContaRepository;
            _ContaRepository = contaRepository;
        }

        public async Task<Pessoa[]> GetAll()
        {
            return await _ContaRepository.GetAll();
        }

        public Task<Pessoa> GetByCpf(string cpf)
        {
            return _ContaRepository.GetByCpf(cpf);
        }

        public Task<Pessoa> GetByConta(string conta)
        {
            return _ContaRepository.GetByConta(conta);
        }
        public Task<Pessoa> GetById(int id)
        {
            return _ContaRepository.GetById(id);
        }

        public Task<TipoConta> GetTipoContaById(int id)
        {
            return _TipoContaRepository.GetTipoContaById(id);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _repo.SaveChangesAsync();
        }
        public void UpdateConta(Pessoa model)
        {
            _repo.Update(model);
        }

        public void DeleteConta(Pessoa model)
        {
            _repo.Delete(model);
        }

        public async Task<Conta> GetContaById(int id)
        {
            return await _ContaRepository.GetContaById(id);
        }

        public Pessoa AdicionarConta(PessoaDTO model)
        {
           var result = this.mountPessoa(model);

            _repo.Add(result);

            return result;
        }

        // public void AdicionarConta(Pessoa model)
        // {
        //     Random rand = new Random();
        //     int numero = rand.Next(1000, 9999);

        //     var numeroConta = numero + "-" + model.TipoContaID;
        //     // model.Conta.NumeroDaConta = numeroConta;
        //     // model.Conta.Saldo = 30;
        //     // model.Conta.isAtivo = false;
        //     var newConta = new Conta();
        //     newConta.NumeroDaConta = numeroConta;
        //     newConta.Saldo = 20;
        //     newConta.isAtivo = true;
        //     model.Conta = newConta;

        //     _repo.Add(model);
        // }

        public bool VerifySaldo(string NumeroDaConta, decimal valorDaTransferencia)
        {
            var result = _ContaRepository.GetByConta(NumeroDaConta);

            var saldoAtual = result.Result.Conta.Saldo;

            if (saldoAtual <= 0 || saldoAtual < valorDaTransferencia) {
                return true;
            }

            return false;
        }

        public Pessoa mountPessoa(PessoaDTO PessoaDTO)
        {
            var pessoa = new Pessoa();

            //Entidade Pessoa;
            pessoa.Nome = PessoaDTO.Nome; 
            pessoa.Cpf = PessoaDTO.Cpf; 
            pessoa.DataNascimento = PessoaDTO.DataNascimento;
            pessoa.Idade = PessoaDTO.Idade; 
            pessoa.TipoContaID = PessoaDTO.TipoContaID;

            //Entidade Endereco;
            var newEndereco = new Endereco();
            newEndereco.Cep = PessoaDTO.Endereco.Cep;
            newEndereco.Logradouro = PessoaDTO.Endereco.Logradouro;
            newEndereco.Localidade = PessoaDTO.Endereco.Localidade;
            newEndereco.Uf = PessoaDTO.Endereco.Uf;
            newEndereco.Complemento = PessoaDTO.Endereco.Complemento;
            pessoa.Endereco = newEndereco;

            //calculo
            Random rand = new Random();
            int numero = rand.Next(1000, 9999);

            var numeroConta = numero + "-" + PessoaDTO.TipoContaID;

            var newConta = new Conta();
            newConta.NumeroDaConta = numeroConta;
            newConta.Saldo = 20;
            newConta.isAtivo = true;
            pessoa.Conta = newConta;

            return pessoa;
        }
    }
}