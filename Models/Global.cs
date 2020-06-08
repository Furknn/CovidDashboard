namespace DashboardCovid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Global")]
    public partial class Global
    {
        public byte Id { get; set; }

        public long? NewConfirmed { get; set; }

        public long? TotalConfirmed { get; set; }

        public long? NewDeaths { get; set; }

        public long? TotalDeaths { get; set; }

        public long? NewRecovered { get; set; }

        public long? TotalRecovered { get; set; }
    }
}
