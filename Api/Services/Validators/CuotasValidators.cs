using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class CuotasValidators : AbstractValidator<Cuotas>
    {
        public CuotasValidators()
        {
            RuleFor(x => x.IDCuota)
                .MaximumLength(10);

        }
    }
}