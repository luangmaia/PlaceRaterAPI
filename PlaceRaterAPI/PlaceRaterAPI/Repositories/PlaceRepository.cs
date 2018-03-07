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
                var place = ((PlaceRaterContext)Context).Places.Where(p => p.Name == rate.Name && p.State == rate.State && p.City == rate.City).Include(p => p.Images).SingleOrDefault<Place>();
                places.Add(place);
            }

            return places;
        }

        public IEnumerable<Place> GetTopAvaliados(int count)
        {
            var rates = ((PlaceRaterContext)Context).Rates
                .GroupBy(r => new { Name = r.Name, State = r.State, City = r.City })
                .Select(r => new { Name = r.Key.Name, State = r.Key.State, City = r.Key.City, Stars = r.Average(a => a.Stars) })
                .OrderByDescending(c => c.Stars).Take(count).ToList();

            var places = new List<Place>();
            foreach (var rate in rates)
            {
                var place = ((PlaceRaterContext)Context).Places.Where(p => p.Name == rate.Name && p.State == rate.State && p.City == rate.City).Include(p => p.Images).SingleOrDefault<Place>();
                places.Add(place);
            }

            return places;
        }

        public IEnumerable<Place> GetTopCustoBeneficio(int count)
        {
            var rates = ((PlaceRaterContext)Context).Rates
                .GroupBy(r => new { Name = r.Name, State = r.State, City = r.City })
                .Select(r => new { Name = r.Key.Name, State = r.Key.State, City = r.Key.City, Price = r.Average(a => a.Price) })
                .OrderBy(c => c.Price).Take(count).ToList();

            var places = new List<Place>();
            foreach (var rate in rates)
            {
                var place = ((PlaceRaterContext)Context).Places.Where(p => p.Name == rate.Name && p.State == rate.State && p.City == rate.City).Include(p => p.Images).SingleOrDefault<Place>();
                places.Add(place);
            }

            return places;
        }

        public IEnumerable<Place> SearchByName(string name)
        {
            var places = ((PlaceRaterContext)Context).Places
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .ToList();

            foreach (Place place in places)
            {
                foreach (Category category in place.Categories)
                {
                    category.Places = null;
                }
            }

            return places;
        }

        public IEnumerable<Place> SearchByCityState(string city)
        {
            var places = ((PlaceRaterContext)Context).Places
                .Where(p => p.City.ToLower().Contains(city.ToLower()) || p.State.ToLower().Contains(city.ToLower()))
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .ToList();

            foreach (Place place in places)
            {
                foreach (Category category in place.Categories)
                {
                    category.Places = null;
                }
            }

            return places;
        }

        public IEnumerable<Place> SearchByNameCityState(string str)
        {
            var strLower = str.ToLower();
            var places = ((PlaceRaterContext)Context).Places
                .Where(p => p.City.ToLower().Contains(strLower) || p.State.ToLower().Contains(strLower) || p.Name.ToLower().Contains(strLower))
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .ToList();

            foreach(Place place in places)
            {
                foreach(Category category in place.Categories)
                {
                    category.Places = null;
                }
            }

            return places;
        }

        public IEnumerable<Place> SearchByNameCityStatePagination(string str, int page, int pageSize)
        {
            var strLower = str.ToLower();
            var places = ((PlaceRaterContext)Context).Places
                .Where(p => p.City.ToLower().Contains(strLower) || p.State.ToLower().Contains(strLower) || p.Name.ToLower().Contains(strLower))
                .OrderBy(p => p.Name)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .ToList();

            foreach (Place place in places)
            {
                foreach (Category category in place.Categories)
                {
                    category.Places = null;
                }
            }

            return places;
        }

        public IEnumerable<Place> SearchByNameCityStateCategoryPagination(string str, int page, int pageSize, string categoria)
        {
            var strLower = str.ToLower();
            var places = ((PlaceRaterContext)Context).Places
                .Where(p => p.City.ToLower().Contains(strLower) || p.State.ToLower().Contains(strLower) || p.Name.ToLower().Contains(strLower))
                .Where(p => p.Categories.Any(c => c.Name == categoria))
                .OrderBy(p => p.Name)
                .Skip((page - 1) * pageSize).Take(pageSize)
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .ToList();

            foreach (Place place in places)
            {
                foreach (Category category in place.Categories)
                {
                    category.Places = null;
                }
            }

            return places;
        }

        public IEnumerable<Place> SearchByNameCityStateCategory(string str, string categoria)
        {
            var strLower = str.ToLower();
            var places = ((PlaceRaterContext)Context).Places
                .Where(p => p.City.ToLower().Contains(strLower) || p.State.ToLower().Contains(strLower) || p.Name.ToLower().Contains(strLower))
                .Where(p => p.Categories.Any(c => c.Name == categoria))
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .ToList();

            foreach (Place place in places)
            {
                foreach (Category category in place.Categories)
                {
                    category.Places = null;
                }
            }

            return places;
        }

        public IEnumerable<Place> GetPlace(string name, string city, string state)
        {
            var places = ((PlaceRaterContext)Context).Places
                .Where(p => p.City.Equals(city) && p.State.Equals(state) && p.Name.Equals(name))
                .Include(p => p.Images)
                .Include(p => p.Categories)
                .ToList();

            foreach (Place place in places)
            {
                foreach (Category category in place.Categories)
                {
                    category.Places = null;
                }
            }

            return places;
        }
    }
}
