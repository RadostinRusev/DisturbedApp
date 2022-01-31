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
    [RoutePrefix("api/PlayLists")]
    public class PlayListController : ApiController
    {
        private readonly PlayListManagmentService _service = null;
        public PlayListController()
        {
            _service = new PlayListManagmentService();
        }
    [Authorize]
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
            return Json(_service.Get());
        }
      
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(PlayListDTO playListDTO)
        {
            ResposnseMessage response = new ResposnseMessage();
            if (_service.Save(playListDTO))
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
    }
}
