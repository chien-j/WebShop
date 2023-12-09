using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Models.Models;
using Shop.Utility;
using System;
using System.IO;

namespace Shop.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class NewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var newsList = _unitOfWork.News.GetAll();
            return View(newsList);
        }

        public IActionResult Details(int id)
        {
            var news = _unitOfWork.News.Get(u => u.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(News news, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootpath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString()+ Path.GetExtension(file.FileName);
                    string newsPath = Path.Combine(wwwRootpath, @"images\news");

                    using (var fileStream = new FileStream(Path.Combine(newsPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    news.ImageFile = @"\images\news" + fileName;

                    _unitOfWork.News.Add(news);
                    _unitOfWork.Save();
                    TempData["success"] = "Thanh Cong";
                    return RedirectToAction(nameof(Index));
                }else
                
                {
                    return View(news);
                }
            }

            return View(news);
        }

        public IActionResult Edit(int id)
        {
            var news = _unitOfWork.News.Get(u => u.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, News news, IFormFile imageFile, IFormFile imageFile_01)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Delete existing images before uploading new ones
                    DeleteImage(news.ImageFile);
                    DeleteImage(news.ImageFile_01);

                    news.ImageFile = UploadFile(imageFile);
                    news.ImageFile_01 = UploadFile(imageFile_01);

                    _unitOfWork.News.Update(news);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    ModelState.AddModelError("", $"Error during file upload: {ex.Message}");
                }
            }
            return View(news);
        }

        public IActionResult Delete(int id)
        {
            var news = _unitOfWork.News.Get(u => u.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var news = _unitOfWork.News.Get(u => u.Id == id);

            // Delete associated images when deleting news
            DeleteImage(news.ImageFile);
            DeleteImage(news.ImageFile_01);

            _unitOfWork.News.Remove(news);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        private string UploadFile(IFormFile file)
        {
            try
            {
                string uniqueFileName = null;

                if (file != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                return uniqueFileName;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"Error during file upload: {ex.Message}");
            }
        }

        private void DeleteImage(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                try
                {
                    string filePath = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    throw new Exception($"Error during file deletion: {ex.Message}");
                }
            }
        }
    }
}
