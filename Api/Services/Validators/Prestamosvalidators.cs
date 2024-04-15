using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class PrestamosValidators : AbstractValidator<Prestamos>
    {
        public PrestamosValidators()
        {
            RuleFor(x => x.IDPrestamo)
                .MaximumLength(30)
                .WithMessage("El valor del prestamo esta mal, por favor volver a ingresar");

        }
    }
}