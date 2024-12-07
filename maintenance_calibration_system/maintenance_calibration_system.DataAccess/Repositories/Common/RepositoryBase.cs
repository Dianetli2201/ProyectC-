using System.Net.Mime;
public abstract class RepositoryBase<T> where T : class // utiliza genéricos para permitir que cualquier tipo de entidad (que sea una clase) pueda ser manejada por el repositorio.
{
    protected readonly ApplicationContext _context;

    protected RepositoryBase(ApplicationContext context) //El constructor recibe un contexto de aplicación (ApplicationContext), que se utiliza para interactuar con la base de datos.
    {
        _context = context;
    }

    public virtual void Add(T entity) //Agrega una nueva entidad al contexto y guarda los cambios.
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public virtual T GetById(Guid id)//Busca una entidad por su identificador.
    {
        return _context.Set<T>().Find(id);
    }

    public virtual IEnumerable<T> GetAll()//Devuelve todas las entidades del tipo especificado.
    {
        return _context.Set<T>().ToList();
    }

    public virtual void Update(T entity)//Actualiza una entidad existente en el contexto y guarda los cambios.
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public virtual void Delete(Guid id)//Elimina una entidad por su identificador.
    {
        var entity = GetById(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}