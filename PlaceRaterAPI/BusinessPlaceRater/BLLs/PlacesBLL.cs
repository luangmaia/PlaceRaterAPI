using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlaceRater.BLLs
{
    public class PlacesBLL
    {
        private readonly int pageSize = 5;

        public IEnumerable<Place> SearchByNameCityStateFiltered(string busca, string categoria = null, int starfilter = 1, int pricefilter = 5)
        {
            List<Place> placesReturn = new List<Place>();

            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                IEnumerable<Place> places = new List<Place>();

                if (categoria != null)
                {
                    if (busca == null || busca.Length == 0)
                    {
                        places = unitOfWork.Places.GetAllFiltered(categoria);
                    }
                    else
                    {
                        places = unitOfWork.Places.SearchByNameCityStateCategory(busca, categoria);
                    }
                }
                else
                {
                    if (busca == null || busca.Length == 0)
                    {
                        places = unitOfWork.Places.GetAll();
                    }
                    else
                    {
                        places = unitOfWork.Places.SearchByNameCityState(busca);
                    }
                }

                foreach (Place place in places)
                {
                    if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= starfilter && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= pricefilter)
                    {
                        placesReturn.Add(place);
                    }
                }
            }

            return placesReturn;
        }

        public IEnumerable<Place> SearchByNameCityStateFilteredPagination(string busca, int page, string categoria = null, int starfilter = 1, int pricefilter = 5)
        {
            List<Place> placesReturn = new List<Place>();

            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                IEnumerable<Place> places = new List<Place>();

                if (categoria != null)
                {
                    if (busca == null || busca.Length == 0)
                    {
                        places = unitOfWork.Places.GetAllPaginationFiltered(page, pageSize, categoria);
                    }
                    else
                    {
                        places = unitOfWork.Places.SearchByNameCityStateCategoryPagination(busca, page, pageSize, categoria);
                    }
                }
                else
                {
                    if (busca == null || busca.Length == 0)
                    {
                        places = unitOfWork.Places.GetAllPagination(page, pageSize);
                    }
                    else
                    {
                        places = unitOfWork.Places.SearchByNameCityStatePagination(busca, page, pageSize);
                    }
                }

                foreach (Place place in places)
                {
                    if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= starfilter && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= pricefilter)
                    {
                        placesReturn.Add(place);
                    }
                }
            }

            return placesReturn;
        }

        public int GetQuantidade(IEnumerable<Place> places)
        {
            return (int)Math.Ceiling(places.Count() / (decimal)pageSize);
        }

        public IEnumerable<Place> GetTopPopulares(int count)
        {
            IEnumerable<Place> places = new List<Place>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                places = unitOfWork.Places.GetTopPopulares(count);
            }

            return places.ToList();
        }

        public IEnumerable<Place> GetTopAvaliados(int count)
        {
            IEnumerable<Place> places = new List<Place>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                places = unitOfWork.Places.GetTopAvaliados(count);
            }

            return places.ToList();
        }

        public IEnumerable<Place> GetTopCustoBeneficio(int count)
        {
            IEnumerable<Place> places = new List<Place>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                places = unitOfWork.Places.GetTopCustoBeneficio(count);
            }

            return places.ToList();
        }

        public IEnumerable<Place> GetPlace(string Name, string City, string State)
        {
            IEnumerable<Place> placesReturn = new List<Place>();

            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                placesReturn = unitOfWork.Places.GetPlace(Name, City, State);
            }

            return placesReturn;
        }

        public IEnumerable<Place> GetAllPlaces()
        {
            IEnumerable<Place> placesReturn = new List<Place>();

            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                placesReturn = unitOfWork.Places.GetAll().ToList();
            }

            return placesReturn;
        }
    }
}
