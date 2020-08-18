﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Repository;
using Service;
using Service.ViewModels;

namespace $rootnamespace$
{
    public class $safeitemname$ : ICqrsRequestWrapper<T>
    {
        
    }

public class $safeitemname$Handler : ICqrsRequestHandlerWrapper<$safeitemname$, T>
    {
    InvoicingContext _context;
IMapper _mapper;
public $safeitemname$Handler(InvoicingContext context, IMapper mapper)
{
    _context = context;
    _mapper = mapper;
}
public Task<CqrsResponse<T>> Handle($safeitemname$ request, CancellationToken cancellationToken)
{

    return Task.FromResult(CqrsResponse.QuerySuccess(T));
}
    }

}
