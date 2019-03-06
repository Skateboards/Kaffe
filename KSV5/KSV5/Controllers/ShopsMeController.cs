using KSV5.Models.Domain;
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
    [RoutePrefix("api/shops/me")]
    public class ShopsMeController : ApiController
    {
        ShopService _service = new ShopService();
        public ShopsMeController() { }

        [AllowAnonymous]
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetUserShops(int Id)
        {
            ItemResponse<List<Shop>> response = new ItemResponse<List<Shop>>();
            response.Item = _service.GetUserShops(Id);

            if (response.Item == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, response);
            }
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

    }
}
