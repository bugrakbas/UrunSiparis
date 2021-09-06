using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrunSiparis.Models
{
    public class UrunSiparisModel
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Required]
        [Display(Name = "Şehir")]
        public City City { get; set; }
        [Required]
        [Display(Name = "Ülke")]
        public string Country { get; set; }

    }
}
