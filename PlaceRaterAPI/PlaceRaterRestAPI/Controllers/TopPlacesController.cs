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
    public class TopPlacesController : ApiController
    {
        private readonly PlacesBLL placesLogic = new PlacesBLL();

        [Route("toppopulares/{count}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetTopPopulares(int count)
        {
            try {
                IEnumerable<Place> places = placesLogic.GetTopPopulares(count);
                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroInternoServidor });
            }
        }

        [Route("topavaliados/{count}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetTopAvaliados(int count)
        {
            try {
                IEnumerable<Place> places = placesLogic.GetTopAvaliados(count);
                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroInternoServidor });
            }
        }

        [Route("topcustobeneficio/{count}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetTopCustoBeneficio(int count)
        {
            try {
                IEnumerable<Place> places = placesLogic.GetTopCustoBeneficio(count);
                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroInternoServidor });
            }
        }

    }
}
