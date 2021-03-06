﻿using CacheAsideDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CacheAsideDemo.Data
{
    public interface IProductService
    {
        Product Get( Guid id );
        void Update( Guid id, Product product );
    }

    public class ProductService : IProductService
    {
        public Product Get( Guid id )
        {
            var product = SampleData.Products.SingleOrDefault( p => p.ProductId == id );
            if ( product == null )
            {
                throw new ProductNotFoundException( String.Format( "Could not find product with id '{0}'", id ) );
            }
            return product;
        }

        public void Update( Guid id, Product product )
        {
            var existingProduct = Get( id );
            existingProduct.Description = product.Description;
            existingProduct.UnitPrice = product.UnitPrice;
        }
    }

    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException() { }
        public ProductNotFoundException( string message ) : base( message ) { }
        public ProductNotFoundException( string message, Exception inner ) : base( message, inner ) { }
    }
}