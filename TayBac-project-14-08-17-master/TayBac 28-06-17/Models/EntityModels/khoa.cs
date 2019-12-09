namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khoa")]
    public partial class khoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khoa()
        {
            giuongs = new HashSet<giuong>();
        }

        [Key]
        [StringLength(10)]
        public string idkhoa { get; set; }

        [StringLength(100)]
        public string tenkhoa { get; set; }

        [StringLength(10)]
        public string idbv { get; set; }

        [StringLength(100)]
        public string mota { get; set; }

        public virtual benhvien benhvien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<giuong> giuongs { get; set; }
    }
}
