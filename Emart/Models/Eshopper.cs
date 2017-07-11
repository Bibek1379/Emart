using Emart.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emart.Models
{
    public class Eshopper
    {
        [Key]
        public int Id { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public string GooglelusLink { get; set; }

        public string Header { get; set; }
        public string Title { get; set; }
        public string Footer { get; set; }
        public int VendorId { get; set; }
        
    }
}