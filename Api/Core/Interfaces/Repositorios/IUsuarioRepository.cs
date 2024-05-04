using Core.Entidades;
namespace Core.Interfaces.Repositorios;
    public interface IUsuariosRepository : IBaseRepository<Usuario>{
        Task<Sesion> Login(string nombre);
       ValueTask<Usuario> GetName(string nombre);

    }
    
