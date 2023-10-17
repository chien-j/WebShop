using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Models.ViewModels;
using System.Security.Claims;

namespace WebShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
         public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitofwork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product")
            };

            foreach(var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBaseOnQuantity(cart);
                ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM );
        }

        public IActionResult Summary()
        {
            return View();
        }



        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitofwork.ShoppingCart.Get(u=>u.Id == cartId);
            cartFromDb.Count += 1;
            _unitofwork.ShoppingCart.Update(cartFromDb);
            _unitofwork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitofwork.ShoppingCart.Get(u => u.Id == cartId);
            if(cartFromDb.Count <= 1) 
            {
                _unitofwork.ShoppingCart.Remove(cartFromDb);

            }
            else
            {
                cartFromDb.Count -= 1;
                _unitofwork.ShoppingCart.Update(cartFromDb);

            }
            _unitofwork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitofwork.ShoppingCart.Get(u => u.Id == cartId);
           
            _unitofwork.ShoppingCart.Remove(cartFromDb);

            _unitofwork.Save();
            return RedirectToAction(nameof(Index));
        }

        private double GetPriceBaseOnQuantity( ShoppingCart shoppingCart)
        {
            if (shoppingCart.Count <= 50)
            {
                return shoppingCart.Product.Price;
            }
            else
            {
                if(shoppingCart.Count <= 100)
                {
                    return shoppingCart.Product.Price50;

                }
                else
                {
                    return shoppingCart.Product.Price100;
                }
            }
        }
    }
}
