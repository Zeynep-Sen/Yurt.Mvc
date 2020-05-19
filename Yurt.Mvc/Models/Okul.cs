using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yurt.Mvc.Models
{
    public class Okul
    {
        public int OkulID { get; set; }
        [Required]
        [Display (Name ="Okul Adı")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Lütfen Sadece Harf Giriniz.")]
        public string Okul_Ad { get; set; }


        public ICollection<Ogrenci> OkuldakiOgrenciler { get; set; }
    }
}