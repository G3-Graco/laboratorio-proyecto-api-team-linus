using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class TipoMovimientoValidators : AbstractValidator<TipoMovimiento>
    {
        public TipoMovimientoValidators()
        {
            RuleFor(x => x.IDMovimiento)
                .MaximumLength(10)
                .WithMessage("El valor de la cédula de identidad esta mal, por favor volver a ingresar");

        }
    }
}