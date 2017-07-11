using Emart.Models;
using Emart.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Emart.Controllers
{
    public class ShopController : Controller
    {
        TemplateContext db = new TemplateContext();
        //Template TemplateData { get; set; }
        // GET: Shop/{username}
        public Template Tname(Vendor VendorData)
        {
            try
            {
                var TemplateData = db.Template.SqlQuery("Select * from Templates where TemplateId = @p0", VendorData.TemplateId).FirstOrDefault();
                return TemplateData;
            }
            catch (Exception)
            {

                return null;
            }
            ;
        }
        public ActionResult Index(string id)
        {
            string VendorUsername = id;
            var VendorData = db.Vendor.SqlQuery("Select * from Vendors where Username = @p0", VendorUsername).SingleOrDefault();

            // var TemplateData = db.Template.SqlQuery("Select * from Templates where TemplateId = @p0", VendorData.TemplateId).FirstOrDefault();

            var TemplateData = Tname(VendorData);
            Session["myname"] = VendorData.VendorId;

            var output = db.Database.SqlQuery<Eshopper>(" Select * from " + TemplateData.TemplateName + " where VendorId = @p0 ", VendorData.VendorId).SingleOrDefault();
           
            EshopperViewModel mytheme = new EshopperViewModel();
            mytheme.Output = output;
            mytheme.Template = TemplateData;
            var path = Path.Combine(@"~/Views/shop", TemplateData.TemplateName, "index.cshtml");

           // TempData["tname"] = TemplateData;
            return View(path, mytheme);
           // Create(TemplateData);


        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Vendor detail)
        {
            try
            {
                List<object> lst = new List<object>();
                lst.Add(detail.UserName);
                lst.Add(detail.FullName);
                lst.Add("1");
                object[] Vendor = lst.ToArray();
                int result = db.Database.ExecuteSqlCommand("INSERT into vendors(UserName,FullName,TemplateId) VALUES (@p0,@p1,@p2)", Vendor);
                if (result > 0)
                {
                    ViewBag.msg = "added";
                }
                
                Session["UserName"] = detail.UserName.ToString();
                
                
                return RedirectToAction("choosetemplate");
            }
            catch 
            {
                return View();

            }

            
        }

        public ActionResult choosetemplate()
        {
            if (Session["Username"] != null)
            {
                
                var TemplateList = db.Template.SqlQuery("SELECT * from Templates").ToList();
                return View(TemplateList);
            }
            return HttpNotFound();
            
        }

        [HttpGet]
        public ActionResult selecttemplate(string id)
        {
            if (Session["Username"] != null)
            {
                string User_Name = Session["Username"].ToString();           
                List<object> parameters = new List<object>();
                parameters.Add(id);
                parameters.Add(User_Name);
                object[] objectarray = parameters.ToArray();
                int result = db.Database.ExecuteSqlCommand("UPDATE vendors set TemplateId=@p0 where UserName=@p1", objectarray);


                var User = db.Vendor.SqlQuery("SELECT * from Vendors where UserName = @p0", User_Name).SingleOrDefault();
                
                Session["UserId"] = User.VendorId.ToString();
                

                Customize(User.VendorId);
                
            }
            return HttpNotFound();

        }

        public ActionResult Customize(int id)
        {
            var User = db.Vendor.SqlQuery("SELECT * from Vendors where VendorId = @p0", id).SingleOrDefault();
            var TemplateData = Tname(User);
            string TemplateName = TemplateData.TemplateName;


            if (User.Equals(null))
            {

            }

            if (User != null)
            {


            }

            return View();
        }


    }
}