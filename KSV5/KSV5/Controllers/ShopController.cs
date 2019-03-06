using KSV5.Models.Domain;
using KSV5.Models.Requests.Shops;
using KSV5.Models.Responses;
using KSV5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KSV5.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/shops")]
    public class ShopController : ApiController
    {
        ShopService _service = new ShopService();
        public ShopController() { }

        [AllowAnonymous]
        [Route, HttpPost]
        public HttpResponseMessage Add(ShopAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            ItemResponse<int> response = new ItemResponse<int>
            {
                Item = _service.Add(model)
            };
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }

        [AllowAnonymous]
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(ShopUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, model);
            }

            _service.Update(model);
            SuccessResponse resp = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        [AllowAnonymous]
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            ItemResponse<Shop> response = new ItemResponse<Shop>();
            response.Item = _service.Get(Id);

            if (response.Item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, response);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        [AllowAnonymous]
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            _service.Delete(Id);
            SuccessResponse response = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
