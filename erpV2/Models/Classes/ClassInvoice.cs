using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace erpV2.Models.Classes
{
    public class ClassInvoice
    {
        public IEnumerable<Invoice> value1 { get; set; }
        public IEnumerable<InvoiceItem> value2 { get; set; }
    }
}