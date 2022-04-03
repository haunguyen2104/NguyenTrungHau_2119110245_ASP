using Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Context
{
    public class PatialMetadataType
    {

    }

    //map csdl
    [MetadataType(typeof(UserMasterData))]
    public partial class User_2119110245
    {

    }
    [MetadataType(typeof(ProductMasterData))]
    public partial class Product_2119110245
    {
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(SliderMasterData))]
    public partial class Slider_2119110245
    {

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
    public partial class Brand_2119110245
    {

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
    public partial class Category_2119110245
    {

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    } public partial class Post_2119110245
    {

        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }

}