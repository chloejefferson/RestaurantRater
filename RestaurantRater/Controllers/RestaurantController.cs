using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant/Index
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        //GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Restaurant/Create
        [HttpPost, ValidateAntiForgeryToken] //Just to show this is ONLY a post because there is another create method. ValidateAntiForegeryToken-- see in the view
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");//Return to home page of Restaurant
            }

            return View(restaurant);//give model back to the view -- aka puts everything back in the form that you sent autopopulated. This would be like if you have one error and everything is still saved for you.
        }

        //GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id)//nullable int (int?)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//user didn't input an id in the url
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if(restaurant == null)
            {
                return HttpNotFound();//unable to find restaurant by id
            }
            return View(restaurant);
        }

        //POST: Restaurant/Delete/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Restaurant/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        //POST: Restaurant/Edit/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;//look through table and see if it finds a match and update its state to modified. Makes the changes save to this entry.
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);//If not valid, return back to the edit view with the restaurant that THEY entered in the edit view again.
        }
    }
}