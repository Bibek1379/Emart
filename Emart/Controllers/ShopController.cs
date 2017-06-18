using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emart.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop/{username}
        public ActionResult Index(string id)
        {
            string VendorUsername = id;


            return View();
        }

       
    }
}