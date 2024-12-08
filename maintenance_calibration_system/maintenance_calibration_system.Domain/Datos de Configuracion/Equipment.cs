using maintenance_calibration_system.Domain.Common;
using maintenance_calibration_system.Domain.ValueObjects;
using System.Security.Cryptography.X509Certificates;

namespace maintenance_calibration_system.Domain.ValueObjects;

    public abstract class Equipment : Entity

    {
    
        public PhysicalMagnitude Magnitude { get; }
        public string AlphanumericCode { get; set; }
         
        public string Manufacturer { get; set; }
     
    

        protected Equipment(Guid id, string? alphanumericCode, PhysicalMagnitude magnitude, string? manufacturer)
        : base(id)// Constructor.
        {
            AlphanumericCode = alphanumericCode;
            Magnitude = magnitude;
            Manufacturer = manufacturer;
        }

    }


