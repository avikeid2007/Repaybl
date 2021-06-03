using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepayblApi.Models;
using System;

namespace RepayblApi.Core
{
    public class RepayblController : ControllerBase
    {
        protected string baseUrl;
        protected IMapper mapper;

        protected RepayblController(RepayblContext context)
        {
            Context = context;
        }

        protected RepayblContext Context { get; private set; }

        protected void Dispose()
        {
            Context?.Dispose();
            Context = null;
        }

        protected IMapper GetMapper()
        {
            baseUrl = Request.Scheme + "://" + Request.Host + Request.PathBase;
            return RepaybMapper.GetMapper(baseUrl);
        }

        protected T ConvertModels<T, T2>(T2 t2)
        {
            if (mapper == null)
            {
                mapper = GetMapper();
            }
            return mapper.Map<T>(t2);
        }

        protected void MapModels<T, T2>(T source, T2 destination)
        {
            (mapper ??= GetMapper()).Map(source, destination);
        }

        protected static void MapCreated<T>(T obj) where T : AuditorBase
        {
            if (obj != null)
            {
                obj.Created = DateTimeOffset.Now;
            }
        }

        protected static void MapModified<T>(T obj) where T : AuditorBase
        {
            if (obj != null)
            {
                obj.Modified = DateTimeOffset.Now;
            }
        }
    }
}
