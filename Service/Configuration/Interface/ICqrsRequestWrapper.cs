using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Service
{
    public interface ICqrsRequestWrapper<TResult> : IRequest<CqrsResponse<TResult>>
    {
    }

    public interface ICqrsRequestHandlerWrapper<TRequest, TResult> : IRequestHandler<TRequest, CqrsResponse<TResult>> where TRequest : ICqrsRequestWrapper<TResult>
    {
    }


}
