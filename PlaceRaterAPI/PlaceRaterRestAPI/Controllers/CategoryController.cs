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
    public class CategoryController : ApiController
    {
        private readonly CategoriesBLL categoriesLogic = new CategoriesBLL();

        [Route("categorias/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage GetAllCategories()
        {
            try
            {
                IEnumerable<Category> categories = categoriesLogic.GetAllCategories();

                return Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorMessages.erroInternoServidor);
            }
        }
    }
}
