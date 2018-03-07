﻿using PlaceRaterAPI;
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
    public class UserController : ApiController
    {
        [Route("cadastro/")]
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage CadastrarUsuario([FromBody]User user)
        {
            try
            {
                User userReturn = new User();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    userReturn = unitOfWork.Users.CadastrarUsuario(user);
                    unitOfWork.Complete();
                }

                return Request.CreateResponse(HttpStatusCode.Created, userReturn);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }
        }

        [Route("login/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage LogarUsuario([FromUri]User user)
        {
            try
            {
                User userReturn = new User();
                using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
                {
                    userReturn = unitOfWork.Users.LoginUsuario(user);
                }

                return Request.CreateResponse(HttpStatusCode.OK, userReturn);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = ex.Message });
            }
        }
    }
}
