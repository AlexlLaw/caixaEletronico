using FluentValidation;
namespace caixaEletronico.DTO.Validators
{
    public class PesssoaValidator : AbstractValidator<PessoaDTO>
    {
        public PesssoaValidator()
        {
            RuleFor(m => m.Nome)
                .NotEmpty()
                    .WithMessage("Campo Obrigatorio")
                .MaximumLength(50)
                    .WithMessage("Nome só pode conter no maximo 50 caracteres")
                .MinimumLength(5)
                    .WithMessage("Nome tem que ser maior que 5 caracteres");

            
            RuleFor(m => m.Cpf)
                .NotEmpty()
                    .WithMessage("Campo Obrigatorio")
                .MaximumLength(11)
                    .WithMessage("CPF só pode conter no maximo 9 caracteres")
                .MinimumLength(11)
                    .WithMessage("CPF tem que ser maior que 5 caracteres");

            RuleFor(m => m.DataNascimento)
                .NotEmpty()
                    .WithMessage("Campo Obrigatorio");

             RuleFor(m => m.DataNascimento)
                .NotEmpty()
                    .WithMessage(" Campo Obrigatorio");

             RuleFor(m => m.TipoContaID)
                .NotEmpty()
                    .WithMessage("Campo Obrigatorio");

             RuleFor(m => m.Endereco.Cep)
                .NotEmpty()
                    .WithMessage("Campo Obrigatorio")
                .MaximumLength(8)
                    .WithMessage("Cep só pode conter no maximo 9 caracteres")
                .MinimumLength(8)
                    .WithMessage("Quantidade de caracteres invalida");

             RuleFor(m => m.Endereco.Logradouro)
               .NotEmpty()
                  .WithMessage("Logradouro não pode ser nulo");
            
            RuleFor(m => m.Endereco.Uf)
               .NotEmpty()
                  .WithMessage("Campo Obrigatorio");
                
        }
    }
}