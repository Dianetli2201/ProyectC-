using maintenance_calibration_system.Domain.Datos_de_Configuracion;


namespace maintenance_calibration_system.Domain.Datos_Historicos
{
    public class Calibration : MaintenanceActivity
    {
        #region Properties
            public string? NameCertificateAuthority { get; set; }      // Nombre de la autoridad certificadora
            public List<Sensor>? CalibratedSensors { get; set; }       // Lista de sensores calibrados

        #endregion

        public Calibration() { }

        public Calibration(Guid id, string? nameCertificateAuthority, DateTime dateActivity, string? nameTechnician)
            : base(id, dateActivity, nameTechnician) // Llama al constructor base.
        {
            NameCertificateAuthority = nameCertificateAuthority;   // Asignar nombre de la autoridad certificadora
            CalibratedSensors = new List<Sensor>();                // Inicializar lista de sensores calibrados
        }

    }
}