namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bn_bs
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string idbn { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string idbsy { get; set; }
    }
}
