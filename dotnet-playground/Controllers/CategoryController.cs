using dotnet_playground.Data;
using dotnet_playground.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_playground.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            // Retrieve all Categories
            IEnumerable<Category> ObjCategoryList = _db.Categories;   
            return View(ObjCategoryList);
        }


        //Get
        public IActionResult Create()
        {
            
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot be exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                //added to database but not saved 
                _db.Categories.Add(obj);

                //Saves changes to database
                _db.SaveChanges();
                //Arlet message
                TempData["success"] = "Category created successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(x => x.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot be exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                //updated to database but not saved 
                _db.Categories.Update(obj);

                //Saves changes to database
                _db.SaveChanges();

                //Arlet message
                TempData["success"] = "Category updated successfully";

                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(x => x.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            //Deleted to database but not saved 
             _db.Categories.Remove(obj);

            //Saves changes to database
             _db.SaveChanges();

            //Arlet message
            TempData["success"] = "Category deleted successfully";

            return RedirectToAction("Index");
            
        }
    }
}
