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

        public async Task<Pessoa[]> GetAll()
        {
            return await  _ContaRepository.GetAll();
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

        public void AdicionarConta(Pessoa model)
        {
            Random rand = new Random();
            int numero = rand.Next(1000, 9999);

            var numeroConta = numero + "-" + model.TipoContaID;
            model.Conta.NumeroDaConta = numeroConta;

            _repo.Add(model);
        }

        public void UpdateConta(Pessoa model)
        {
            _repo.Update(model);
        }

        public void DeleteConta(Pessoa model) 
        {
            _repo.Delete(model);
        }

        public Task<Conta> GetContaById(int id)
        {
            return _ContaRepository.GetContaById(id);
        }
    }
}