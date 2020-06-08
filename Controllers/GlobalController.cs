using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DashboardCovid.Models;

namespace DashboardCovid.Controllers
{
    public class GlobalController : ApiController
    {
        CovidContext context = new CovidContext();
        // GET: api/Global
        public IEnumerable<Models.Global> Get()
        {
            return context.Global.ToList();
        }
    }
}
