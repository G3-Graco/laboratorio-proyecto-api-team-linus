using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class UsuarioValidators : AbstractValidator<Usuario>
    {
        public UsuarioValidators()
        {
            RuleFor(x => x.CI)
                .MaximumLength(8)
                .WithMessage("El valor de la cédula de iidentidad esta mal, por favor volver a ingresar");

        }
    }
}