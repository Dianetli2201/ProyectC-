using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maintenance_calibration_system.Application.Abstract
{
    public interface IQueryHandler<TQuery, TResponse>
        : IRequestHandler<TQuery, TResponse>
        where TQuery : IRequest<TResponse>
    {

    }
}
