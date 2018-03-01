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
        [Route("toppopulares/{count}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetTopPopulares(int count)
        {
            try {
                IEnumerable<Place> places = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    places = unitOfWork.Places.GetTopPopulares(count);
                }

                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("topavaliados/{count}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetTopAvaliados(int count)
        {
            try {
                IEnumerable<Place> places = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    places = unitOfWork.Places.GetTopAvaliados(count);
                }

                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("topcustobeneficio/{count}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetTopCustoBeneficio(int count)
        {
            try {
                IEnumerable<Place> places = new List<Place>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    places = unitOfWork.Places.GetTopCustoBeneficio(count);
                }

                return Request.CreateResponse(HttpStatusCode.OK, places.ToList());
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
