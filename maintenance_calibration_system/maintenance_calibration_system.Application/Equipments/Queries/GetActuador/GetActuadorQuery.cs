using maintenance_calibration_system.Domain.Datos_de_Configuracion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Equipments.Queries.GetActuador
{
    public record GetActuadorByIdQuery(Guid Id) : IRequest<Actuador>;
}
