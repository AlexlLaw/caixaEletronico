using FluentValidation;

namespace caixaEletronico.DTO.Validators
{
    public class EnderecoValidator : AbstractValidator<EnderecoDTO>
    {
        public EnderecoValidator()
        {
             RuleFor(m => m.Cep)
                .NotEmpty()
                    .WithMessage("Campo Obrigatorio")
                .MaximumLength(9)
                    .WithMessage("Cep só pode conter no maximo 9 caracteres")
                .MinimumLength(9)
                    .WithMessage("Quantidade de caracteres invalida");

            RuleFor(m => m.Logradouro)
               .NotEmpty()
                  .WithMessage("Logradouro não pode ser nulo");
            
            RuleFor(m => m.Uf)
               .NotEmpty()
                  .WithMessage("Campo Obrigatorio");
        }
    }
}