using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class SendBookAseatviewmodel
    {
        [Required(ErrorMessage = "Lutfen Bu Alanı Bos Gecmeyiniz")]
        [StringLength(30, ErrorMessage = "litfen 30 karakterden fazla veri girisi yapmayınız")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lutfen Bu Alanı Bos Gecmeyiniz")]
        [StringLength(50, ErrorMessage = "litfen 50 karakterden fazla veri girisi yapmayınız")]
        [EmailAddress(ErrorMessage = "Lutfen gecerli bir mail giriniz")]
        public string Email { get; set; }

    }
}