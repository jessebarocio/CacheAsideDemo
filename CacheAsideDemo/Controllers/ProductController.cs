﻿using CacheAsideDemo.Data;
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
        IProductService _service = new ProductService();

        [HttpGet, Route( "{id:guid}" )]
        public Product Get( Guid id )
        {
            return _service.Get( id );
        }
    }
}