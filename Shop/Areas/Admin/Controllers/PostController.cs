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
    public class PostController : BaseController
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Post
        //LOAD DANH SÁCH BÀI VIẾT-------------------------------------------------------------------------------------
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var listPost = new List<Post_2119110245>();
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
                //lấy ds post theo từ khoá tìm kiếm
                listPost = objWebsiteBanHangEntities.Post_2119110245.Where(x => x.PostTitle.Contains(SearchString) && x.isDelete == false).ToList();
            }
            else
            {
                //lấy ds post trong bảng product
                listPost = objWebsiteBanHangEntities.Post_2119110245.Where(x => x.isDelete== false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listPost = listPost.OrderByDescending(x => x.PostId).ToList();
            return View(listPost.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int id)
        {
            var objPost = objWebsiteBanHangEntities.Post_2119110245.Where(a => a.PostId == id).FirstOrDefault();
            return View(objPost);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Post_2119110245 objPost)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objPost.ImageUpload != null)
                    {

                        string fileName = Path.GetFileNameWithoutExtension(objPost.ImageUpload.FileName);
                        string extension = Path.GetExtension(objPost.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objPost.PostAvatar = fileName;
                        objPost.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/post/"), fileName));
                    }

                    objPost.PostDateCreate = DateTime.Now;
                    objPost.isDelete = false;
                    objPost.PostSlug = ToStringSlug.ToSlug(objPost.PostTitle);
                    objWebsiteBanHangEntities.Post_2119110245.Add(objPost);
                    objWebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objPost = objWebsiteBanHangEntities.Post_2119110245.Where(n => n.PostId == id).FirstOrDefault();
            return View(objPost);
        }
        [HttpPost]
        public ActionResult Edit(int id,Post_2119110245 objPost)
        {
            objPost.PostId = id;
            if (objPost.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(objPost.ImageUpload.FileName);
                string extension = Path.GetExtension(objPost.ImageUpload.FileName);
                fileName = fileName + extension;
                objPost.PostAvatar = fileName;
                objPost.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/post/"), fileName));
            }
            //objPost.UpdatedOnUtc = DateTime.Now;
            objPost.PostSlug = ToStringSlug.ToSlug(objPost.PostTitle);
            objWebsiteBanHangEntities.Entry(objPost).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        //XOÁ BÀI VIẾT------------------------------------------------------------------------------------------------
        ///DANH SÁCH BÀI VIẾT TRONG THÙNG RÁC
        public ActionResult ListInTrash(string currentFilter, string SearchString, int? page)
        {
            var objPost = new List<Post_2119110245>();
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
                //lấy ds bài viết theo từ khoá tìm kiếm
                objPost = objWebsiteBanHangEntities.Post_2119110245.Where(x => x.PostTitle.Contains(SearchString) && x.isDelete == true).ToList();
            }
            else
            {
                //lấy ds bài viết trong bảng post
                objPost = objWebsiteBanHangEntities.Post_2119110245.Where(x => x.isDelete == true).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id bài viết, bài viết mới đc đưa lên đầu
            objPost = objPost.OrderByDescending(x => x.PostId).ToList();
            return View(objPost.ToPagedList(pageNumber, pageSize));
        }
        ///ĐƯA VÀO THÙNG RÁC
        public ActionResult ToggleTrash(int id, Post_2119110245 objPost)
        {
            objPost = objWebsiteBanHangEntities.Post_2119110245.Where(a => a.PostId == id).FirstOrDefault();
            objPost.isDelete = true;
            objWebsiteBanHangEntities.Entry(objPost).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        ///KHÔI PHỤC
        public ActionResult Recover(int id, Post_2119110245 objPost)
        {
            objPost = objWebsiteBanHangEntities.Post_2119110245.Where(a => a.PostId == id).FirstOrDefault();
            objPost.isDelete = false;
            objWebsiteBanHangEntities.Entry(objPost).State = EntityState.Modified;
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        ///XOÁ VĨNH VIỄN

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objPost = objWebsiteBanHangEntities.Post_2119110245.Where(a => a.PostId == id).FirstOrDefault();
            return View(objPost);
        }
        [HttpPost]
        public ActionResult Delete(int id,Post_2119110245 objPost)
        {
            objPost = objWebsiteBanHangEntities.Post_2119110245.Where(a => a.PostId == id).FirstOrDefault();
            objWebsiteBanHangEntities.Post_2119110245.Remove(objPost);
            objWebsiteBanHangEntities.SaveChanges();
            return RedirectToAction("ListInTrash");
        }
    }
}