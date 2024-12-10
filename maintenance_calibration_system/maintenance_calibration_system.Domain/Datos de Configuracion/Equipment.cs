using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.ValueObjects;
using System.Security.Cryptography.X509Certificates;

namespace maintenance_calibration_system.Domain.Datos_de_Configuracion
{
    public abstract class Equipment : Entity

    {
    #region Properties
    /// <summary>
    /// Codigo alfanumerico del equipo
    /// </summary>
    public string? AlphanumericCode { get; set; }
    public PhysicalMagnitude Magnitude { get; }//Magnitud fisica asociada
    public string? Manufacturer { get; set; } //Nombre de fabricante

    #endregion
    
    public Equipment() 
     { }

    protected Equipment (Guid id, string alphanumericCode, PhysicalMagnitude magnitude, string manufacturer)
        : base(id)// Constructor.
        {
            AlphanumericCode = alphanumericCode;
            Magnitude = magnitude;
            Manufacturer = manufacturer;
        }

    }

}
