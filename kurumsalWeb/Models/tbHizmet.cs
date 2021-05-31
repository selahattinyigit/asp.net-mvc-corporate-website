namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbHizmet")]
    public partial class tbHizmet
    {
        [Key]
        public int hizmetId { get; set; }

        [StringLength(50)]
        public string baslik { get; set; }

        [StringLength(500)]
        public string aciklama { get; set; }

        [StringLength(500)]
        public string resimUrl { get; set; }
    }
}
