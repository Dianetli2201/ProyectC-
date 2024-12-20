using maintenance_calibration_system.Domain.Datos_Historicos; 
using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion;

public interface IMaintenanceActivityRepository<T> where T : MaintenanceActivity
{
    /// <summary>Añade una nueva entidad al repositorio.</summary>
    /// <param name="maintenance">La entidad a añadir.</param>
    void Add(Maintenance maintenance);

    /// <summary>Busca una entidad por su identificador único.</summary>
    /// <param name="id">El identificador único de la entidad.</param>
    /// <returns>La entidad correspondiente al identificador, o null si no se encuentra.</returns>
    T GetById(Guid id);

    /// <summary>Devuelve todas las entidades del tipo especificado.</summary>
    /// <returns>Una colección de todas las entidades.</returns>
    IEnumerable<Maintenance> GetAll();

    /// <summary>Actualiza una entidad existente en el repositorio.</summary>
    /// <param name="maintenance">La entidad a actualizar.</param>
    void Update(Maintenance maintenance);

    /// <summary>Elimina una entidad del repositorio por su identificador único.</summary>
    /// <param name="id">El identificador único de la entidad a eliminar.</param>
    void Delete(Guid id);
}

namespace maintenance_calibration_system.DataAccess.Respositories.MaintenanceActivitiy
{
    /// <summary>Repositorio para manejar entidades de tipo MaintenanceActivity.</summary>
    public class MaintenanceActivityRepository<T> : RepositoryBase<T> where T : MaintenanceActivity
    {
        /// <summary>Constructor que inicializa el repositorio con el contexto de la aplicación.</summary>
        /// <param name="context">El contexto de la aplicación.</param>
        public MaintenanceActivityRepository(ApplicationContext context) : base(context)
        {

        }

    }
}
