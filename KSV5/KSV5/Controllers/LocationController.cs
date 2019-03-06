using KSV5.Models.Requests;
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
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        ShopService _service = new ShopService();
        public LocationController() { }

        [Route, HttpPut]
        public HttpResponseMessage GetLocation(LocationRequest model)
        {
            WebClient client = new WebClient();
            ItemResponse<string> response = new ItemResponse<string>();
            response.Item = client.DownloadString(model.Url);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [AllowAnonymous]
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage UpdateLatLong(ShopUpdateLatLongRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, model);
            }

            _service.UpdateLatLong(model);
            SuccessResponse resp = new SuccessResponse();
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }
    }
}
