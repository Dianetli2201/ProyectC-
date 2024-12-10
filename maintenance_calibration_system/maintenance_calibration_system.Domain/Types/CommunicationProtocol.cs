

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