using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Usuario
    {
        public int IDUsuario { get; set; } 
		public string Nombre { get; set; }
		public string Contrasena { get; set; }
		public int CI { get; set; }
    }
}