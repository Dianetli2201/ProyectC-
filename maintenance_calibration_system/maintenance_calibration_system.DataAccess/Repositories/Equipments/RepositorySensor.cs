
using System; //Para tipos básicos como Guid.
using System.Collections.Generic; //Para usar colecciones genéricas como IEnumerable.
using System.Linq; //Para utilizar métodos LINQ como ToList().
using maintenance_calibration_system.Domain.Datos_de_Configuración; // Para Sensor e IRepositorioSensor
using maintenance_calibration_system.DataAccess.Contexts;// Para ApplicationContext
using maintenance_calibration_system.Domain.Types;
using maintenance_calibration_system.Domain.ValueObjects;
using System.Text;
using System.Threading.Tasks;
using maintenance_calibration_system.Domain.Common;


namespace maintenance_calibration_system.Infrastructure.Repositories
{
     public interface ISensorRepository
    {
        void Add(Sensor sensor);
        Sensor GetById(Guid id);
        IEnumerable<Sensor> GetAll();
        void Update(Sensor sensor);
        void Delete(Guid id);
    }
    public class SensorRepository : ISensorRepository
    {
        private readonly ApplicationContext _context;

        public SensorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Sensor sensor)
        {
            _context.Set<Sensor>().Add(sensor);
            _context.SaveChanges();
        }

        public Sensor GetById(Guid id)
        {
            return _context.Set<Sensor>().Find(id);
        }

        public IEnumerable<Sensor> GetAll()
        {
            return _context.Set<Sensor>().ToList();
        }

        public void Update(Sensor sensor)
        {
            _context.Set<Sensor>().Update(sensor);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var sensor = GetById(id);
            if (sensor != null)
            {
                _context.Set<Sensor>().Remove(sensor);
                _context.SaveChanges();
            }
        }
    }
}
/*Métodos CRUD:
Add: Agrega un nuevo Sensor al contexto y guarda los cambios.
GetById: Busca un Sensor por su identificador.
GetAll: Devuelve todos los Sensor del tipo especificado.
Update: Actualiza un Sensor existente en el contexto y guarda los cambios.
Delete: Elimina un Sensor por su identificador.
*/




/* RepositorySensor que hereda de RepositoryEquipment
using System; // Para tipos básicos como Guid.
using System.Collections.Generic; // Para usar colecciones genéricas como IEnumerable.
using System.Linq; // Para utilizar métodos LINQ como ToList().
using maintenance_calibration_system.Domain.Datos_de_Configuracion; // Para Sensor e ISensorRepository
using maintenance_calibration_system.Infrastructure; // Para ApplicationContext

namespace maintenance_calibration_system.Infrastructure.Repositories
{
    public class SensorRepository : EquipmentRepository<Sensor>, ISensorRepository
    {
        public SensorRepository(ApplicationContext context) : base(context)
        {
        
        }

        Los métodos CRUD se heredan de EquipmentRepository<T>, por lo que no es necesario redefinirlos aquí.
    }
}
*/


