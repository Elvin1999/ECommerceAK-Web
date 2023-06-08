using ECommerce.Business.Abstract;
using ECommerce.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ECommerce.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private IHttpContextAccessor _contextAccessor;

        public CategoryListViewComponent(ICategoryService categoryService, IHttpContextAccessor contextAccessor)
        {
            _categoryService = categoryService;
            _contextAccessor = contextAccessor;
        }

        public ViewViewComponentResult Invoke()
        {
            var first = new Category
            {
                CategoryId = 0,
                CategoryName = "All Categories"
            };
            var categories=new List<Category>();
            categories.Add(first);
            categories.AddRange(_categoryService.GetAll());
            var model = new CategoryListViewModel
            {
                Categories=categories,
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };
            return View(model);
        }
    }
}
