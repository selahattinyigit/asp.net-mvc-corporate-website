namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbSlider")]
    public partial class tbSlider
    {
        [Key]
        public int sliderId { get; set; }

        [StringLength(30)]
        public string baslik { get; set; }

        [StringLength(250)]
        public string icerik { get; set; }

        [StringLength(100)]
        public string resimUrl { get; set; }
    }
}
