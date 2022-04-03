using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Admin/Post
        public ActionResult Index()
        {
            var listPost = objWebsiteBanHangEntities.Post_2119110245.Where(a => a.isDelete == false).ToList();
            return View(listPost);
        } public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Post_2119110245 objPost)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Post_2119110245 objPost)
        {
            return View();
        }
    }
}