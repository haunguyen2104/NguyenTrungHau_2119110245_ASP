using PagedList;
using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Category
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var listCategory = new List<Category_2119110245>();
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
                listCategory = objWebsiteBanHangEntities.Category_2119110245.Where(x => x.CategoryName.Contains(SearchString) && x.Deleted == false).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listCategory = objWebsiteBanHangEntities.Category_2119110245.Where(x => x.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listCategory = listCategory.OrderByDescending(x => x.CategoryId).ToList();
            return View(listCategory.ToPagedList(pageNumber, pageSize));
            //------------------------------------------------
            //var listCategory = objWebsiteBanHangEntities.Category_2119110245.ToList();
            //return View(listCategory);
        }
        public ActionResult Details(int id) {
            var objCate = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            return View(objCate); }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
       [HttpPost]
        public ActionResult Create(Category_2119110245 objCategory)
        {
            try
            {
                if (objCategory.ImageUpload != null)
                {

                    string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                    string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objCategory.Avatar = fileName;
                    objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/category/"), fileName));
                }
                objCategory.CreateOnUtc = DateTime.Now;
                objCategory.Slug = ToStringSlug.ToSlug(objCategory.CategoryName);
                objCategory.ShowOnHomePage = true;
                objCategory.Deleted = false;
                objWebsiteBanHangEntities.Category_2119110245.Add(objCategory);
                objWebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int id)
        {
            var objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(n => n.CategoryId == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Edit(int id, Category_2119110245 objCategory)
        {
            if (objCategory.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                fileName = fileName +  extension;
                objCategory.Avatar = fileName;
                objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/category/"), fileName));
            }
            objCategory.Slug = ToStringSlug.ToSlug(objCategory.CategoryName);
            objCategory.UpdateOnUtc = DateTime.Now;
                  objWebsiteBanHangEntities.Entry(objCategory).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objCate = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();

            return View(objCate);
        }
        public ActionResult Delete(Category_2119110245 objCategory)
        {
            var objCate = objWebsiteBanHangEntities.Category_2119110245.Where(n => n.CategoryId == objCategory.CategoryId).FirstOrDefault();
            objWebsiteBanHangEntities.Category_2119110245.Remove(objCate);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}