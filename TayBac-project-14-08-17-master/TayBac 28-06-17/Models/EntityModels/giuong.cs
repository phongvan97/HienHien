namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("giuong")]
    public partial class giuong
    {
        [Key]
        [StringLength(10)]
        public string idgiuong { get; set; }

        [StringLength(10)]
        public string idkhoa { get; set; }

        public bool? trangthai { get; set; }

        public virtual khoa khoa { get; set; }
    }
}
