using ShopApp3.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp3.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(60, MinimumLength = 5, ErrorMessage = "Ürün ismi minimum 5 karakter maximum 60 karakter olabilir.")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Ürün açıklaması minimum 20 karakter maximum 500 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fiyat belirtiniz.")]
        [Range(1, 20000)]
        public decimal? Price { get; set; }

        public List<Category> SelectedCategories { get; set; }

    }
}
