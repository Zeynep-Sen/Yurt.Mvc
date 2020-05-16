using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yurt.Mvc.Models
{
    public class Kullanici

    {
        public int KullaniciId { get; set; }
        [Display(Name = "Email Adresi")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }
        [Display(Name = "Sifre")]
        [DataType(DataType.Password)]
        [Required]
        public string Sifre { get; set; }
    }
}