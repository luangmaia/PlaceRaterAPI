using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PlaceRaterAPI.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(PlaceRaterContext context) : base(context)
        {
        }
        public IEnumerable<Place> GetTopPopulares(int count)
        {
            var rates = ((PlaceRaterContext) Context).Rates
                .GroupBy(r => new { Name = r.Name, State = r.State, City = r.City })
                .Select(r => new { Name = r.Key.Name, State = r.Key.State, City = r.Key.City, Qtde = r.Count() })
                .OrderByDescending(r => r.Qtde).Take(count).ToList();

            var places = new List<Place>();
            foreach (var rate in rates)
            {
                var place = ((PlaceRaterContext)Context).Places.Where(p => p.Name == rate.Name && p.State == rate.State && p.City == rate.City)/*.Include(p => p.Categories)*/.SingleOrDefault<Place>();
                places.Add(place);
            }

            return places;
        }

        public IEnumerable<Place> GetTopAvaliados(int count)
        {
            var rates = ((PlaceRaterContext)Context).Rates
                .GroupBy(r => new { Name = r.Name, State = r.State, City = r.City })
                .Select(r => new { Name = r.Key.Name, State = r.Key.State, City = r.Key.City, Stars = r.FirstOrDefault().Stars })
                .OrderByDescending(c => c.Stars).Take(count).ToList();

            var places = new List<Place>();
            foreach (var rate in rates)
            {
                var place = ((PlaceRaterContext)Context).Places.Where(p => p.Name == rate.Name && p.State == rate.State && p.City == rate.City)/*.Include(p => p.Categories)*/.SingleOrDefault<Place>();
                places.Add(place);
            }

            return places;
        }

        public IEnumerable<Place> GetTopCustoBeneficio(int count)
        {
            var rates = ((PlaceRaterContext)Context).Rates
                .GroupBy(r => new { Name = r.Name, State = r.State, City = r.City })
                .Select(r => new { Name = r.Key.Name, State = r.Key.State, City = r.Key.City, Price = r.FirstOrDefault().Price })
                .OrderByDescending(c => c.Price).Take(count).ToList();

            var places = new List<Place>();
            foreach (var rate in rates)
            {
                var place = ((PlaceRaterContext)Context).Places.Where(p => p.Name == rate.Name && p.State == rate.State && p.City == rate.City)/*.Include(p => p.Categories)*/.SingleOrDefault<Place>();
                places.Add(place);
            }

            return places;
        }
    }
}
