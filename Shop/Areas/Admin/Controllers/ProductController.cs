using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Shop.Common;

namespace Shop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index(string SearchString)
        {
            //if (SearchString != "")
            //{
                
            //    var lstpro = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.FullName.Contains(SearchString)).ToList();
            //    return View(lstpro);
            //}
            //else
            //{
                var lstpro = objWebsiteBanHangEntities.Product_2119110245.ToList();
                return View(lstpro);
            //}
        }
        [HttpGet]
        public ActionResult Create()
        {
            LoadData();
            return View();
        }



        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product_2119110245 objProduct)
        {
            LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objProduct.ImageUpload != null)
                    {

                        string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objProduct.Avatar = fileName;
                        objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/product/"), fileName));
                    }

                    objProduct.CreatedOnUtc = DateTime.Now;
                    objWebsiteBanHangEntities.Product_2119110245.Add(objProduct);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(objProduct);

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        public ActionResult Delete(int id)
        {
            var objProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product_2119110245 objPro)
        {
            var objProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebsiteBanHangEntities.Product_2119110245.Remove(objProduct);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //------------------------------

            //------------------------------
            var objProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult Edit(int id, Product_2119110245 objProduct)
        {
            if (objProduct.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/product/"), fileName));
            }
            objWebsiteBanHangEntities.Entry(objProduct).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }


        void LoadData()
        {
            Common objCommon = new Common();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            //Lấy dữ liệu từ database 
            //Danh mục
            var lstCategory = objWebsiteBanHangEntities.Category_2119110245.ToList();
            //Convert sang select list dạng value,text
            DataTable dtCategory = converter.ToDataTable(lstCategory);
            ViewBag.ListCategory = objCommon.ToSelectList(dtCategory, "CategoryId", "CategoryName");

            //Thương hiệu
            var lstBrand = objWebsiteBanHangEntities.Brand_2119110245.ToList();
            //Convert sang select list dạng value,text
            DataTable dtBrand = converter.ToDataTable(lstBrand);
            ViewBag.ListBrand = objCommon.ToSelectList(dtBrand, "BrandId", "BrandName");

            //Loại sản phẩm
            List<ProductType> lstProductType = new List<ProductType>();
            ProductType objProductType = new ProductType();
            objProductType.Id = 01; objProductType.Name = "Giảm giá sốc"; lstProductType.Add(objProductType);
            objProductType = new ProductType();
            objProductType.Id = 02; objProductType.Name = "Đề xuất"; lstProductType.Add(objProductType);

            DataTable dtType = converter.ToDataTable(lstProductType);
            ViewBag.ProductType = objCommon.ToSelectList(dtType, "Id", "Name");
        }
    }
}