namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbAdmin")]
    public partial class tbAdmin
    {
        [Key]
        public int adminID { get; set; }

        [StringLength(50)]
        public string adminPosta { get; set; }

        [StringLength(50)]
        public string adminSifre { get; set; }

        [StringLength(50)]
        public string adminYetki { get; set; }
    }
}
