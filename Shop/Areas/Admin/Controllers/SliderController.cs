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
    public class SliderController : BaseController
    {
        // GET: Admin/Slider
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        //LOAD DANH SÁCH HÌNH ẢNH-------------------------------------------------------------------------------------
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var listSlider = new List<Slider_2119110245>();
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

                listSlider = objWebsiteBanHangEntities.Slider_2119110245.Where(x => x.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy ds sản phẩm trong bảng product
                listSlider = objWebsiteBanHangEntities.Slider_2119110245.ToList();
            }

            ViewBag.CurrentFilter = SearchString;
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listSlider = listSlider.OrderByDescending(x => x.Id).ToList();
            return View(listSlider.ToPagedList(pageNumber, pageSize));
        }
        //XEM CHI TIẾT HÌNH ẢNH---------------------------------------------------------------------------------------
        public ActionResult Details(int id)
        {
            var objSlider = objWebsiteBanHangEntities.Slider_2119110245.Where(a => a.Id == id).FirstOrDefault();
            return View(objSlider);
        }
        public ActionResult Create()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Slider_2119110245 objSlider)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objSlider.ImageUpload != null)
                    {

                        string fileName = Path.GetFileNameWithoutExtension(objSlider.ImageUpload.FileName);
                        string extension = Path.GetExtension(objSlider.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objSlider.Avatar = fileName;
                        objSlider.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/slider/"), fileName));
                    }
                    objSlider.IsDelete = false;
                    objSlider.Class = "carousel-item";
                    objWebsiteBanHangEntities.Slider_2119110245.Add(objSlider);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(objSlider);
        }

        //TOGGLE TRẠNG THÁI XOÁ
        public ActionResult IsDelete(int id)
        {
            var objSlider = objWebsiteBanHangEntities.Slider_2119110245.Where(n => n.Id == id).FirstOrDefault();
            objSlider.IsDelete = (objSlider.IsDelete == true) ? false : true;
            objWebsiteBanHangEntities.Entry(objSlider).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}