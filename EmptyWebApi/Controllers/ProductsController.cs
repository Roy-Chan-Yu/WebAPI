using EmptyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace EmptyWebApi.Controllers
{
    // Default /api/
    public class ProductsController : ApiController
    {
        static Product[] products = new Product[]
        {
             new Product { ID = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1},
             new Product { ID = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M},
             new Product { ID = 3, Name = "Hammer", Category = "Handware", Price = 16.99M},

        };

        //public HttpResponseMessage Get()
        //{
        //    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
        //    response.Content = new StringContent("Hello", Encoding.UTF8);
        //    response.Headers.CacheControl = new CacheControlHeaderValue()
        //    {
        //        MaxAge = TimeSpan.FromMinutes(20)
        //    };

        //    return response;
        //}

        // Default /products
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        // Default /products/id
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.First(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [ActionName("thumbnail")]
        public IHttpActionResult ProductsList(int id)
        {
            var product = products.FirstOrDefault(p => p.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [Route("products/find/{id:int:nonzero}")] // ignore the /api/{controller} routes
        [HttpGet]
        public IEnumerable<Product> FindProduct(int id)
        {
            return products.Where(p => p.ID == id).ToList();
        }

    }

}