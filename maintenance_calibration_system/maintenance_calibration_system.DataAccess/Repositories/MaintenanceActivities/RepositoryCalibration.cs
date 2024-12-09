/*
using System; // Para tipos básicos como Guid y DateTime.
using System.Collections.Generic; // Para usar colecciones genéricas como IEnumerable y List.
using System.Linq; // Para utilizar métodos LINQ como ToList().
using Microsoft.EntityFrameworkCore; // Para usar métodos de Entity Framework como Include.
using maintenance_calibration_system.Domain.Datos_Historicos; // Para Calibration y MaintenanceActivity.
using maintenance_calibration_system.DataAccess.Contexts; // Para ApplicationContext.

namespace maintenance_calibration_system.Infrastructure.Repositories
{
    public class CalibrationRepository : MaintenanceActivityRepository<Calibration>
    {
        public CalibrationRepository(ApplicationContext context) : base(context)
        {
        }

        /// <summary>
        /// Obtiene todas las calibraciones con sus sensores calibrados.
        /// </summary>
        /// <returns>Una lista de calibraciones con sus sensores calibrados.</returns>
        public IEnumerable<Calibration> GetAllWithSensors()
        {
            return _context.Set<Calibration>()
                           .Include(c => c.CalibratedSensors) // Asegúrate de incluir los sensores calibrados.
                           .ToList();
        }

        /// <summary>
        /// Obtiene una calibración por su ID, incluyendo los sensores calibrados.
        /// </summary>
        /// <param name="id">El ID de la calibración.</param>
        /// <returns>La calibración correspondiente al ID, o null si no se encuentra.</returns>
        public Calibration GetByIdWithSensors(Guid id)
        {
            return _context.Set<Calibration>()
                           .Include(c => c.CalibratedSensors)
                           .FirstOrDefault(c => c.Id == id);
        }
    }
}
*/
using System;
using System.Collections.Generic;
using System.Linq;
using maintenance_calibration_system.Domain.Datos_Historicos;
using maintenance_calibration_system.Domain.Types; // Asegúrate de incluir este using si necesitas acceder a otros tipos relacionados
using maintenance_calibration_system.Domain.Common; // Incluye MaintenanceActivity

namespace maintenance_calibration_system.Data.Repositories
{
    public interface ICalibrationRepository
    {
        void Add(Calibration calibration);
        Calibration GetById(Guid id);
        IEnumerable<Calibration> GetAll();
        void Update(Calibration calibration);
        void Delete(Guid id);
    }

    public class CalibrationRepository : ICalibrationRepository
    {
        private readonly List<Calibration> _calibrations; // Simulando una base de datos en memoria

        public CalibrationRepository()
        {
            _calibrations = new List<Calibration>();
        }

        public void Add(Calibration calibration)
        {
            _calibrations.Add(calibration);
        }

        public Calibration GetById(Guid id)
        {
            return _calibrations.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Calibration> GetAll()
        {
            return _calibrations;
        }

        public void Update(Calibration calibration)
        {
            var existingCalibration = GetById(calibration.Id);
            if (existingCalibration != null)
            {
                existingCalibration.NameCertificateAuthority = calibration.NameCertificateAuthority;
                existingCalibration.CalibratedSensors = calibration.CalibratedSensors;
                // Actualizar otras propiedades según sea necesario
            }
        }

        public void Delete(Guid id)
        {
            var calibration = GetById(id);
            if (calibration != null)
            {
                _calibrations.Remove(calibration);
            }
        }
    }
}