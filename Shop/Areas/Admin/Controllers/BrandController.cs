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
        public ActionResult Index()
        {
            var listBrand = objWebsiteBanHangEntities.Brand_2119110245.ToList();
            return View(listBrand);
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