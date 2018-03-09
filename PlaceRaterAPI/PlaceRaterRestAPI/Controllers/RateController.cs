using BusinessPlaceRater.BLLs;
using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using PlaceRaterAPI.Validators;
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
        private readonly RatesBLL ratesLogic = new RatesBLL();

        [Route("avgStarsPlace/{name}/{city}/{state}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAvgStarsPlace(string name, string city, string state)
        {
            try
            {
                double avg = ratesLogic.GetAvgStarsPlace(name, city, state);

                var retorno = new { avg = avg };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("avgPricePlace/{name}/{city}/{state}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAvgPricePlace(string name, string city, string state)
        {
            try
            {
                double avg = ratesLogic.GetAvgPricePlace(name, city, state);

                var retorno = new { avg = avg };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("qtdeRatePlace/{name}/{city}/{state}")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetQtdePlace(string name, string city, string state)
        {
            try
            {
                int qtde = ratesLogic.GetQtdePlace(name, city, state);

                var retorno = new { qtde = qtde };

                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("rates/")]
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage PostRate([FromBody]Rate rate)
        {
            try
            {
                if (!RateValidator.isValid(rate))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroAvaliacaoInvalida);
                }

                Rate rateReturn = ratesLogic.PostRate(rate);

                return Request.CreateResponse(HttpStatusCode.Created, rateReturn);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("rates/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetRate(string Login, string City, string State, string Name)
        {
            try
            {
                Rate rate = ratesLogic.GetRate(Login, City, State, Name);

                if (rate == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, ErrorMessages.erroAvaliacaoNaoEncontrada);
                }

                return Request.CreateResponse(HttpStatusCode.OK, rate);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("rates/")]
        [HttpDelete]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteRate([FromUri]Rate rate)
        {
            try
            {
                Rate rateReturn = ratesLogic.DeleteRate(rate);

                return Request.CreateResponse(HttpStatusCode.OK, rateReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("rates/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetUserRates(string Login)
        {
            try
            {
                IEnumerable<Rate> rates = ratesLogic.GetUserRates(Login);

                return Request.CreateResponse(HttpStatusCode.OK, rates);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("rates/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetRates()
        {
            try
            {
                IEnumerable<Rate> rates = ratesLogic.GetRates();

                return Request.CreateResponse(HttpStatusCode.OK, rates);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }

        [Route("rates/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetRatesByPlace(string City, string State, string Name)
        {
            try
            {
                IEnumerable<Rate> rates = ratesLogic.GetRatesByPlace(City, State, Name);

                return Request.CreateResponse(HttpStatusCode.OK, rates);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }
    }
}
