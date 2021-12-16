using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataLayer
{
   public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [Display(Name ="گروه بندی وبلاگ")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int GroupID { get; set; }

        [Display(Name ="عنوان ")] 
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(250)]
        public string Title { get; set; }

        [Display(Name ="توضیح مختصر")] 
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")] 
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDiscription { get; set; }

        [Display(Name ="متن")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string BlogText { get; set; }

        [Display(Name = "برچسب ها")]
        public string Tags { get; set; }

        [Display(Name ="بازدید")]
        public int Visit  { get; set; }

        [Display(Name =" تصویر")]
        public string ImageName { get; set; }

        [Display(Name ="تاریخ ایجاد")]
        [DisplayFormat(DataFormatString ="{0: yyyy/mm/dd}")]
        public DateTime CreateDate { get; set; }

        //Navigation Property
        public virtual BlogGroup BlogGroup { get; set; }
        public virtual ICollection<BlogComment> BlogComments { get; set; }
    }
}
