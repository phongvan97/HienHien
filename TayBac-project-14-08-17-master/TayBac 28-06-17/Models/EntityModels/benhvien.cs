namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("benhvien")]
    public partial class benhvien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public benhvien()
        {
            bacsies = new HashSet<bacsy>();
            benhnhans = new HashSet<benhnhan>();
            khoas = new HashSet<khoa>();
            users = new HashSet<user>();
        }

        [Key]
        [StringLength(10)]
        public string idbv { get; set; }

        [Required]
        [StringLength(50)]
        public string tenbv { get; set; }

        [StringLength(20)]
        public string dienthoai { get; set; }

        [StringLength(20)]
        public string fax { get; set; }

        [StringLength(10)]
        public string IP { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? updatetime { get; set; }

        [StringLength(5)]
        public string idxa { get; set; }

        [StringLength(3)]
        public string idhuyen { get; set; }

        [StringLength(2)]
        public string idtinh { get; set; }

        public bool? trangthai { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bacsy> bacsies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhnhan> benhnhans { get; set; }

        public virtual huyen huyen { get; set; }

        public virtual tinh tinh { get; set; }

        public virtual xa xa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<khoa> khoas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
