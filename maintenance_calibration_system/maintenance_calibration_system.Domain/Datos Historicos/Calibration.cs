using maintenance_calibration_system.Domain.Datos_de_Configuracion;


namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    /// <summary>Representa una calibración en el sistema de mantenimiento y calibración.</summary>
    public class Calibration : MaintenanceActivity
    {
        #region Properties
        /// <summary>Nombre de la autoridad certificadora.</summary>
        public string? NameCertificateAuthority { get; set; }

        /// <summary>Lista de sensores calibrados.</summary>
        public List<Sensor>? CalibratedSensors { get; set; }
        #endregion

        /// <summary>Constructor por defecto.</summary>
        public Calibration() { }

        /// <summary>Constructor para crear una instancia de Calibration.</summary>
        /// <param name="id">Identificador único de la calibración.</param>
        /// <param name="nameCertificateAuthority">Nombre de la autoridad certificadora.</param>
        /// <param name="dateActivity">Fecha de la actividad de calibración.</param>
        /// <param name="nameTechnician">Nombre del técnico que realizó la calibración.</param>
        public Calibration(Guid id, string? nameCertificateAuthority, DateTime dateActivity, string? nameTechnician)
            : base(id, dateActivity, nameTechnician)
        {
            NameCertificateAuthority = nameCertificateAuthority;
            CalibratedSensors = new List<Sensor>();
        }
    }
}
