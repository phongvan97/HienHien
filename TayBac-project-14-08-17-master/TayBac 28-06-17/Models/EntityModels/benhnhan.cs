namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("benhnhan")]
    public partial class benhnhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public benhnhan()
        {
            benhnhanIoTs = new HashSet<benhnhanIoT>();
            benhsus = new HashSet<benhsu>();
        }

        [Key]
        [StringLength(10)]
        public string idbn { get; set; }

        [StringLength(20)]
        public string pass { get; set; }

        [Required]
        [StringLength(50)]
        public string tenbn { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaysinh { get; set; }

        public bool? gioitinh { get; set; }

        [StringLength(50)]
        public string nghenghiep { get; set; }

        [StringLength(50)]
        public string dantoc { get; set; }

        [StringLength(50)]
        public string ngoaikieu { get; set; }

        [StringLength(50)]
        public string noilamviec { get; set; }

        [StringLength(20)]
        public string dienthoai { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string diachi { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? updatetime { get; set; }

        [StringLength(5)]
        public string idxa { get; set; }

        [StringLength(3)]
        public string idhuyen { get; set; }

        [StringLength(2)]
        public string idtinh { get; set; }

        [Column(TypeName = "image")]
        public byte[] image { get; set; }

        [StringLength(10)]
        public string idbv { get; set; }

        [StringLength(10)]
        public string idgiuong { get; set; }

        [StringLength(20)]
        public string mayt { get; set; }

        [StringLength(20)]
        public string soluutru { get; set; }

        public bool? trangthai { get; set; }

        [StringLength(10)]
        public string idkhoa { get; set; }

        public virtual benhvien benhvien { get; set; }

        public virtual huyen huyen { get; set; }

        public virtual tinh tinh { get; set; }

        public virtual xa xa { get; set; }

        public virtual xa xa1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhnhanIoT> benhnhanIoTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhsu> benhsus { get; set; }
    }
}
