namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [Key]
        [StringLength(10)]
        public string idnd { get; set; }

        [Required]
        [StringLength(10)]
        public string idbv { get; set; }

        [Required]
        [StringLength(20)]
        public string pass { get; set; }

        [Required]
        [StringLength(50)]
        public string tennd { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaysinh { get; set; }

        [StringLength(20)]
        public string dienthoai { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string chucvu { get; set; }

        [StringLength(50)]
        public string donvi { get; set; }

        [StringLength(50)]
        public string kieuuser { get; set; }

        public DateTime? updatetime { get; set; }

        [StringLength(5)]
        public string idxa { get; set; }

        [StringLength(3)]
        public string idhuyen { get; set; }

        [StringLength(2)]
        public string idtinh { get; set; }

        [StringLength(50)]
        public string account { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        public bool? trangthai { get; set; }

        public virtual benhvien benhvien { get; set; }

        public virtual huyen huyen { get; set; }

        public virtual tinh tinh { get; set; }

        public virtual xa xa { get; set; }
    }
}
