using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CacheAsideDemo.Data
{
    public class Cache
    {
        private static ConnectionMultiplexer __connection;
        private static ConnectionMultiplexer Connection
        {
            get
            {
                return __connection ??
                    ( __connection = ConnectionMultiplexer.Connect( ConfigurationManager.AppSettings["RedisConnString"] ) );
            }
        }

        public T GetFromCache<T>( string key, Func<T> missCallback )
        {
            T value;
            var redis = Connection.GetDatabase();
            var serializedValue = redis.StringGet( key );

            if ( !serializedValue.IsNullOrEmpty ) // Hit!
            {
                value = JsonConvert.DeserializeObject<T>( serializedValue );
            }
            else // Miss - load from callback and store in cache with expiry time of 5 minutes
            {
                value = missCallback();
                redis.StringSet( key, JsonConvert.SerializeObject( value ), TimeSpan.FromMinutes( 5 ) );
            }
            return value;
        }

        public void InvalidateCacheEntry( string key )
        {
            var redis = Connection.GetDatabase();
            redis.KeyDelete( key );
        }
    }
}