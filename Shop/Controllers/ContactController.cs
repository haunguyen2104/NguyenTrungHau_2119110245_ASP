using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        } 
       // [HttpPost]
        //public ActionResult Contact(Contact_2119110245 objContact)
        //{
        //    return View();
        //}
    }
}