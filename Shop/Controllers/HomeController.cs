using Facebook;
using PagedList;
using Shop.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace Shop.Controllers
{

    public class HomeController : Controller
    {
        //private Uri RedirectUri
        //{
        //    get
        //    {
        //        var uriBuilder = new UriBuilder(Request.Url);
        //        uriBuilder.Query = null;
        //        uriBuilder.Fragment = null;
        //        uriBuilder.Path = Url.Action("FacebookCallback");
        //        return uriBuilder.Uri;
        //    }
        //}
        WebsiteBanHangEntities objWebsiteBanHangEntities = new WebsiteBanHangEntities();
        public ActionResult Index()
        {
            var listProducts = new List<Product_2119110245>();
            var listCategory = new List<Category_2119110245>();
            var listBrand = new List<Brand_2119110245>();
            var listSlider = objWebsiteBanHangEntities.Slider_2119110245.Where(a=>a.IsDelete==false).ToList();
            var listPost = new List<Post_2119110245>();
            //Lấy sản phẩm giá sốc
            // var listProduct= objWebsiteBanHangEntities.C2119110245_Product.ToList();
            listProducts = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.Deleted == false).ToList();
            //Lấy danh mục sản phẩm
            listCategory = objWebsiteBanHangEntities.Category_2119110245.ToList();
            //Lấy thương hiệu
            listBrand = objWebsiteBanHangEntities.Brand_2119110245.ToList();

            //Lấy post
            listPost = objWebsiteBanHangEntities.Post_2119110245.Where(a => a.isDelete == false).ToList();
         
            HomeModel objhomeModel = new HomeModel();
            objhomeModel.listCategory = listCategory;
            objhomeModel.listProduct = listProducts;
            objhomeModel.listBrand = listBrand;
            objhomeModel.listSilder = listSlider;
            objhomeModel.listPost = listPost;
            return View(objhomeModel);
        }
        public ActionResult PostDetail(int id)
        {
            PostModel objPostModel = new PostModel();
            var objPost = objWebsiteBanHangEntities.Post_2119110245.Where(n => n.PostId == id).FirstOrDefault();
            var listPost = objWebsiteBanHangEntities.Post_2119110245.ToList();
            objPostModel.objPost = objPost;
            objPostModel.listPost = listPost;
            return View(objPostModel);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User_2119110245 _user)
        {
            if (ModelState.IsValid)
            {
                var check = objWebsiteBanHangEntities.User_2119110245.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    //_user.Password = GetMD5(_user.Password);
                    _user.Password = ConvertMD5.GetMD5(_user.Password);
                    _user.IsAdmin = 0;
                    objWebsiteBanHangEntities.Configuration.ValidateOnSaveEnabled = false;
                    objWebsiteBanHangEntities.User_2119110245.Add(_user);
                    objWebsiteBanHangEntities.SaveChanges();
                    //TempData["success"] = "Đăng ký thành công";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["error"] = "Thông tin tài khoản đã tồn tại";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = ConvertMD5.GetMD5(password);
                var data = objWebsiteBanHangEntities.User_2119110245.Where(s => s.IsActive == 1 && s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Id"] = data.FirstOrDefault().Id;
                    Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
                    //TempData["success"] = "Đăng nhập thành công";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Sai thông tin tài khoản hoặc mật khẩu";
                    //ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult LoginFacebook()
        {
            //var fb = new FacebookClient();
            //var loginUrl = fb.GetLoginUrl(new
            //{
            //    client_id = ConfigurationManager.AppSettings["FBAppId"],
            //    client_secret = ConfigurationManager.AppSettings["FBAppSecret"],
            //    redirect_uri = RedirectUri.AbsoluteUri,
            //    response_type = "code",
            //    scope = "email"
            //});

            //return Redirect(loginUrl.AbsoluteUri);
            return View();
        }
        public ActionResult FacebookCallback(string code)
        {
            //var fb = new FacebookClient();
            //dynamic result = fb.Post("oauth/access_token", new
            //{
            //    client_id = ConfigurationManager.AppSettings["FBAppId"],
            //    client_secret = ConfigurationManager.AppSettings["FBAppSecret"],
            //    redirect_uri = RedirectUri.AbsoluteUri,
            //    code = code
            //});
            //var accessToken = result.access_token;
            //if (!string.IsNullOrEmpty(accessToken))
            //{
            //    fb.AccessToken = accessToken;
            //    dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
            //    string email = me.email;
            //    string userName = me.email;
            //    string firstname = me.first_name;
            //    string lastname = me.last_name;
            //    string middlename = me.middle_name;

            //    var users = new User_2119110245();
            //    users.Email = email;
            //    users.FirstName = firstname + " " + middlename;
            //    users.LastName = lastname;
            //    objWebsiteBanHangEntities.User_2119110245.Add(users);
            //    objWebsiteBanHangEntities.SaveChanges();
               
            //        //add session
            //        Session["FullName"] = firstname + " " + middlename + " " + lastname;
            //        Session["Email"] = email;
            //        Session["Id"] = users.Id;
            //        Session["IsAdmin"] = users.IsAdmin;
            //        //TempData["success"] = "Đăng nhập thành công";

                  
               
            //}
            return Redirect("/");
        }
        public ActionResult Logout()
        {
            Session.Clear();//Remove session
            return RedirectToAction("Index");
        }
        public ActionResult Search(string currentFilter, string SearchString, int? page)
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
                listProduct = objWebsiteBanHangEntities.Product_2119110245.Where(n => n.FullName.Contains(SearchString) && n.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            //Sắp xếp sp theo id sản phẩm, sp mới đc đưa lên đầu
            listProduct = listProduct.OrderBy(x => x.Id).ToList();
            return View(listProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}