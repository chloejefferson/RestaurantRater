using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");//Return to home page of Restaurant
            }

            return View(restaurant);//give model back to the view -- aka puts everything back in the form that you sent autopopulated. This would be like if you have one error and everything is still saved for you.
        }
    }
}