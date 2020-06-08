using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using DashboardCovid.Models;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DashboardCovid.Diger
{
    public class Update
    {
        public static void updateAll()
        {
            try
            {
                CovidContext db = new CovidContext();
                //covid19api.com sitesine istek yolla
                var client = new RestClient("https://api.covid19api.com/summary");
                var clientTurkey = new RestClient("https://api.covid19api.com/country/turkey");
                var request = new RestRequest(Method.GET);
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                var queryResult = client.Execute(request);
                var queryResultTurkey = clientTurkey.Execute(request);
                //Cevabı Json objesine çevir
                var jObject = JObject.Parse(queryResult.Content);
                //Cevabı Json dizisine cevir
                var jObjectTurkey = JArray.Parse(queryResultTurkey.Content);
                var Countries = jObject.GetValue("Countries");
                var Global = jObject.GetValue("Global");

                //Countries Tablosunu Doldur/Güncelle
                foreach (var country in Countries)
                {
                    db.Countries.AddOrUpdate(new Models.Countries() { Country = country["Country"].ToString(), CountryCode = country["CountryCode"].ToString(), NewConfirmed = Int64.Parse(country["NewConfirmed"].ToString()), NewDeaths = Int64.Parse(country["NewDeaths"].ToString()), NewRecovered = Int64.Parse(country["NewRecovered"].ToString()), Slug = country["Slug"].ToString(), TotalConfirmed = Int64.Parse(country["TotalConfirmed"].ToString()), TotalDeaths = Int64.Parse(country["TotalDeaths"].ToString()), TotalRecovered = Int64.Parse(country["TotalRecovered"].ToString()), date = country["Date"].ToString() });
                }
                //Turkey Tablosunu Doldur/Güncelle
                foreach (var data in jObjectTurkey)
                {
                    db.Turkey.AddOrUpdate(new Models.Turkey() { CountryCode = data["CountryCode"].ToString(), Active = Int64.Parse(data["Active"].ToString()), Confirmed = Int64.Parse(data["Confirmed"].ToString()), Date = DateTime.Parse(data["Date"].ToString()), Deaths = Int64.Parse(data["Deaths"].ToString()), Recovered = Int64.Parse(data["Recovered"].ToString()) });
                }
                //Global Tablosunun Doldur/Güncelle
                db.Global.AddOrUpdate(new Models.Global() { Id = 1, NewConfirmed = Int64.Parse(Global["NewConfirmed"].ToString()), NewDeaths = Int64.Parse(Global["NewDeaths"].ToString()), NewRecovered = Int64.Parse(Global["NewRecovered"].ToString()), TotalConfirmed = Int64.Parse(Global["TotalConfirmed"].ToString()), TotalDeaths = Int64.Parse(Global["TotalDeaths"].ToString()), TotalRecovered = Int64.Parse(Global["TotalRecovered"].ToString()) });

                db.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }
            
        }
    }
}