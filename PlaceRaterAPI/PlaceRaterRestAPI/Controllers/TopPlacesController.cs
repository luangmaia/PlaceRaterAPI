using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceRaterRestAPI.Controllers
{
    public class TopPlacesController : ApiController
    {
        [Route("toppopulares/{count}")]
        [HttpGet]
        public IEnumerable<Place> GetTopPopulares(int count)
        {
            IEnumerable<Place> places = new List<Place>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                places = unitOfWork.Places.GetTopPopulares(count);
            }

            return places.ToList();
        }

        [Route("topavaliados/{count}")]
        [HttpGet]
        public IEnumerable<Place> GetTopAvaliados(int count)
        {
            IEnumerable<Place> places = new List<Place>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                places = unitOfWork.Places.GetTopAvaliados(count);
            }

            return places.ToList();
        }

        [Route("topcustobeneficio/{count}")]
        [HttpGet]
        public IEnumerable<Place> GetTopCustoBeneficio(int count)
        {
            IEnumerable<Place> places = new List<Place>();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                places = unitOfWork.Places.GetTopCustoBeneficio(count);
            }

            return places.ToList();
        }

    }
}
