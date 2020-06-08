namespace DashboardCovid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Countries
    {
        [StringLength(50)]
        public string Country { get; set; }

        [Key]
        [StringLength(50)]
        public string CountryCode { get; set; }

        [StringLength(50)]
        public string Slug { get; set; }

        public long? NewConfirmed { get; set; }

        public long? TotalConfirmed { get; set; }

        public long? NewDeaths { get; set; }

        public long? TotalDeaths { get; set; }

        public long? NewRecovered { get; set; }

        public long? TotalRecovered { get; set; }

        [StringLength(50)]
        public string date { get; set; }
    }
}
