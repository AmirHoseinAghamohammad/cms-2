using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
   public class BlogComment
    {
      [Key]
       public int CommentID { get; set; }

        [Display(Name ="وبلاگ")] 
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public int BlogID { get; set; }

        [Display(Name ="نام")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]  
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name ="ایمیل")] 
        [MaxLength(200)]
        [EmailAddress(ErrorMessage ="لطفا ایمیل را به شکل صحیح وارد کنید")]
        public string Email { get; set; }

        [Display(Name ="وب سایت")]  
        [MaxLength(200)]
        [Url(ErrorMessage = "لطفا آدرس وب سایت را به شکل صحیح وارد کنید")]
        public string WebSite { get; set; }

        [Display(Name ="نظرات")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Display(Name ="تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        //Navigation Property
        public virtual Blog Blog { get; set; }

    }
}
