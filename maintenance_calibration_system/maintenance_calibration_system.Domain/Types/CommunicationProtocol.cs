using System; // Espacio de nombres fundamental.
using System.Collections.Generic; // Colecciones genéricas.
using System.Linq; // Consultas sobre colecciones.
using System.Text; // Manipulación de cadenas.
using System.Threading.Tasks; // Programación asincrónica.

namespace maintenance_calibration_system.Domain.Types // Espacio de nombres para el sistema de mantenimiento y calibración.
{
    public enum CommunicationProtocol // Enumeración de protocolos de comunicación.
    {
        ModBus, // Protocolo utilizado en automatización industrial.
        OPC, // Protocolo para interoperabilidad en automatización.
        UA, // OPC Unified Architecture, versión moderna del protocolo OPC.
        BACNet, // Protocolo para automatización de edificios y control HVAC.
    }
}