using Shop.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ContactsController : Controller
    {
        WebsiteBanHangEntities db = new WebsiteBanHangEntities();
        // GET: Contacts
        public ActionResult SendContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendContact(Contact_2119110245 objContact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    objContact.CreateAt = DateTime.Now;
                    objContact.Title = "Liên hệ " + objContact.ContactId;
                    objContact.Status = 1;
                    db.Contact_2119110245.Add(objContact);
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");
                }
                catch (Exception)
                {

                    return RedirectToAction("Index","Home");
                }
            }
            return View(objContact);
        }
    }
}