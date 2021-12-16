using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer
{
   public class Footer
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیح کوتاه درباره شرکت")]
        [Required(ErrorMessage = "لطفا{0}را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescriptionAboutFirm { get; set; }
  
    }
}
