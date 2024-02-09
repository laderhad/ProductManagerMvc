using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Drawing.Text;
using WebApplication4.Web.Helper;
using WebApplication4.Web.Models;
using WebApplication4.Web.ViewModels;



namespace WebApplication4.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private readonly ProductRepository _productRepository;


        private readonly IMapper _mapper;


        //private IHelper _helper;
        
        public ProductsController(AppDbContext context,IMapper mapper) { 

            
            //DI container
            //Dependency Injection Pattern
            _productRepository=new ProductRepository();
            _context=context;
            _mapper=mapper;
            //linq method
   //         if (!_context.Products.Any())
   //         {
			//	_context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 100 });
			//	_context.Products.Add(new Product() { Name = "Kalem 2", Price = 100, Stock = 200 });
			//	_context.Products.Add(new Product() { Name = "Kalem 3", Price = 100, Stock = 300 });

			//	_context.SaveChanges();
			//}
            
        }
        //public IActionResult Index([FromServices] IHelper helper2)
        //{
        //    var text = "Asp.Net";

        //    var upperText = _helper.Upper(text);

        //    var status = _helper.Equals(helper2);


        //    var products = _context.Products.ToList();


        //    return View(products);
        //}
        public IActionResult Index()
        {
            //var text = "Asp.Net";

            //var upperText = _helper.Upper(text);

            //var status = _helper.Equals(helper2);
            

            var products = _context.Products.ToList();
            

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult Remove(int id)
        {
            var products = _context.Products.Find(id);

            _context.Products.Remove(products);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        
        [HttpGet]
        public IActionResult Add() {


            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay",1},
                {"3 Ay",3},
                {"6 Ay",6},
                {"12 Ay",12}
            };



            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new(){ Data="Mavi",Value="Mavi"},
                new(){ Data="Kırmızı",Value="Kırmızı"},
                new(){ Data="Kırmızı",Value="Kırmızı"}
            }, "Value", "Data");

            

            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct) {
            //var name = HttpContext.Request.Form["Name"].ToString();


            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());

            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());

            //Product newProduct = new Product() { Name = Name, Price = Price, Stock = Stock };

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Products.Add(_mapper.Map<Product>(newProduct));
                    _context.SaveChanges() ;


                    TempData["status"] = "ürün başarıyla yüklendi";
                    return RedirectToAction("Index");
                }

                catch (Exception) {

                    ModelState.AddModelError(String.Empty, "Ürün kaydedilirken bir hata meydana geldi lütfen daha sonra tekrar deneyin.");
                        return View();
                
                
                }


            }
            else
            {




                return View();

            }




            
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1 },
                 { "3 Ay",3 },
                 { "6 Ay",6 },
                 { "12 Ay",12 }
            };
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
                new(){ Data="Mavi" ,Value="Mavi" },
                  new(){ Data="Kırmızı" ,Value="Kırmızı" },
                    new(){ Data="Sarı" ,Value="Sarı" }
        
            
            }, "Value", "Data", product.Color);

            return View(_mapper.Map<ProductViewModel>(product));

        }




        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {

            

            if (!ModelState.IsValid)
            {

                ViewBag.ExpireValue = updateProduct.Expire;
                ViewBag.Expire = new Dictionary<string, int>()
            {
                { "1 Ay",1 },
                 { "3 Ay",3 },
                 { "6 Ay",6 },
                 { "12 Ay",12 }
            };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {

                new(){ Data="Mavi" ,Value="Mavi" },
                  new(){ Data="Kırmızı" ,Value="Kırmızı" },
                    new(){ Data="Sarı" ,Value="Sarı" }


            }, "Value", "Data", updateProduct.Color);

                return View();
            }

            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        [Route("[controller]/[action]/page/{page}/pagesize/{pagesize}")]
        [HttpGet]
        public IActionResult GetData(int page, int pageSize)
        {

            return View();
        }



        [AcceptVerbs("GET", "POST")]
        public IActionResult HasProductName(string Name)
        {

            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());

            if (anyProduct)
            {
                return Json("Kaydetmeye çalıştığınız ürün ismi veritabanında bulunmaktadır.");
            }
            else
            {
                return Json(true);
            }




        }
    }

}
