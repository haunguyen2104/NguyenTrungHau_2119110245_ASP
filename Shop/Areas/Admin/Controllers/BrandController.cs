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
            this.LoadData();
            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/brand/"), fileName));
                    }
                    objBrand.CreatedOnUtc = DateTime.Now;
                    objBrand.Deleted = false;
                    objBrand.ShowOnHomePage = true;
                    objBrand.Slug = ToStringSlug.ToSlug(objBrand.BrandName);
                    objWebsiteBanHangEntities.Brand_2119110245.Add(objBrand);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(objBrand);
        }
        public ActionResult Edit(int id)
        {
            this.LoadData();
            var objBrand = objWebsiteBanHangEntities.Brand_2119110245.Where(n => n.BrandId == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand_2119110245 objBrand)
        {
            this.LoadData();
            if (ModelState.IsValid)
            {
                if (objBrand.ImageUpload != null)
                {

                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/product/"), fileName));
                }
                objBrand.UpdatedOnUtc = DateTime.Now;
                objBrand.Slug = ToStringSlug.ToSlug(objBrand.BrandName);
                objWebsiteBanHangEntities.Entry(objBrand).State = EntityState.Modified;
                objWebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objBrand);
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

        //------------------------------------------------------------------
        //------------------------------------------------------------------
        void LoadData()
        {
            Common objCommon = new Common();
            ListtoDataTableConverter converter = new ListtoDataTableConverter();


            //---------------------------------------------
            //Hiển thị trang chủ
            List<ProductDisplayHome> listDisplayHome = new List<ProductDisplayHome>();
            ProductDisplayHome objDisplayHome = new ProductDisplayHome();
            objDisplayHome.Value = "true";
            objDisplayHome.Name = "Hiển thị";
            listDisplayHome.Add(objDisplayHome);
            objDisplayHome = new ProductDisplayHome();
            objDisplayHome.Value = "false";
            objDisplayHome.Name = "Không hiển thị";
            listDisplayHome.Add(objDisplayHome);
            DataTable dtDisplayHome = converter.ToDataTable(listDisplayHome);
            ViewBag.ProductDisplayHome = objCommon.ToSelectList(dtDisplayHome, "Value", "Name");
            //---------------------------------------------
            //Deleted
            List<Delete> listDelete = new List<Delete>();
            Delete objDel = new Delete();
            objDel.Value = "true";
            objDel.Name = "Xoá";
            listDelete.Add(objDel);
            objDel = new Delete();
            objDel.Value = "false";
            objDel.Name = "Không xoá";
            listDelete.Add(objDel);
            DataTable dtDelete = converter.ToDataTable(listDelete);
            ViewBag.Delete = objCommon.ToSelectList(dtDelete, "Value", "Name");
            //---------------------------------------------
        }
    }

}