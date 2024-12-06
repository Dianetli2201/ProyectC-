using maintenance_calibration_system.DataAccess.Contexts;

namespace maintenance_calibration_system.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creando un contexto para interactuar con la base de datos
            ApplicationContext appContext = new ApplicationContext("Data Source=maintenance_calibration_systemDb.sqlite");
            //Verificando si la BD no existe
            if (!appContext.DataBase.CanConnect())
            {
                //Migrando base de datos. Este paso general la BD con las tablas configuradas en su migración
                appContext.DataBase.Migrate();
            }
        }
    }
}
