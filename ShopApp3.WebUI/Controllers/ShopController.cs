using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp3.Business.Abstract;
using ShopApp3.Entities;
using ShopApp3.WebUI.Models;

namespace ShopApp3.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }

        public IActionResult List(string category, int page = 1, string sortOrder = "")
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortAsc"] = sortOrder == "price" ? "price" : "price";
            ViewData["PriceSortDesc"] = sortOrder == "price" ? "price_desc" : "price_desc";



            const int pageSize = 6;
            var products = new ProductListModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category,
                    SortOrder=sortOrder
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            };
            switch (sortOrder)
            {
                case "price_desc":
                    products.Products = products.Products.OrderByDescending(s => s.Price).ToList();
                    break;
                case "name_desc":
                    products.Products = products.Products.OrderByDescending(s => s.Name).ToList();
                    break;
                case "price":
                    products.Products = products.Products.OrderBy(s => s.Price).ToList();
                    break;
                default:
                    products.Products = products.Products.OrderBy(s => s.Name).ToList();
                    break;
            }

            return View(products);
        }

        public IActionResult SearchProduct(string searchString)
        {
            if (String.IsNullOrEmpty(searchString))
            {
                return NotFound();
            }
            var products = _productService.GetAll();
            return View(new ProductListModel()
            {
                Products = products.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList()
            });
        }
    }
}