using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Project.Models
{
    public class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }
        public virtual DbSet<Student> Student_set { get; set; }
        public virtual DbSet<Ispit> Ispit_set { get; set; }
        public virtual DbSet<Predmet> Predmet_set { get; set; }
        public virtual DbSet<PrijavaIspita> PrijavaIspita_set { get; set; }
        public virtual DbSet<Primer> Primer_set { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}


