using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Service
{
    public interface IServiceRequestWrapper<T> : IRequest<ServiceResponse<T>>
    {
    }

    public interface IServiceRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ServiceResponse<TOut>> where TIn : IServiceRequestWrapper<TOut>
    {
    }


}
