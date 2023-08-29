using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Caching;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Caching
{
    public class CacheAspect:MethodInterceptor
    {
        private readonly int _duration;
        private readonly ICacheService _cacheService;
        public CacheAspect(int duration)
        {
            _duration = duration;
            _cacheService = (ICacheService)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(ICacheService)); 
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments;
            var key = $"{methodName}({string.Join(",",arguments.Select(x=>x?.ToString()??"<Null>"))})";

            if (_cacheService.IsAdd(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheService.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
