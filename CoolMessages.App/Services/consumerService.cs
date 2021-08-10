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

        public ConsumerService(IRepository repo, ITipoContaRepository tipoContaRepository, IContaRepository contaRepository)
        {
            _repo = repo;
            _TipoContaRepository = tipoContaRepository;
            _ContaRepository = contaRepository;
        }

        public Transferecia MontarTransferencia(MessageInputModel model)
        {
          var contaDebitante = _ContaRepository.GetContaById(model.ContaDebitadoId);
          var transferecia = new Transferecia();

          transferecia.ContaCreditadoId = model.ContaCreditadoId;
          transferecia.DataDeTransferencia = model.DataDeTransferencia;
          transferecia.Valor = model.Valor;
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