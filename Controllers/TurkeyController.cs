using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DashboardCovid.Models;

namespace DashboardCovid.Controllers
{
    public class TurkeyController : ApiController
    {   CovidContext context=new CovidContext();
        // GET: api/Turkey
        public IEnumerable<Turkey> Get()
        {
            return context.Turkey.ToList();
        }

        
    }
}
