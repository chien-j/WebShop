using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repository;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Models.ViewModels;
using Shop.Utility;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]


    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BlogController(IUnitOfWork unitiofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfwork = unitiofwork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string searchString, string topic_tree)
        {
            // Lấy danh sách các danh mục
            ViewBag.Topic_trees = _unitOfwork.Topic_tree.GetAll().ToList();

            // Lấy tất cả sản phẩm với thông tin danh mục
            List<Blog> objBlogList = _unitOfwork.Blog.GetAll(includeProperties: "Topic_tree").ToList();


            return View(objBlogList);
        }


        public IActionResult Upsert(int? id)
        {

            BlogVM blogVM = new()
            {
                Topic_treeList = _unitOfwork.Topic_tree.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),

                Blog = new Blog()
            };
           if(id == null || id ==0)
            {
                //Create
                return View(blogVM);
            }
            else
            {
                //update
                blogVM.Blog = _unitOfwork.Blog.Get(u=>u.Id == id, includeProperties: "BlogImages");
                return View(blogVM);

            }
        }
        [HttpPost]
        public IActionResult Upsert(BlogVM blogVM, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                if (blogVM.Blog.Id == 0)
                {
                    _unitOfwork.Blog.Add(blogVM.Blog);
                }
                else
                {
                    _unitOfwork.Blog.Update(blogVM.Blog);
                }

                _unitOfwork.Save();


                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
                {

                    foreach (IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string blogPath = @"images\blogs\blog-" + blogVM.Blog.Id;
                        string finalPath = Path.Combine(wwwRootPath, blogPath);

                        if (!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        BlogImage blogImage = new()
                        {
                            ImageUrl = @"\" + blogPath + @"\" + fileName,
                            BlogId = blogVM.Blog.Id,
                        };

                        if (blogVM.Blog.BlogImages == null)
                            blogVM.Blog.BlogImages = new List<BlogImage>();

                        blogVM.Blog.BlogImages.Add(blogImage);

                    }

                    _unitOfwork.Blog.Update(blogVM.Blog);
                    _unitOfwork.Save();




                }


                TempData["success"] = "Câp nhật thành công";
                return RedirectToAction("Index");
            }
            else
            {
                blogVM.Topic_treeList = _unitOfwork.Topic_tree.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                   
                return View(blogVM);
            }
        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted = _unitOfwork.BlogImage.Get(u => u.Id == imageId);
            int blogId = imageToBeDeleted.BlogId;
            if (imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath =
                                   Path.Combine(_webHostEnvironment.WebRootPath,
                                   imageToBeDeleted.ImageUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                _unitOfwork.BlogImage.Remove(imageToBeDeleted);
                _unitOfwork.Save();

                TempData["success"] = "Đã xóa danh mục thành công";
            }

            return RedirectToAction(nameof(Upsert), new { id = blogId });
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Blog? BlogFromDb = _unitOfwork.Blog.Get(u => u.Id == id);

            if (BlogFromDb == null)
            {
                return NotFound();
            }
            return View(BlogFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Blog? obj = _unitOfwork.Blog.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();

            }

            _unitOfwork.Blog.Remove(obj);
            _unitOfwork.Save();
            TempData["success"] = " Đã xóa danh mục thành công";

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll() {
            List<Blog> objBlogList = _unitOfwork.Blog.GetAll(includeProperties: "Topic_tree").ToList();
            return Json(new { dat = objBlogList });
        }

        #endregion
    }
}
