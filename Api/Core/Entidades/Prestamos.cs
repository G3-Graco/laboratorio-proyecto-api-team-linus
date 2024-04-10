using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Prestamos
    {
        public int IdPrestamos {get;set;}
        public int IdCuotas {get;set;}
        public int IdTasas {get;set;}
        public int IdCuentas {get;set;}
        public int IdArchivos {get;set;}
        public  DateTime  FechaDeOperacion {get; set;}
        public double Sueldo {get;set;}
        public double Monto {get;set;}
    }
}