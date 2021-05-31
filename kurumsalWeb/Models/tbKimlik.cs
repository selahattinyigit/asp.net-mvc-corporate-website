namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbKimlik")]
    public partial class tbKimlik
    {
        [Key]
        public int kimlik_id { get; set; }

        [StringLength(150)]
        public string title { get; set; }

        [StringLength(250)]
        public string keyword { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        [StringLength(250)]
        public string logoUrl { get; set; }

        [StringLength(250)]
        public string unvan { get; set; }
    }
}
