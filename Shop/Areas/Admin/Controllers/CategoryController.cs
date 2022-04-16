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
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Category
        //LOAD DANH SÁCH DANH MỤC-------------------------------------------------------------------------------------
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
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listCategory = listCategory.OrderByDescending(x => x.CategoryId).ToList();
            return View(listCategory.ToPagedList(pageNumber, pageSize));
        }
        //XEM CHI TIẾT DANH MỤC---------------------------------------------------------------------------------------
        public ActionResult Details(int id)
        {
            var objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            return View(objCategory);
        }
        //THÊM MỚI DANH MỤC-------------------------------------------------------------------------------------------
        public ActionResult Create()
        {
            this.LoadData();
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
                    fileName = fileName + extension;
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
        //CHỈNH SỬA DANH MỤC------------------------------------------------------------------------------------------
        public ActionResult Edit(int id)
        {
            this.LoadData();
            //------------------------------
            var objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(n => n.CategoryId == id).FirstOrDefault();
            return View(objCategory);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, Category_2119110245 objCategory) 
        {
            objCategory.CategoryId = id;
            if (objCategory.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objCategory.ImageUpload.FileName);
                string extension = Path.GetExtension(objCategory.ImageUpload.FileName);
                fileName = fileName + extension;
                objCategory.Avatar = fileName;
                objCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/category/"), fileName));
            }
            objCategory.UpdateOnUtc = DateTime.Now;
            objCategory.Slug = ToStringSlug.ToSlug(objCategory.CategoryName);
            objWebsiteBanHangEntities.Entry(objCategory).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        //XOÁ DANH MỤC------------------------------------------------------------------------------------------------
        ///DANH SÁCH DANH MỤC TRONG THÙNG RÁC
        public ActionResult ListInTrash(string currentFilter, string SearchString, int? page)
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
                listCategory = objWebsiteBanHangEntities.Category_2119110245.Where(x => x.CategoryName.Contains(SearchString) && x.Deleted == true).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listCategory = objWebsiteBanHangEntities.Category_2119110245.Where(x => x.Deleted == true).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listCategory = listCategory.OrderByDescending(x => x.CategoryId).ToList();
            return View(listCategory.ToPagedList(pageNumber, pageSize));
        }
        ///ĐƯA VÀO THÙNG RÁC
        public ActionResult ToggleTrash(int id)
        {
            this.LoadData();
            var objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult ToggleTrash(int id, Category_2119110245 objCategory)
        {
            this.LoadData();
            objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            objCategory.Deleted = true;
            objWebsiteBanHangEntities.Entry(objCategory).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        ///KHÔI PHỤC
        public ActionResult Recover(int id)
        {
            this.LoadData();
            var objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            return View(objCategory);

        }
        [HttpPost]
        public ActionResult Recover(int id, Category_2119110245 objCategory)
        {
            this.LoadData();
            objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            objCategory.Deleted = false;
            objWebsiteBanHangEntities.Entry(objCategory).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        ///XOÁ VĨNH VIỄN
        public ActionResult Delete(int id)
        {
            this.LoadData();
            var objCategory = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            return View(objCategory);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category_2119110245 objCategory)
        {
            var objCate = objWebsiteBanHangEntities.Category_2119110245.Where(a => a.CategoryId == id).FirstOrDefault();
            objWebsiteBanHangEntities.Category_2119110245.Remove(objCate);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("ListInTrash");
        }
        //LOAD DATA---------------------------------------------------------------------------------------------------
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