using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class SenddMessageViewModel
    {
        [Required(ErrorMessage ="Lutfen Bu Alanı Bos Gecmeyiniz")]
        [StringLength(30,ErrorMessage ="litfen 30 karakterden fazla veri girisi yapmayınız")]
        public string NameSurname {  get; set; }
        [Required(ErrorMessage = "Lutfen Bu Alanı Bos Gecmeyiniz")]
        [StringLength(50, ErrorMessage = "litfen 50 karakterden fazla veri girisi yapmayınız")]
        [EmailAddress(ErrorMessage = "Lutfen gecerli bir mail giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lutfen Bu Alanı Bos Gecmeyiniz")]
        [StringLength(50, ErrorMessage = "litfen 50 karakterden fazla veri girisi yapmayınız")]
        [MinLength(5,ErrorMessage = "Lutfen en az 5 karakter girin")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Lutfen Bu Alanı Bos Gecmeyiniz")]
        [StringLength(1000, ErrorMessage = "litfen 1000 karakterden fazla veri girisi yapmayınız")]
        public string Message { get; set; }

    }
}