using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PlaceRaterRestAPI.Controllers
{
    public class RateController : ApiController
    {
        [Route("avgStarsPlace/{name}/{city}/{state}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAvgStarsPlace(string name, string city, string state)
        {
            try
            {
                double avg = 0;
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    avg = unitOfWork.Rates.GetPlaceAvgStars(new Place() { Name = name, City = city, State = state } );
                }

                var retorno = new { avg = avg };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("avgPricePlace/{name}/{city}/{state}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAvgPricePlace(string name, string city, string state)
        {
            try
            {
                double avg = 0;
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    avg = unitOfWork.Rates.GetPlaceAvgPrice(new Place() { Name = name, City = city, State = state });
                }

                var retorno = new { avg = avg };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("qtdeRatePlace/{name}/{city}/{state}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetQtdePlace(string name, string city, string state)
        {
            try
            {
                int qtde = 0;
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    qtde = unitOfWork.Rates.GetPlaceQtde(new Place() { Name = name, City = city, State = state });
                }

                var retorno = new { qtde = qtde };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("postrate/")]
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage PostRate([FromBody]Rate rate)
        {
            try
            {
                Rate rateReturn = new Rate();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    rateReturn = unitOfWork.Rates.PostRate(rate);
                    unitOfWork.Complete();
                }

                return Request.CreateResponse(HttpStatusCode.Created, rateReturn);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("rates/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetRate(string Login, string City, string State, string PlaceName)
        {
            try
            {
                Rate rate = new Rate();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    rate = unitOfWork.Rates.GetRate(Login, City, State, PlaceName);
                }

                return Request.CreateResponse(HttpStatusCode.OK, rate);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("rates/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetUserRates(string Login)
        {
            try
            {
                IEnumerable<Rate> rates = new List<Rate>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    rates = unitOfWork.Rates.GetUserRates(Login);
                }

                return Request.CreateResponse(HttpStatusCode.OK, rates);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("rates/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetRates()
        {
            try
            {
                IEnumerable<Rate> rates = new List<Rate>();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    rates = unitOfWork.Rates.GetAll();
                }

                return Request.CreateResponse(HttpStatusCode.OK, rates);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
