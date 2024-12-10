using maintenance_calibration_system.DataAccess.Contexts;

/// <summary>Utiliza genéricos para permitir que cualquier tipo de entidad (que sea una clase) pueda ser manejada por el repositorio.</summary>
public abstract class RepositoryBase<T> where T : class
{
    protected readonly ApplicationContext _context;

    /// <summary>El constructor recibe un contexto de aplicación (ApplicationContext), que se utiliza para interactuar con la base de datos.</summary>
    protected RepositoryBase(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>Añade una entidad al contexto y guarda los cambios.</summary>
    public void Add(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "La planificación no puede ser nula.");
        }
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    /// <summary>Busca una entidad por su identificador.</summary>
    public virtual T GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    /// <summary>Devuelve todas las entidades del tipo especificado.</summary>
    public virtual IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    /// <summary>Actualiza una entidad existente en el contexto y guarda los cambios.</summary>
    public virtual void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    /// <summary>Elimina una entidad por su identificador.</summary>
    public virtual void Delete(Guid id)
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
