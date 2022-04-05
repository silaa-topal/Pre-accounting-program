using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceRowNo { get; set; }

        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string InvoiceTime { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TaxOffice { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Consigner { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}