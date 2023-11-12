using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Utility;
using System.Diagnostics;
using System.Security.Claims;
using WebShop.Models;

namespace WebShop.Areas.Customer.Controllers
{
    [Area("Customer")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitofwork;


        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitiofwork)
        {
            _logger = logger;
            _unitofwork = unitiofwork;

        }

        public IActionResult Index(string searchString, int categoryId)
        {
            IEnumerable<Product> productList = _unitofwork.Product.GetAll(includeProperties: "Category");

            // Nếu có chuỗi tìm kiếm, hãy lọc danh sách sản phẩm.
            if (!string.IsNullOrEmpty(searchString))
            {
                productList = productList.Where(p => p.Title.ToLower().Contains(searchString));
            }
            if (categoryId != 0)
            {
                productList = productList.Where(p => p.CategoryId == categoryId);
            }

            // Trả về danh sách sản phẩm.
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitofwork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitofwork.ShoppingCart.Get(u => u.ApplicationUserId == userId && u.ProductId == shoppingCart.ProductId);

            if(cartFromDb != null)
            {
                cartFromDb.Count += shoppingCart.Count;
                _unitofwork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                _unitofwork.ShoppingCart.Add(shoppingCart);
                HttpContext.Session.SetInt32(SD.SessionCart, _unitofwork.ShoppingCart.Get(u => u.ApplicationUserId == userId).Count);
            }

            TempData["success"] = "Giỏ hàng được thêm thành công";
            _unitofwork.Save();

            return  RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}