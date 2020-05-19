using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yurt.Mvc.Models
{
    public class Ogrenci
    { //dropdownlist yüzünden çalışma esnasında çok hata verdiği için açıklama satırı olarak ekledim okul classında çalışıyor :)
     public int ogrenciId { get; set; }
        [Display(Name ="Öğrencinin Adı")]
        [Required]
       // [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$",
       //  ErrorMessage = "Lütfen Sadece harf giriniz.")]
        public string ad { get; set; }
        [Display(Name = "Soyadı")]
        [Required]
       // [RegularExpression(@"^[a-zA-Z''-'\s]{1,25}$",
       //  ErrorMessage = "Lütfen Sadece harf giriniz.")]
        public string soyad { get; set; }
        [Display(Name = "Anne Adı")]
        [Required]
       // [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$",
       //  ErrorMessage = "Lütfen Sadece harf giriniz.")]
        public string anneAd { get; set; }
        [Display(Name = "Anne Soyadı")]
        [Required]
       // [RegularExpression(@"^[a-zA-Z''-'\s]{1,25}$",
       //  ErrorMessage = "Lütfen Sadece harf giriniz.")]
        public string anneSoyad { get; set; }
        [Display(Name = "Baba Adı")]
        [Required]
      //  [RegularExpression(@"^[a-zA-Z''-'\s]{1,30}$",
       //  ErrorMessage = "Lütfen Sadece harf giriniz.")]
        public string babaAd { get; set; }
        [Display(Name = "Tc Kimlik Numarası")]
        [Required]
      //  [MaxLength(11)]
        public string tc { get; set; }
        [Display(Name = "Baba Soyadı")]
        [Required]
      //  [RegularExpression(@"^[a-zA-Z''-'\s]{1,25}$",
      //   ErrorMessage = "Lütfen Sadece harf giriniz.")]
        public string babaSoyad { get; set; }
        [Display(Name = "Okuduğu Okul")]
        [Required]
      //  [RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$",
       //  ErrorMessage = "Lütfen Sadece harf giriniz.")]
        public int okulId { get; set; }
        [Display(Name = "Okuduğu Okul")]
        public Okul okulu { get; set; }
        
    }
}