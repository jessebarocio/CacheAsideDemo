using CacheAsideDemo.Data;
using CacheAsideDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CacheAsideDemo.Controllers
{
    [RoutePrefix( "api/products" )]
    public class ProductController : ApiController
    {
        //IProductService _service = new ProductService(); // No Caching
        IProductService _service = new CacheAsideProductService( new ProductService(), new Cache() );

        [HttpGet, Route( "{id:guid}" )]
        public Product Get( Guid id )
        {
            return _service.Get( id );
        }

        [HttpPut, Route( "{id:guid}" )]
        public Product Update( Guid id, Product product )
        {
            _service.Update( id, product );
            return product;
        }
    }
}
