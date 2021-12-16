using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
  public  class Slider
    {
        [Key]
        public int SlideID { get; set; }

        
        [Display(Name ="عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")] 
        public string Title { get; set; }


        [Display(Name ="متن")]
        public string Text { get; set; }


        [Display(Name ="توضیح مختصر")]
        public string ShortDescription { get; set; }


        [Display(Name ="تصویر")]
        public string ImageName { get; set; }


        [Display(Name ="تاریخ شروع")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DisplayFormat(DataFormatString ="{0: yyyy/mm/dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public System.DateTime StartDate  { get; set; }


        [Display(Name = "تاریخ پابان")] 
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DisplayFormat(DataFormatString = "{0: yyyy/mm/dd}", ApplyFormatInEditMode = true)]
       [Column(TypeName = "datetime2")]
        public System.DateTime EndDate { get; set; }



        [Display(Name = "وضعیت")]

        public bool IsActive { get; set; }


        [Display(Name = "لینک")] 
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [Url(ErrorMessage = "آدرس وارد شده معتبر نمی باشد")]
        public string url { get; set; }



    }
}
