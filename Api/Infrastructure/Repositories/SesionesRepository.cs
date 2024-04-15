using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
     public class SesionesRepository: BaseRepository<Sesion>, ISesionRepository
    {
        public SesionesRepository(AppDbContext context) : base(context){}
    }
}