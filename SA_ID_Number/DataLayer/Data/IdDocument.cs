using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DataLayer.Data
{
    public class IdDocument
    {  
        [Key]
        public string IdDocumentId { get; set; }
        public string IdNumber { get; set; }
        public string Country { get; set; }     
    }
}