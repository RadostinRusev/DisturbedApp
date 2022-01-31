using API.Messages;
using AppsService.DTOs;
using AppsService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/Users")]
    public class UserController : BaseController
    {
        private readonly UserManagmentService  _service = null;
        public UserController()
        {
            _service = new UserManagmentService();
        }
        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Json(_service.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Json(_service.GetById(id));
        }
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(UserDTO userDTO)
        {
            ResposnseMessage response = new ResposnseMessage();
            if (_service.Save(userDTO))
            {
                response.Code = 201;
                response.Body = "succ";
            }
            return Json(response);

        }
        [HttpDelete]
        [Route("")]
        public IHttpActionResult Delete(int id)
        {
            ResposnseMessage response = new ResposnseMessage();
            if (_service.Delete(id))
            {
                response.Code = 200;
                response.Body = "succ del";
            }

            return Json(response);

        }
        [HttpPatch]
        [Route("{id}")]
        public IHttpActionResult Edit(int ra,UserDTO userDTO)
        {
            ResposnseMessage response = new ResposnseMessage();
            if (_service.Edit(ra,userDTO))
            {
                response.Code = 201;
                response.Body = "succ";
            }

            return Json(response);

        }
    }

}

