using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI.Repositories.Interfaces
{
    public interface IRateRepository : IRepository<Rate>
    {
        IEnumerable<Rate> GetRatesByPlace(Place place);
        double GetPlaceAvgStars(Place place);
        double GetPlaceAvgPrice(Place place);
        int GetPlaceQtde(Place place);
        Rate PostRate(Rate rate);
        Rate DeleteRate(Rate rate);
        void ChangeRate(Rate rate);
        Rate GetRate(string Login, string City, string State, string PlaceName);
        IEnumerable<Rate> GetUserRates(string Login);
    }
}
