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
    public class CategoryController : ApiController
    {
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
    }
}
