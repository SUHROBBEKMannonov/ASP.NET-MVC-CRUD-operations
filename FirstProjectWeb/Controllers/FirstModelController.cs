
using FirstProjectWeb.Data;
using FirstProjectWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjectWeb.Controllers;

    public class FirstModelController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FirstModelController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult ListOfUsers()
        {
            
            IEnumerable<FirstModel> objFirstModelList = _db.DataUsers;
            return View(objFirstModelList);
        }
    [HttpGet]    
    public ViewResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
     public IActionResult Create( FirstModel obj)
    {
        if(obj.FirstName == obj.LastName)

        {
            ModelState.AddModelError("CustomError", "The Birth of date cannot be over 3000 year");
        }
        if (obj.BirthDate.Year > 3000)
        {
            ModelState.AddModelError("CustomError", "The Birth of date cannot be over 3000 year");
        }
        if (ModelState.IsValid)
        {

            _db.DataUsers.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "User created successfully!!!";
            return RedirectToAction("ListOfUsers");
        }
        return View();

    }

    ////////////____UPDATE____/////////////////


    public IActionResult Edit(int?  id)
    {
        if (id== 0 || id == null)
        {
            return NotFound();
        } 

        var firstmodelFromDb= _db.DataUsers.Find(id);

        if (firstmodelFromDb == null) { return NotFound(); }

        return View(firstmodelFromDb);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(FirstModel obj)
    {
        if (obj.FirstName == obj.LastName)

        {
            ModelState.AddModelError("CustomError", "The Birth of date cannot be over 3000 year");
        }
        
        if (ModelState.IsValid)
        {

            _db.DataUsers.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "User updated successfully!!!";
            return RedirectToAction("ListOfUsers");
        }
        return View();

    }
    ////////////_________delete____________/////////////////
    ///
    public IActionResult Delete(int? id)
    {
        if (id == 0 || id == null)
        {
            return NotFound();
        }

        var firstmodelFromDb = _db.DataUsers.Find(id);

        if (firstmodelFromDb == null) { return NotFound(); }

        return View(firstmodelFromDb);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int id)
    {
        var obj = _db.DataUsers.Find(id);

        if (obj == null) { return NotFound(); }

        _db.DataUsers.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "User deleted successfully!!!";
        return RedirectToAction("ListOfUsers");
        
        
    }
    }
