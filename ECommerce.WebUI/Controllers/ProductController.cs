using ECommerce.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(int page=1,int category=0)
        {
            int pageSize = 10;
            var products = _productService.GetAllByCategoryId(category);
            var model = new ProductListViewModel
            {
                Products=products.Skip((page-1)*pageSize).Take(pageSize).ToList(),
                CurrentCategory=category,
                PageCount=(int)Math.Ceiling(products.Count/(double)pageSize),
                PageSize=pageSize,
                CurrentPage=page
            };
            return View(model);
        }
    }
}
