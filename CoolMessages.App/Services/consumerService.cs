using System.Threading.Tasks;
using CoolMessages.App.Data;
using CoolMessages.App.Models;

namespace CoolMessages.App.Services
{
    public class ConsumerService : IConsumerService
    {
        public IRepository _repo { get; }
        public ITipoContaRepository _TipoContaRepository { get; }
        public IContaRepository _ContaRepository { get; }

        public Task<bool> SaveChangesAsync()
        {
            return _repo.SaveChangesAsync();
        }

        public 

        public ConsumerService(IRepository repo, ITipoContaRepository tipoContaRepository, IContaRepository contaRepository)
        {
            _repo = repo;
            _TipoContaRepository = tipoContaRepository;
            _ContaRepository = contaRepository;
        }

        public Transferecia MontarTransferencia(MessageInputModel model)
        {
          var transferecia = new Transferecia();

          transferecia.ContaId = model.ContaDebitadoId;
          transferecia.DataDeTransferencia = model.DataDeTransferencia;
          transferecia.Valor = model.Valor;
          transferecia.descricao = model.descricao;
          transferecia.ContaCreditadoId = model.ContaCreditadoId;

          return transferecia;
        }

        public void addTransferencia(MessageInputModel model)
        {
          var dadosTransferencia = this.MontarTransferencia(model);
            
           _repo.Add(dadosTransferencia);
        }
    }
}



