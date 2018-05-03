namespace CADMundial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Equipo")]
    public partial class Equipo
    {
        [Key]
        public short IdEqupo { get; set; }

        [Required]
        [StringLength(1)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }

        public virtual Grupo Grupo { get; set; }
    }
}
