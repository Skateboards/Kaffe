using KSV5.Models.Requests.Consumer;
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
    [RoutePrefix("api/consumers")]
    public class ConsumerController : BaseApiController
    {
        //ConsumerService _service = null;
        //public ConsumerController(ConsumerService service)
        //{
        //    _service = service;
        //}

        //[Route, HttpPost]
        //public HttpResponseMessage Add(ConsumerAddRequest model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        CreateErrorResponse();
        //    }
        //    ItemResponse<int> response = new ItemResponse<int>
        //    {
        //        Item = _service.Add(model)
        //    };
        //    return Request.CreateResponse(HttpStatusCode.Created, response);
        //}

        //[Route("{id:int}"), HttpPut]
        //public HttpResponseMessage Update(ConsumerUpdateRequest model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        CreateErrorResponse();
        //    }
        //    _service.Update(model);
        //    SuccessResponse response = new SuccessResponse();
        //    return Request.CreateResponse(HttpStatusCode.OK, response);
        //}

        //[Route("{email:string}"), HttpGet]
        //public HttpResponseMessage Get(string email)
        //{
        //    ItemResponse<Consumer> response = new ItemResponse<Consumer>();
        //    response.Item = _service.Get(email);

        //    if (response.Item == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, response);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, response);
        //}
    }
}
