using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class Personnel
    {
        [Key]
        public int PersonnelID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonnelFirstname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonnelLastname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string PersonnelTitle { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string PersonnelEmailAddress { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<SalesTransaction> SalesTransactions { get; set; }
        
    }
}