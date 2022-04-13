using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Shop.Common;

namespace Shop.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/User
        public ActionResult Index()
        {
            var listUser = objWebsiteBanHangEntities.User_2119110245.ToList();
            return View(listUser);
        }
        //------------------toggle admin--------------
        public ActionResult IsAdmin(int? id)
        {
            var objUser = objWebsiteBanHangEntities.User_2119110245.Where(n => n.Id == id).FirstOrDefault();
            objUser.IsAdmin = (objUser.IsAdmin == 1) ? 0 : 1;
            objWebsiteBanHangEntities.Entry(objUser).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult IsActive(int? id)
        {
            var objUser = objWebsiteBanHangEntities.User_2119110245.Where(n => n.Id == id).FirstOrDefault();
            objUser.IsActive = (objUser.IsActive == 1) ? 0 : 1;
            objWebsiteBanHangEntities.Entry(objUser).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
            
        }
        private void LoadData()
        {
            Common objCommon = new Common();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            //Giới tính
            List<Gender> lstGender = new List<Gender>();
            Gender objGender = new Gender();
            objGender.Value = "1"; objGender.Name = "Nữ"; lstGender.Add(objGender);
            objGender = new Gender();
            objGender.Value = "0"; objGender.Name = "Nam"; lstGender.Add(objGender);

            DataTable dtGender = converter.ToDataTable(lstGender);
            ViewBag.Gender = objCommon.ToSelectList(dtGender, "Id", "Name");
        }
    }
}