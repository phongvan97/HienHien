namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("laophoi")]
    public partial class laophoi
    {
        [Key]
        [StringLength(10)]
        public string idlaophoi { get; set; }

        [StringLength(10)]
        public string idbs { get; set; }

        public virtual benhsu benhsu { get; set; }
    }
}
