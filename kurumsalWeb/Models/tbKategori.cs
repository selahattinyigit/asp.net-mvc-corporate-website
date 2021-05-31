namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbKategori")]
    public partial class tbKategori
    {
        [Key]
        public int kategoriId { get; set; }

        [StringLength(50)]
        public string kategoriAd { get; set; }

        [StringLength(500)]
        public string aciklama { get; set; }
    }
}
