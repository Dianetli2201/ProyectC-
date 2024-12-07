namespace maintenance_calibration_system.Domain.Datos_de_Configuracion
{
    public abstract class Equipment : Entity
    {
        #region Properties
        
        /// <summary>
        /// Código alfanumérico del equipo.
        /// </summary>
        public string? AlphanumericCode { get; set; }
        public PhysicalMagnitude Magnitude { get; set; } // Magnitud física asociada.
        public string? Manufacturer { get; set; } // Nombre del fabricante.
        
        #endregion

        // Constructor sin parámetros
        protected Equipment() 
        {
            Magnitude = new PhysicalMagnitude("DefaultName", "DefaultUnit");
        }

        protected Equipment(Guid id, string? alphanumericCode, PhysicalMagnitude magnitude, string? manufacturer)
        : base(id)// Constructor.
        {
            AlphanumericCode = alphanumericCode;
            Magnitude = magnitude;
            Manufacturer = manufacturer;
        }

    }
}