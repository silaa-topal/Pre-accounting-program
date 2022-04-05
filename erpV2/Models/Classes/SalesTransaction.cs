using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class SalesTransaction
    {
        [Key]
        public int SalesID { get; set; }

        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int ProductID { get; set; }
        public int CustomerID { get; set; }
        public int PersonnelID { get; set; }

        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}