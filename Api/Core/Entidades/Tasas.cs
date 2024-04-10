using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Tasas
    {
        public int IdTasas {get;set;}
        public  int  IdTipo {get; set;}
        public  string?  IdCuenta {get; set;}
        public  DateTime  Date {get; set;}
        public  double  Monto {get; set;}
    }
}