using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Abstract
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {

    }
}
