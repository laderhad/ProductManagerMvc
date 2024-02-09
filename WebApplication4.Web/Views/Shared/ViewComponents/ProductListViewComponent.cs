using Microsoft.AspNetCore.Mvc;
using WebApplication4.Web.Models;
using WebApplication4.Web.ViewModels;
using WebApplication4.Web.Models;
using WebApplication4.Web.ViewModels;

namespace WebApplication4.Web.Views.Shared.ViewComponents
{

    //[ViewComponent(Name ="p-list")] //component isim değiştirmek istediğimizde kullanılır.
    public class ProductListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int type = 1)
        {

            var viewmodels = _context.Products.Select(x => new ProductListComponentViewModel()
            {

                Name = x.Name,

                Description = x.Description

            }).ToList();

            if (type == 1)
            {
                return View("Default", viewmodels);
            }
            else
            {
                return View("Type2", viewmodels);
            }








        }


    }
}

