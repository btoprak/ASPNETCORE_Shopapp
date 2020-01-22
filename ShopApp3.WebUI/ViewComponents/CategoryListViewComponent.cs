﻿using Microsoft.AspNetCore.Mvc;
using ShopApp3.Business.Abstract;
using ShopApp3.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp3.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel() {
                SelectedCategory=RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll()
            });
        }
    }
}
