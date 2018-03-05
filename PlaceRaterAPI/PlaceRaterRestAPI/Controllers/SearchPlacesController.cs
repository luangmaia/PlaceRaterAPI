using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PlaceRaterRestAPI.Controllers
{
    public class SearchPlacesController : ApiController
    {
        private readonly int pageSize = 2;

        /*[Route("procurarLugares/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityState(string busca)
        {
            try
            {
                IEnumerable<Place> places = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    places = unitOfWork.Places.SearchByNameCityState(busca);
                }

                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            } catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }*/

        [Route("procurarLugares/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateFiltered(string busca, string categoria = null, int starfilter = 1, int pricefilter = 5, bool qtdepaginas = false)
        {
            try
            {
                List<Place> placesReturn = new List<Place>();

                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    IEnumerable<Place> places = new List<Place>();

                    if (categoria != null)
                    {
                        places = unitOfWork.Places.SearchByNameCityStateCategory(busca, categoria);
                    } else
                    {
                        places = unitOfWork.Places.SearchByNameCityState(busca);
                    }

                    foreach (Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= starfilter && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= pricefilter)
                        {
                            placesReturn.Add(place);
                        }
                    }
                }

                if (qtdepaginas == true)
                {
                    int qtde = (int)Math.Ceiling(placesReturn.Count() / (decimal)pageSize);
                    return Request.CreateResponse(HttpStatusCode.OK, new { qtde = qtde });
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugares/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateFilteredPagination(string busca, int page, string categoria = null, int starfilter = 1, int pricefilter = 5)
        {
            try
            {
                List<Place> placesReturn = new List<Place>();

                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    IEnumerable<Place> places = new List<Place>();

                    if (categoria != null)
                    {
                        places = unitOfWork.Places.SearchByNameCityStateCategoryPagination(busca, page, pageSize, categoria);
                    }
                    else
                    {
                        places = unitOfWork.Places.SearchByNameCityStatePagination(busca, page, pageSize);
                    }

                    foreach (Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= starfilter && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= pricefilter)
                        {
                            placesReturn.Add(place);
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("categorias/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAllCategories()
        {
            try
            {
                IEnumerable<Category> categories = new List<Category>();

                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    categories = unitOfWork.Categories.GetAll();
                }

                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /*[Route("procurarLugares/{page}/{busca}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStatePagination(int page, string busca)
        {
            try
            {
                IEnumerable<Place> places = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    places = unitOfWork.Places.SearchByNameCityStatePagination(busca, page, pageSize);
                }

                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugares/{busca}/qtdepaginas")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateQtde(string busca)
        {
            try
            {
                int qtde = 0;
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    qtde = (int) Math.Ceiling(unitOfWork.Places.SearchByNameCityState(busca).Count()/(decimal)pageSize);
                }

                var retorno = new { qtde = qtde };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugaresFiltrado/{busca}/{categoria}/{stars?}/{price?}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateCategory(string busca, string categoria, int stars = 1, int price = 5)
        {
            try
            {
                List<Place> placesReturn = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    IEnumerable<Place> places = unitOfWork.Places.SearchByNameCityStateCategory(busca, categoria);

                    foreach(Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= stars && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= price)
                        {
                            placesReturn.Add(place);
                        } 
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugaresFiltrado/{page}/{busca}/{categoria}/{stars?}/{price?}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateCategoryPagination(int page, string busca, string categoria, int stars = 1, int price = 5)
        {
            try
            {
                List<Place> placesReturn = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    IEnumerable<Place> places = unitOfWork.Places
                        .SearchByNameCityStateCategoryPagination(busca, page, pageSize, categoria);

                    foreach (Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= stars && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= price)
                        {
                            placesReturn.Add(place);
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugaresFiltrado/{busca}/{categoria}/{stars?}/{price?}/qtdepaginas")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateCategoryQtde(string busca, string categoria, int stars = 1, int price = 5)
        {
            try
            {
                int qtde = 0;
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    List<Place> placesReturn = new List<Place>();
                    IEnumerable<Place> places = unitOfWork.Places
                        .SearchByNameCityStateCategory(busca, categoria);

                    foreach (Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= stars && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= price)
                        {
                            placesReturn.Add(place);
                        }
                    }

                    qtde = (int)Math.Ceiling(placesReturn.Count() / (decimal)pageSize);
                }

                var retorno = new { qtde = qtde };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }






        [Route("procurarLugaresFiltradoSemCategoria/{busca}/{stars?}/{price?}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateStarsPrice(string busca, int stars = 1, int price = 5)
        {
            try
            {
                List<Place> placesReturn = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    IEnumerable<Place> places = unitOfWork.Places.SearchByNameCityState(busca);

                    foreach (Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= stars && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= price)
                        {
                            placesReturn.Add(place);
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugaresFiltradoSemCategoria/{page}/{busca}/{stars?}/{price?}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateStarsPricePagination(int page, string busca, int stars = 1, int price = 5)
        {
            try
            {
                List<Place> placesReturn = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    IEnumerable<Place> places = unitOfWork.Places
                        .SearchByNameCityStatePagination(busca, page, pageSize);

                    foreach (Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= stars && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= price)
                        {
                            placesReturn.Add(place);
                        }
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugaresFiltradoSemCategoria/{busca}/{stars?}/{price?}/qtdepaginas")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateStarsPriceQtde(string busca, int stars = 1, int price = 5)
        {
            try
            {
                int qtde = 0;
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    List<Place> placesReturn = new List<Place>();
                    IEnumerable<Place> places = unitOfWork.Places
                        .SearchByNameCityState(busca);

                    foreach (Place place in places)
                    {
                        if (Math.Ceiling(unitOfWork.Rates.GetPlaceAvgStars(place)) >= stars && Math.Ceiling(unitOfWork.Rates.GetPlaceAvgPrice(place)) <= price)
                        {
                            placesReturn.Add(place);
                        }
                    }

                    qtde = (int)Math.Ceiling(placesReturn.Count() / (decimal)pageSize);
                }

                var retorno = new { qtde = qtde };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }*/
    }
}
