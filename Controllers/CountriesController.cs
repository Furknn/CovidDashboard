using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DashboardCovid.Models;

namespace DashboardCovid.Controllers
{
    public class CountriesController : ApiController
    {
        CovidContext context = new CovidContext();
        // GET: api/Countries
        public IEnumerable<Countries> Get()
        {
            return context.Countries.ToList();
        }

        
    }
}
