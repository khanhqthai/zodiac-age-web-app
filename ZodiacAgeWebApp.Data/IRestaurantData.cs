using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ZodiacAgeWebApp.Core;

namespace ZodiacAgeWebApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName( string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int Commit();
    }

}
