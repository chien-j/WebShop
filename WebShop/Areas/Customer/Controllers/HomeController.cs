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



        public IActionResult Index(string searchTerm, int? categoryId)
        {
            IEnumerable<Product> productList;

            if (!string.IsNullOrEmpty(searchTerm))
            {

                productList = _unitofwork.Product.GetAll(filter: p => (p.TenCay.ToLower().Contains(searchTerm.ToLower()) ||p.MoTaCay.ToLower().Contains(searchTerm.ToLower())) &&(!categoryId.HasValue || p.CategoryId == categoryId.Value),includeProperties: "Category,ProductImages"  );
            }
            else if (categoryId.HasValue)
            {
                
                productList = _unitofwork.Product.GetAll(
                    filter: p => p.CategoryId == categoryId.Value,
                    includeProperties: "Category,ProductImages"
                );
            }
            else
            {
                
                productList = _unitofwork.Product.GetAll(includeProperties: "Category,ProductImages");
            }

            var groupedProducts = productList.GroupBy(p => p.Category).ToList();

            return View(groupedProducts);
        }
        public IActionResult Index_Blog(string searchTerm, int? topic_treeId)
        {
            IEnumerable<Blog> blogList;

            if (!string.IsNullOrEmpty(searchTerm))
            {

                blogList = _unitofwork.Blog.GetAll(filter: p => (p.Title.ToLower().Contains(searchTerm.ToLower()) || p.Body.ToLower().Contains(searchTerm.ToLower())) && (!topic_treeId.HasValue || p.Topic_treeId == topic_treeId.Value), includeProperties: "Topic_tree,BlogImages");
            }
            else if (topic_treeId.HasValue)
            {

                blogList = _unitofwork.Blog.GetAll(
                    filter: p => p.Topic_treeId == topic_treeId.Value,
                    includeProperties: "Topic_tree,BlogImages"
                );
            }
            else
            {

                blogList = _unitofwork.Blog.GetAll(includeProperties: "Topic_tree,BlogImages");
            }

            var groupedBlogs = blogList.GroupBy(p => p.Topic_tree).ToList();

            return View(groupedBlogs);
        }


        public IActionResult Details(int productId)
        {

            var product = _unitofwork.Product.Get(
           u => u.Id == productId,
           includeProperties: "Category,ProductImages"
       );

            if (product == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }

            return View(product); // Trả về đối tượng Product trực tiếp
        }

        public IActionResult Details_Blog(int blogId)
        {

            var blog = _unitofwork.Blog.Get(
           u => u.Id == blogId,
           includeProperties: "Topic_tree,BlogImages"
       );

            if (blog == null)
            {
                return NotFound(); // Trả về 404 nếu không tìm thấy sản phẩm
            }

            return View(blog); // Trả về đối tượng  trực tiếp
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

        public IActionResult Home_new(int? categoryId)
        {
            IEnumerable<Product> productList;

            if (categoryId.HasValue)
            {
                // Display products from a specific category
                productList = _unitofwork.Product.GetAll(
                    filter: p => p.CategoryId == categoryId.Value,
                    includeProperties: "Category,ProductImages"
                );
            }
            else
            {
                // Display all products if no category is specified
                productList = _unitofwork.Product.GetAll(includeProperties: "Category,ProductImages");
            }

            var groupedProducts = productList.GroupBy(p => p.Category).ToList();

            return View(groupedProducts);
        }


    }
}