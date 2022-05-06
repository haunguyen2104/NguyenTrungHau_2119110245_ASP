using PagedList;
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
    public class UserController : BaseController
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/User
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var listUser = new List<User_2119110245>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy ds sản phẩm theo từ khoá tìm kiếm
                listUser = objWebsiteBanHangEntities.User_2119110245.Where(x => x.FirstName.Contains(SearchString) && x.IsActive == 1).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listUser = objWebsiteBanHangEntities.User_2119110245.Where(x => x.IsActive == 1).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listUser = listUser.OrderByDescending(x => x.IsAdmin).ToList();
            return View(listUser.ToPagedList(pageNumber, pageSize));
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