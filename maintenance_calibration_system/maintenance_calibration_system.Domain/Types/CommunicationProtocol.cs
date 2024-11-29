using System; // Espacio de nombres fundamental.
using System.Collections.Generic; // Colecciones gen�ricas.
using System.Linq; // Consultas sobre colecciones.
using System.Text; // Manipulaci�n de cadenas.
using System.Threading.Tasks; // Programaci�n asincr�nica.

namespace maintenance_calibration_system.Domain.Types // Espacio de nombres para el sistema de mantenimiento y calibraci�n.
{
    public enum CommunicationProtocol // Enumeraci�n de protocolos de comunicaci�n.
    {
        ModBus, // Protocolo utilizado en automatizaci�n industrial.
        OPC, // Protocolo para interoperabilidad en automatizaci�n.
        UA, // OPC Unified Architecture, versi�n moderna del protocolo OPC.
        BACNet, // Protocolo para automatizaci�n de edificios y control HVAC.
    }
}