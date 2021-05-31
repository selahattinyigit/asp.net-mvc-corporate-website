namespace kurumsalWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tbHakkimizda")]
    public partial class tbHakkimizda
    {
        [Key]
        public int hakkimizdaId { get; set; }

        public string aciklama { get; set; }
    }
}
