using KaffeSolution.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KaffeSolution.Web.Controllers.Api
{
    [RoutePrefix("api/kaffe")]
    public class KaffeController : ApiController
    {
        readonly KaffeService kaffeService = new KaffeService();

        [HttpGet, Route]
        public List<KaffeModel> GetAll()
        {
            return kaffeService.GetAll();
        }
    }
}
