using PagedList;
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
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var listProduct = new List<Product_2119110245>();
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
                listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(x => x.FullName.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listProduct = objWebsiteBanHangEntities.Product_2119110245.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listProduct = listProduct.OrderByDescending(x => x.Id).ToList();
            return View(listProduct.ToPagedList(pageNumber, pageSize));
         }
        [HttpGet]
        public ActionResult Create()
        {
            this.LoadData();
            return View();
        }



        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Product_2119110245 objProduct)
        {
            this.LoadData();
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
            this.LoadData();
            //------------------------------
            var objProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [ValidateInput(false)]

        [HttpPost]
        public ActionResult Edit(int id, Product_2119110245 objProduct)
        {
            this.LoadData();
            if (objProduct.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName  + extension;
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