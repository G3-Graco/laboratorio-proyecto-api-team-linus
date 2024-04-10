using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Movimientos
    {
        public int IdMovimiento {get;set;}
        public  int  IdTipo {get; set;}
        public  string?  IdCuenta {get; set;}
        public  DateTime  Date {get; set;}
        public  double  Monto {get; set;}
    }
}