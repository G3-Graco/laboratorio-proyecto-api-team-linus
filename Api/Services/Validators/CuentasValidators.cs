using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class CuentaValidators : AbstractValidator<Cuentas>
    {
        public UsuarioValidators()
        {
            RuleFor(x => x.IDCuenta)
                .Length(12)
               
        }
    }
}