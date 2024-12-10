

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