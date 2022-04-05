using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; } //birden fazla ürünü tutabilmek için bir koleksiyona ihtiyaç var.ICollection bi interface dir.
        //her bir kategoride birden fazla ürün bulunabilir
    }
}