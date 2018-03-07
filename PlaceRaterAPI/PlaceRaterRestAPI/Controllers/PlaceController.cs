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
    public class PlaceController : ApiController
    {
        [Route("places/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetPlace(string Name, string City, string State)
        {
            try
            {
                IEnumerable<Place> placesReturn = new List<Place>();

                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    placesReturn = unitOfWork.Places.GetPlace(Name, City, State);
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("places/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAllPlaces()
        {
            try
            {
                IEnumerable<Place> placesReturn = new List<Place>();

                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    placesReturn = unitOfWork.Places.GetAll().ToList();
                }

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
