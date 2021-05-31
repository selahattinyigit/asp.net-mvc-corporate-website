namespace kurumsalWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogDb : DbContext
    {
        public BlogDb()
            : base("name=Models")
        {
        }

        public virtual DbSet<blog> blog { get; set; }
        public virtual DbSet<iletisim> iletisim { get; set; }
        public virtual DbSet<tbAdmin> tbAdmin { get; set; }
        public virtual DbSet<tbHakkimizda> tbHakkimizda { get; set; }
        public virtual DbSet<tbHizmet> tbHizmet { get; set; }
        public virtual DbSet<tbKategori> tbKategori { get; set; }
        public virtual DbSet<tbKimlik> tbKimlik { get; set; }
        public virtual DbSet<tbSlider> tbSlider { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
