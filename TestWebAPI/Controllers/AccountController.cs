using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestWebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/TestController/GetAccountWithID")]
        [HttpGet]
        public IHttpActionResult GetAccountWithID(int id)
        {
            try
            {
                DataTable result = Database.Database.ReadTable("select * from ACCOUNT where AccountID = " + id);
                return Ok(result);
            }
            catch
            {



                return NotFound();
            }
        }

        [Route("api/TestController/hello")]
        [HttpGet]
        public IHttpActionResult hello()
        {
            return Ok("thanh coong");
        }
        //[Route("api/TestController/GetAccounts")]
        //[HttpGet]
        //public IHttpActionResult AddUser()
        //{
        //    try
        //    {
        //        Database.Database data = new Database.Database();
        //        data.ExecuteQuery("select * from ACCOUNT");
        //        return Ok(data);
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
