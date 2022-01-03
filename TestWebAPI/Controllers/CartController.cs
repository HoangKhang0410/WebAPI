using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    public class CartController : ApiController
    {
        [Route("api/CartController/AddToCart")]
        [HttpGet]
        public IHttpActionResult AddToCart(int accountID, int pID)
        {
            try
            {
                DataTable productInfo = Database.Database.ReadTable($"select * from PRODUCT where ProductID = {pID}");

                DataTable item = Database.Database.ReadTable($"select * from CART where AccountID = {accountID}");
                if (item.Rows.Count > 0)
                {
                    // Co cart roi

                    string cartID = Database.Database.ReadTable($"select CartID from CART where AccountID = {accountID}").Rows[0].ItemArray[0].ToString();


                    // update lai tong tien khi them moi san pham
                    DataTable updateCart = Database.Database.ReadTable($"update CART set CartTotal = CartTotal + {productInfo.Rows[0].ItemArray[3].ToString()}");

                    // Sau khi bo vao cart thi kiem tra xem san pham da co trong gio chua

                    //DataTable checkCartDetail = Database.Database.ReadTable($"select * from CART_DETAIL where ProductID = {productInfo.Rows[0].ItemArray[0].ToString()} and CartID = {cartID}");
                    //if (checkCartDetail.Rows.Count > 0)
                    //{
                    //    // co roi thi update so luong
                    //    DataTable updateCartDetail = Database.Database.ReadTable($"update CART_DETAIL set ProductQuanity = {productInfo.Rows[0].ItemArray[2].ToString() + 1}");
                    //}
                    //else
                    //{
                    //    DataTable insert = Database.Database.ReadTable($"insert into CART_DETAIL values ({cartID}, {productInfo.Rows[0].ItemArray[0].ToString()}, 1)");
                    //}

                }
                else
                {

                    Database.Database.ReadTable($"insert into CART values ({accountID}, {productInfo.Rows[0].ItemArray[3]}, {DateTime.Now.ToString("dd/MM/yyyy")}");
                    DataTable result = Database.Database.ReadTable("select CartDate from CART where CartID = 1");
                    return Ok(result);

                    DataTable cart = Database.Database.ReadTable($"select CartID from CART where AccountID = {accountID}");
                    //object cartID = cart.Rows[0].ItemArray[0];

                    //DataTable insert = Database.Database.ReadTable($"insert into CART_DETAIL values ({cartID}, {productInfo.Rows[0].ItemArray[0].ToString()}, 1)");
                }
                return Ok(true);


            }
            catch (Exception)
            {

                return Ok(false);
            }
        }
    }
}
