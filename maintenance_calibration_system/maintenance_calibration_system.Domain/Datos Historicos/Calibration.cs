using maintenance_calibration_system.Domain.Datos_de_Configuracion;


namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    /// <summary>Representa una calibraci�n en el sistema de mantenimiento y calibraci�n.</summary>
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
        /// <param name="id">Identificador �nico de la calibraci�n.</param>
        /// <param name="nameCertificateAuthority">Nombre de la autoridad certificadora.</param>
        /// <param name="dateActivity">Fecha de la actividad de calibraci�n.</param>
        /// <param name="nameTechnician">Nombre del t�cnico que realiz� la calibraci�n.</param>
        public Calibration(Guid id, string? nameCertificateAuthority, DateTime dateActivity, string? nameTechnician)
            : base(id, dateActivity, nameTechnician)
        {
            NameCertificateAuthority = nameCertificateAuthority;
            CalibratedSensors = new List<Sensor>();
        }
    }
}
