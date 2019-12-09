namespace TayBac_28_06_17.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("benhnhanIoT")]
    public partial class benhnhanIoT
    {
        [Key]
        [StringLength(10)]
        public string idbnIoT { get; set; }

        [StringLength(10)]
        public string idbn { get; set; }

        public virtual benhnhan benhnhan { get; set; }
    }
}
