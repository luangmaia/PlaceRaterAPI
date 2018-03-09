using BusinessPlaceRater.BLLs;
using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using PlaceRaterAPI.Validators;
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
        private readonly UsersBLL userLogic = new UsersBLL();

        [Route("cadastro/")]
        [HttpPost]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage CadastrarUsuario([FromBody]User user)
        {
            try
            {
                if (!UserValidator.isValidCadastro(user))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroCamposVaziosInvalidos });
                }

                user.HashPass = UserValidator.sha256_hash(user.HashPass);

                if (userLogic.existeUsuario(user))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = ErrorMessages.erroUsuarioJaExistente });
                }

                User userReturn = userLogic.CadastrarUsuario(user);

                return Request.CreateResponse(HttpStatusCode.Created, userReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroInternoServidor });
            }
        }

        [Route("login/")]
        [HttpGet]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
        public HttpResponseMessage LogarUsuario([FromUri]User user)
        {
            try
            {
                if (!UserValidator.isValidLogin(user))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ErrorMessages.erroCamposVaziosInvalidos });
                }

                user.HashPass = UserValidator.sha256_hash(user.HashPass);

                if (!userLogic.existeUsuario(user))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = ErrorMessages.erroUsuarioNaoExistente });
                }

                User userReturn = userLogic.LogarUsuario(user);

                return Request.CreateResponse(HttpStatusCode.OK, userReturn);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = ErrorMessages.erroInternoServidor });
            }
        }
    }
}
