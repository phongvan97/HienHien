namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("huyen")]
    public partial class huyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public huyen()
        {
            bacsies = new HashSet<bacsy>();
            benhnhans = new HashSet<benhnhan>();
            benhviens = new HashSet<benhvien>();
            users = new HashSet<user>();
            xas = new HashSet<xa>();
        }

        [Key]
        [StringLength(3)]
        public string idhuyen { get; set; }

        [StringLength(50)]
        public string tenhuyen { get; set; }

        [StringLength(50)]
        public string cap { get; set; }

        [StringLength(2)]
        public string idtinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bacsy> bacsies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhnhan> benhnhans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<benhvien> benhviens { get; set; }

        public virtual tinh tinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user> users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<xa> xas { get; set; }
    }
}
