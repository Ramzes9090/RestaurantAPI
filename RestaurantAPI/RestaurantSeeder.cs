using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast food",
                    Description = "Somethig, something",
                    ContactEmail = "contact@gmail.com",
                    HasDelivey = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Chicen Nuggets",
                            Price = 10M,
                        },
                        new Dish()
                        {
                            Name = "Longer",
                            Price = 15.5M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 6",
                        PostalCode= "13-111",
                    }
                }

            };
            return restaurants;

        }
    }
}
