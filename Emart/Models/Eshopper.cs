using Emart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emart.Models
{
    public class Eshopper
    {
        public int EshopperId { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public int VendorId { get; set; }
        
    }
}