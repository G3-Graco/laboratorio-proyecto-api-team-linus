using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class TasasValidators : AbstractValidator<Tasas>
    {
        public TasasValidators()
        {
            RuleFor(x => x.IDTasa)
                .MaximumLength(30)
                .WithMessage("El valor de la Tasa esta mal, por favor volver a ingresar");

        }
    }
}