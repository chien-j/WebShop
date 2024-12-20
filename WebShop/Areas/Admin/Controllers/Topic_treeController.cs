using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Utility;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class Topic_treeController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public Topic_treeController(IUnitOfWork unitiofwork)
        {
            _unitofwork = unitiofwork;
        }
        public IActionResult Index()
        {
            List<Topic_tree> objTopic_treeList = _unitofwork.Topic_tree.GetAll().ToList();
            return View(objTopic_treeList);
        }

        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Topic_tree obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitofwork.Topic_tree.Add(obj);
                _unitofwork.Save();
                TempData["success"] = " Tạo mới danh mục thành công";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Topic_tree? Topic_treeFromDb = _unitofwork.Topic_tree.Get(u => u.Id == id);
           


            if (Topic_treeFromDb == null)
            {
                return NotFound();
            }
            return View(Topic_treeFromDb);
        }

         [HttpPost]
        public IActionResult Edit(Topic_tree obj)
        {
            

            if (ModelState.IsValid)
            {
                _unitofwork.Topic_tree.Update(obj);
                _unitofwork.Save();
                TempData["success"] = " Cập nhật danh mục thành công";

                return RedirectToAction("Index");

            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Topic_tree? Topic_treeFromDb = _unitofwork.Topic_tree.Get(u => u.Id == id);

            if (Topic_treeFromDb == null)
            {
                return NotFound();
            }
            return View(Topic_treeFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Topic_tree? obj = _unitofwork.Topic_tree.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }

            _unitofwork.Topic_tree.Remove(obj);
            _unitofwork.Save();
            TempData["success"] = " Đã xóa danh mục thành công";

            return RedirectToAction("Index");
        }


    }
}
