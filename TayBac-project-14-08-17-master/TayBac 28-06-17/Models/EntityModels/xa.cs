namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("xa")]
    public partial class xa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public xa()
        {
            benhnhans = new HashSet<benhnhan>();
            benhnhans1 = new HashSet<benhnhan>();
            benhviens = new HashSet<benhvien>();
            users = new HashSet<user>();
        }

        [Key]
        [StringLength(5)]
        public string idxa { get; set; }

        [StringLength(50)]
        public string tenxa { get; set; }

        [StringLength(50)]
        public string cap { get; set; }

        [StringLength(3)]
        public string idhuyen { get; set; }

        [StringLength(2)]
        public string idtinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhnhan> benhnhans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhnhan> benhnhans1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhvien> benhviens { get; set; }

        public virtual huyen huyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }
    }
}
