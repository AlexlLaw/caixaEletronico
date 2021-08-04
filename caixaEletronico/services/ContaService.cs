using System;
using System.Threading.Tasks;
using caixaEletronico.data;
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

        public Task<Pessoa[]> GetAll()
        {
           var result =  _ContaRepository.GetAll();
            return result;
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

        public string AdicionarConta(Pessoa model)
        {
            var hasTipoConta = this.GetTipoContaById(model.TipoContaID);

            if (hasTipoConta.Result == null) {
                return "Nosso caixa não faz operação com esse tipo de conta";
            }

            Random rand = new Random();
            int numero = rand.Next(1000, 9999);

            var numeroConta = numero + "-" + model.TipoContaID;
            model.Conta.NumeroDaConta = numeroConta;

            _repo.Add(model);
            this.SaveChangesAsync();
            return "Conta criada com sucesso, o numero da sua nova conta é :  " + numeroConta;
        }

        public void UpdateConta(Pessoa model)
        {
            _repo.Update(model);
        }

        public string DeleteConta(int id) 
        {
            var conta = this.GetById(id);

            if (conta == null) {
                return "Conta não encontrada";
            }

            _repo.Delete(conta);

            this.SaveChangesAsync();

            return "Exclusão realizada com sucesso";
        }
    }
}