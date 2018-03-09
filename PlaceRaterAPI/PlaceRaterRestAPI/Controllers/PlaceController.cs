using BusinessPlaceRater.BLLs;
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
        private readonly PlacesBLL placesLogic = new PlacesBLL();

        [Route("places/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetPlace(string Name, string City, string State)
        {
            try
            {
                IEnumerable<Place> placesReturn = placesLogic.GetPlace(Name, City, State);

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroInternoServidor });
            }
        }

        [Route("places/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAllPlaces()
        {
            try
            {
                IEnumerable<Place> placesReturn = placesLogic.GetAllPlaces();

                return Request.CreateResponse(HttpStatusCode.OK, placesReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroInternoServidor });
            }
        }
    }
}
