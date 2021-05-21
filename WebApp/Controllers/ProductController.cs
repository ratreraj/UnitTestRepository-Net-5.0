using DAL;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        IUnitOfWork _uow;
       // IUnitOfWork _uow2;
        public ProductController(IUnitOfWork uow)
        {
            _uow = uow;
           // _uow2 = uow2;
        }
        public IActionResult Index()
        {
            var data = _uow.ProductRepo.GetProducts();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryList = _uow.CategoryRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            ModelState.Remove("ProductId");
            if (ModelState.IsValid)
            {
                _uow.ProductRepo.Add(model);
                _uow.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = _uow.CategoryRepo.GetAll();
            return View();
        }

        public IActionResult Edit(int id)
        {
            Product model = _uow.ProductRepo.Find(id);

            ViewBag.CategoryList = _uow.CategoryRepo.GetAll();
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _uow.ProductRepo.Update(model);
                _uow.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = _uow.CategoryRepo.GetAll();
            return View("Create", model);
        }

        public IActionResult Delete(int id)
        {
            _uow.ProductRepo.DeleteById(id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
