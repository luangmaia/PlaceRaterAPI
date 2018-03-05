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

        public IEnumerable<Rate> GetRatesByPlace(Place place)
        {
           return ((PlaceRaterContext)Context).Rates
                .Where(r => r.Name == place.Name && r.City == place.City && r.State == place.State).ToList();
        }
    }
}
