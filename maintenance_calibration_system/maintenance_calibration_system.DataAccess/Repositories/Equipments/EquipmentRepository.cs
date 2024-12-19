using maintenance_calibration_system.DataAccess.Contexts;
using maintenance_calibration_system.Domain.Datos_de_Configuracion; // Para ApplicationContext

public interface IEquipment<T> where T : class
{
    /// <summary>A�ade una nueva entidad al repositorio.</summary>
    /// <param name="equipment">La entidad a a�adir.</param>
    void Add(Equipment equipment);

    /// <summary>Busca una entidad por su identificador �nico.</summary>
    /// <param name="id">El identificador �nico de la entidad.</param>
    /// <returns>La entidad correspondiente al identificador, o null si no se encuentra.</returns>
    T GetById(Guid id);

    /// <summary>Devuelve todas las entidades del tipo especificado.</summary>
    /// <returns>Una colecci�n de todas las entidades.</returns>
    IEnumerable<Equipment> GetAll();

    /// <summary>Actualiza una entidad existente en el repositorio.</summary>
    /// <param name="equipment">La entidad a actualizar.</param>
    void Update(Equipment equipment);

    /// <summary>Elimina una entidad del repositorio por su identificador �nico.</summary>
    /// <param name="id">El identificador �nico de la entidad a eliminar.</param>
    void Delete(Guid id);
}

namespace maintenance_calibration_system.DataAccess.Respositories.Equipments
{
    /// <summary>Repositorio para manejar entidades de tipo Equipment.</summary>
    public class EquipmentRepository<T> : RepositoryBase<T> where T : Equipment
    {
        /// <summary>Constructor que inicializa el repositorio con el contexto de la aplicaci�n.</summary>
        /// <param name="context">El contexto de la aplicaci�n.</param>
        public EquipmentRepository(ApplicationContext context) : base(context)
        {
        }
        
    }
}
    

