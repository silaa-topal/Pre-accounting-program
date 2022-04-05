using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CustomerSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "Required")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CustomerMailAddress { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
}