using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CacheAsideDemo.Models;
using StackExchange.Redis;

namespace CacheAsideDemo.Data
{
    public class CacheAsideProductService : IProductService
    {
        private IProductService _underlyingService;
        private Cache _cache;

        public CacheAsideProductService( IProductService underlyingService, Cache cache )
        {
            _underlyingService = underlyingService;
            _cache = cache;
        }

        public Product Get( Guid id )
        {
            var cacheKey = String.Format( "Product_{0}", id );
            return _cache.GetFromCache<Product>( cacheKey, () => _underlyingService.Get( id ) );
        }

        public void Update( Guid id, Product product )
        {
            var cacheKey = String.Format( "Product_{0}", id );
            _underlyingService.Update( id, product );
            _cache.InvalidateCacheEntry( cacheKey );
        }
    }
}