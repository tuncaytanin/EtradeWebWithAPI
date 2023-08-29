using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Caching;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Caching
{
    public class CacheRemoveAspect : MethodInterceptor
    {
        private readonly string _methodName;
        private readonly ICacheService _cacheService;
        public CacheRemoveAspect(string methodName)
        {
            _methodName = methodName;
            _cacheService = (ICacheService)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(ICacheService));
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheService.Remove($"Business.Abstract.{_methodName}()");
        }

    }
}
