namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("huyetap")]
    public partial class huyetap
    {
        [Key]
        [StringLength(10)]
        public string idhuyetap { get; set; }

        [StringLength(10)]
        public string idbs { get; set; }

        [StringLength(100)]
        public string HA_I { get; set; }

        [StringLength(100)]
        public string HA_II_A { get; set; }

        public bool? HA_II_B_1 { get; set; }

        [Column("HA_II_B_1.1")]
        [StringLength(50)]
        public string HA_II_B_1_1 { get; set; }

        public bool? HA_II_B_2 { get; set; }

        [Column("HA_II_B_2.1")]
        [StringLength(50)]
        public string HA_II_B_2_1 { get; set; }

        public bool? HA_II_B_3 { get; set; }

        [Column("HA_II_B_3.1")]
        [StringLength(50)]
        public string HA_II_B_3_1 { get; set; }

        public bool? HA_II_B_4 { get; set; }

        [Column("HA_II_B_4.1")]
        [StringLength(50)]
        public string HA_II_B_4_1 { get; set; }

        [StringLength(30)]
        public string HA_II_B_5 { get; set; }

        public bool? HA_II_B_6 { get; set; }

        [Column("HA_II_B_6.1")]
        [StringLength(50)]
        public string HA_II_B_6_1 { get; set; }

        [Column("HA_III_1.1")]
        public float? HA_III_1_1 { get; set; }

        [Column("HA_III_1.2")]
        public float? HA_III_1_2 { get; set; }

        [Column("HA_III_1.3.1")]
        public int? HA_III_1_3_1 { get; set; }

        [Column("HA_III_1.3.2")]
        public int? HA_III_1_3_2 { get; set; }

        [Column("HA_III_1.4")]
        public int? HA_III_1_4 { get; set; }

        [Column("HA_III_1.5")]
        public float? HA_III_1_5 { get; set; }

        [Column("HA_III_1.6")]
        public float? HA_III_1_6 { get; set; }

        [StringLength(50)]
        public string HA_III_2 { get; set; }

        [StringLength(50)]
        public string HA_IV_1 { get; set; }

        public float? HA_IV_2 { get; set; }

        public float? HA_IV_3 { get; set; }

        public float? HA_IV_4 { get; set; }

        public float? HA_IV_5 { get; set; }

        public float? HA_IV_6 { get; set; }

        public bool? HA_IV_7 { get; set; }

        public bool? HA_IV_8 { get; set; }

        public bool? HA_IV_9 { get; set; }

        public bool? HA_IV_10 { get; set; }

        public bool? HA_IV_11 { get; set; }

        public bool? HA_IV_12 { get; set; }

        public bool? HA_IV_13 { get; set; }

        public bool? HA_IV_14 { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaynhapvien { get; set; }

        [StringLength(10)]
        public string idnd { get; set; }

        public DateTime? updatetime { get; set; }

        public virtual benhsu benhsu { get; set; }
    }
}
