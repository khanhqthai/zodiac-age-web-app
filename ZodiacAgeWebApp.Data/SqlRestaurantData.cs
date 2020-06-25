using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using ZodiacAgeWebApp.Core;

namespace ZodiacAgeWebApp.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly ZodiacAgeDbContext db;

        public SqlRestaurantData(ZodiacAgeDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            // dbcontext will know that you are adding a Restaurant object, and will map the data to the correct table in the database
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            // a success SaveChanges returns an integer representing the number of rows affected by the changes
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant !=null) 
            {
                db.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = db.Restaurants.Where(r=> r.Name.StartsWith(name) || string.IsNullOrEmpty(name) )
                                    .OrderBy(r => r.Name);
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
