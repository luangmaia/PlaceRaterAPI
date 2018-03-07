using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlaceRaterAPI.Repositories.Interfaces;

namespace PlaceRaterAPI.Repositories
{
    public class RateRepository : Repository<Rate>, IRateRepository
    {
        public RateRepository(PlaceRaterContext context) : base(context)
        {
        }

        public double GetPlaceAvgPrice(Place place)
        {
            return ((PlaceRaterContext)Context).Rates
                .Where(r => r.Name == place.Name && r.City == place.City && r.State == place.State)
                .Average(r => r.Price);
        }

        public double GetPlaceAvgStars(Place place)
        {
            return ((PlaceRaterContext)Context).Rates
                .Where(r => r.Name == place.Name && r.City == place.City && r.State == place.State)
                .Average(r => r.Stars);
        }

        public int GetPlaceQtde(Place place)
        {
            return ((PlaceRaterContext)Context).Rates
                .Where(r => r.Name == place.Name && r.City == place.City && r.State == place.State)
                .Count();
        }

        public Rate GetRate(string Login, string City, string State, string PlaceName)
        {
            return ((PlaceRaterContext)Context).Rates
                .Where(r => r.Name == PlaceName && r.Login == Login && r.City == City && r.State == State).FirstOrDefault();
        }

        public IEnumerable<Rate> GetRatesByPlace(Place place)
        {
           return ((PlaceRaterContext)Context).Rates
                .Where(r => r.Name == place.Name && r.City == place.City && r.State == place.State)
                .OrderBy(r => r.Stars)
                .ToList();
        }

        public IEnumerable<Rate> GetUserRates(string Login)
        {
            return ((PlaceRaterContext)Context).Rates
                .Where(r => r.Login == Login)
                .OrderBy(r => r.Stars)
                .ToList();
        }

        public Rate PostRate(Rate rate)
        {
            return ((PlaceRaterContext)Context).Rates.Add(rate);
        }

        public void ChangeRate(Rate rate)
        {
            Rate rateBD = ((PlaceRaterContext)Context).Rates
                .Where(r => r.Login == rate.Login && r.Name == rate.Name && r.City == rate.City && r.State == rate.State)
                .Single();

            rateBD = rate;
        }

        public Rate DeleteRate(Rate rate)
        {
            Rate rateBD = ((PlaceRaterContext)Context).Rates
                .Where(r => r.Login == rate.Login && r.Name == rate.Name && r.City == rate.City && r.State == rate.State)
                .Single();
            return ((PlaceRaterContext)Context).Rates.Remove(rateBD);
        }
    }
}
