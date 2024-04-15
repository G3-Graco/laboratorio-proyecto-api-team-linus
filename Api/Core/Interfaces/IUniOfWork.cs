using Core.Interfaces.Repositorios;
namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }
        ICuentasRepository CuentasRepository {get;}
        ICuotasRepository CuotasRepository {get;}
        IMovimientosRepository MovimientosRepository {get;}
        IPrestamosRepository PrestamosRepository {get;}
        ITasasRepository TasasRepository {get;}
        ITipoMovimientoRepository TipoMovimientoRepository {get;}
        IArchivosRepository ArchivosRepository {get;}

        Task<int> CommitAsync();
    }