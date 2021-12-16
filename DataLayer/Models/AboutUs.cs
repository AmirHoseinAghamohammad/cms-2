using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
  public  class AboutUs
    {
       [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "درباره ما")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string AboutUsText { get; set; }

        [Display(Name = "تصویر درباره ما")]
        public string ImageName { get; set; }
    }
}
