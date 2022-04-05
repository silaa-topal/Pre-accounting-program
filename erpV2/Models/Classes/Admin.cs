using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminUsername { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string AdminPassword { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(10)]
        public string AdminAuthority { get; set; }
    }
}