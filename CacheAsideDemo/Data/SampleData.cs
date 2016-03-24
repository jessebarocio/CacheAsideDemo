using CacheAsideDemo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CacheAsideDemo.Data
{
    public class SampleData
    {
        private static string sampleDataPath = HttpContext.Current.Server.MapPath( "~/SampleData.json" );

        private static IEnumerable<Product> _products;
        public static IEnumerable<Product> Products
        {
            get
            {
                return _products ?? (
                    _products = JsonConvert.DeserializeObject<IEnumerable<Product>>( File.ReadAllText( sampleDataPath ) ) );
            }
        }
    }
}