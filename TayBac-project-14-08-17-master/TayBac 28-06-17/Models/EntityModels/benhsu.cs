namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("benhsu")]
    public partial class benhsu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public benhsu()
        {
            daithaoduongs = new HashSet<daithaoduong>();
            henphequans = new HashSet<henphequan>();
            huyetaps = new HashSet<huyetap>();
            laophois = new HashSet<laophoi>();
        }

        [Key]
        [StringLength(10)]
        public string idbs { get; set; }

        [StringLength(10)]
        public string idbn { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaytao { get; set; }

        public DateTime? updatetime { get; set; }

        public virtual benhnhan benhnhan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<daithaoduong> daithaoduongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<henphequan> henphequans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<huyetap> huyetaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<laophoi> laophois { get; set; }
    }
}
