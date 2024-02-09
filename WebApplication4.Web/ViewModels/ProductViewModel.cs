using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebApplication4.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Remote(action: "HasProductName", controller: "Products")]
        [Required(ErrorMessage = "İsim Alanı Boş Olamaz !")]
        [StringLength(90, ErrorMessage = "İsim Alanı Boş Olamaz !")]
        public string ? Name { get; set; } = null!;


        [Required(ErrorMessage = "Fiyat Alanı Boş Olamaz !")]
        public decimal? Price { get; set; }


        [Required(ErrorMessage = "Stok Alanı Boş Olamaz !")]
        [Range(0,300,ErrorMessage = "Açıklama Alanı Boş Olamaz !")]
        public int? Stock { get; set; }

        public string Color { get; set; }

        public DateTime PublishDate { get; set; }


        public bool IsPublish { get; set; }

        public string ?Expire { get; set; }

        [Required(ErrorMessage = "Açıklama Alanı Boş Olamaz !")]
        public string ?Description { get; set; }
    }
}
