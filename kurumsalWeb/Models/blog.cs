namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("blog")]
    public partial class blog
    {
        public int blogId { get; set; }

        [StringLength(250)]
        public string baslik { get; set; }

        public string icerik { get; set; }

        [StringLength(250)]
        public string resimUrl { get; set; }
        
        public int kategoriId { get; set; }
        [ForeignKey("kategoriId")]
        public virtual tbKategori kategori { get; set; }
    }
}
