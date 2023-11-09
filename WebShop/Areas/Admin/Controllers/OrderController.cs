using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Models.ViewModels;
using Shop.Utility;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderVM OrderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
    
        public IActionResult Index(string status)
        {
            List<OrderHeader> objOrderHeaders;

            if (string.IsNullOrEmpty(status) || status == "all")
            {
                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            }
            else
            {
                objOrderHeaders = _unitOfWork.OrderHeader.GetAll(
                    filter: o => o.OrderStatus == status,
                    includeProperties: "ApplicationUser"
                ).ToList();
            }

            ViewData["Status"] = status; // Lưu trạng thái hiện tại để sử dụng trong view

            return View(objOrderHeaders);

        }

        public IActionResult Details(int orderId)
        {
            OrderVM orderVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderHeaderId == orderId, includeProperties: "Product")
            };

            return View(orderVM);
        }



        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderHeader > objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties:"ApplicationUser").ToList();
            return Json(new { data = objOrderHeaders });
        }
        #endregion
    }
}
