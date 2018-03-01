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
        [Route("procurarLugares/{busca}")]
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
            } catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("procurarLugares/{busca}/qtde")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage SearchByNameCityStateQtde(string busca)
        {
            try
            {
                int qtde = 0;
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    qtde = unitOfWork.Places.SearchByNameCityState(busca).Count();
                }

                return Request.CreateResponse(HttpStatusCode.OK, qtde);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
