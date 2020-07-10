using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Service
{
    public interface ICqrsRequestWrapper<TIn, TOut> : IRequest<CqrsResponse<TIn, TOut>>
    {
    }

    public interface ICqrsRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, CqrsResponse<TIn, TOut>> where TIn: ICqrsRequestWrapper<TIn, TOut>
    {
    }


}
