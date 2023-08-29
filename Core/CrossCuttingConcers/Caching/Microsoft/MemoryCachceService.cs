using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcers.Caching.Microsoft
{
    public class MemoryCachceService : ICacheService
    {
        IMemoryCache _memoryCache;
        public MemoryCachceService()
        {
            _memoryCache = (IMemoryCache)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(IMemoryCache));
        }
        public void Add(string key, object data, int duration)
        {
             _memoryCache.Set(key, data, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);   
        }

        public bool IsAdd(string key)
        {
          return _memoryCache.TryGetValue(key, out var value);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
