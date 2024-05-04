using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class CancelacionPrestamo
    {
        public int IDCancelacion { get; set; }
		public Int64 IDCuenta { get; set; }
		public virtual Cuentas? Cuenta { get; set; }
		public int IDtasa { get; set; }
		public virtual Tasas? Tasa { get; set; }

    }
}