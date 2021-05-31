namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("iletisim")]
    public partial class iletisim
    {
        public int iletisimId { get; set; }

        [StringLength(500)]
        public string adres { get; set; }

        [StringLength(50)]
        public string telefon { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string whattsap { get; set; }

        [StringLength(50)]
        public string facebook { get; set; }

        [StringLength(50)]
        public string twiter { get; set; }

        [StringLength(50)]
        public string instagram { get; set; }
    }
}
