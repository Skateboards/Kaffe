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
    [RoutePrefix("api/scraper")]
    public class ScraperController : ApiController
    {
        ScraperService _service = new ScraperService();
        public ScraperController()
        {
        }

        [Route, HttpGet]
        public HttpResponseMessage Get()
        {
            ItemResponse<List<SprudgeScrape>> responseBody = new ItemResponse<List<SprudgeScrape>>();
            responseBody.Item = _service.Scraper();

            if (responseBody == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, responseBody);
            }
            return Request.CreateResponse(HttpStatusCode.OK, responseBody);
        }
    }
}
