using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        [Route("api/ProductController/GetProductWithID")][HttpGet]
        public IHttpActionResult GetProductWithID(int id)
        {
            try
            {
                DataTable result = Database.Database.ReadTable("select * from PRODUCT where ProductID = " + id);
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
        [Route("api/ProductController/GetAllProducts")][HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            try
            {
                DataTable result = Database.Database.ReadTable("select * from PRODUCT");
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
