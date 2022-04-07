using PagedList;
using Shop.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
      
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Brand
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var listBrand = new List<Brand_2119110245>();
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
                listBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(x => x.BrandName.Contains(SearchString) && x.Deleted == false).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(x => x.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listBrand = listBrand.OrderByDescending(x => x.BrandId).ToList();
            return View(listBrand.ToPagedList(pageNumber, pageSize));
         
        }
        public ActionResult Details(int id)
        {
            var objBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(a => a.BrandId == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand_2119110245 objBrand)
        {
            try
            {
                if (objBrand.ImageUpload != null)
                {

                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/brand/"), fileName));
                }
                objWebsiteBanHangEntities.Brand_2119110245.Add(objBrand);
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
            var objBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(n => n.BrandId == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand_2119110245 objBrand)
        {
            if (objBrand.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/brand/"), fileName));
            }
            objWebsiteBanHangEntities.Entry(objBrand).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(a => a.BrandId == id).FirstOrDefault();

            return View(objBrand);
        }
        public ActionResult Delete(Brand_2119110245 objBrands)
        {
            var objBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(n => n.BrandId == objBrands.BrandId).FirstOrDefault();
            objWebsiteBanHangEntities.Brand_2119110245.Remove(objBrand);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}