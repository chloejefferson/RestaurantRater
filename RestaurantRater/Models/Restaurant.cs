using System;
using System.Collections.Generic;
using System.Data.Entity; //entities are models that get stored in the database ex. Restaurant
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
    }
    //Below we will create our own DbContext instead of using the one created for us
    public class RestaurantDbContext : DbContext //Using system.data.entity Just use basic DbContext not the applicationDbContext in the identity model.
    {
        public DbSet<Restaurant> Restaurants { get; set; } //collection of restaurant objects in db
    }
}