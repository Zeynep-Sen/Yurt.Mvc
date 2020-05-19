using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yurt.Mvc.Models
{
    public class Ogrenci
    { 
     public int ogrenciId { get; set; }
        [Display(Name ="Öğrencinin Adı")]
        [Required]
       
        public string ad { get; set; }
        [Display(Name = "Soyadı")]
        [Required]
        public string soyad { get; set; }
        [Display(Name = "Anne Adı")]
        [Required]
        public string anneAd { get; set; }
        [Display(Name = "Anne Soyadı")]
        [Required]
        public string anneSoyad { get; set; }
        [Display(Name = "Baba Adı")]
        [Required]
        public string babaAd { get; set; }
        [Display(Name = "Tc Kimlik Numarası")]
        [Required]
        [MaxLength(11)]
        public string tc { get; set; }
        [Display(Name = "Baba Soyadı")]
        [Required]
        public string babaSoyad { get; set; }
        [Display(Name = "Okuduğu Okul")]
        [Required]
        public int okulId { get; set; }
        [Display(Name = "Okuduğu Okul")]
        public Okul okulu { get; set; }
        
    }
}