using ShopApp3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp3.WebUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }

        public List<Category> Categories { get; set; }
    }
}
