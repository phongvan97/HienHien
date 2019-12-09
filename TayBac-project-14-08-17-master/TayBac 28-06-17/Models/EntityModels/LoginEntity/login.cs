using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TayBac_28_06_17.Models.EntityModels.LoginEntity
{
    public class Login
    {
        [Required]
        [StringLength(10)]
        public string id { get; set; }

        [Required]
        [StringLength(20)]
        public string pass { get; set; }

        [Required]
        public int group { get; set; }
    }
}