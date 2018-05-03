namespace CADMundial
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloMundial : DbContext
    {
        public ModeloMundial()
            : base("name=ModeloMundial")
        {
        }

        public virtual DbSet<Equipo> Equipo { get; set; }
        public virtual DbSet<Grupo> Grupo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Grupo>()
                .Property(e => e.NombreGrupo)
                .IsUnicode(false);
        }
    }
}
