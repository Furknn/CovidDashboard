namespace DashboardCovid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Turkey")]
    public partial class Turkey
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [StringLength(10)]
        public string CountryCode { get; set; }

        public long? Confirmed { get; set; }

        public long? Deaths { get; set; }

        public long? Recovered { get; set; }

        public long? Active { get; set; }
    }
}
