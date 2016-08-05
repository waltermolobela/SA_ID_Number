using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SA_ID_Number.Models
{
    public abstract class IdDocument
    {  
        [Key]
        public string IdDocumentId { get; set; }
        public int idNumber { get; set; }
        public string country { get; set; }

        public abstract string GenerateIdNumber(string birthDate, string gender, string country);
        public abstract bool ValidateIdNumber(string idNumber); 
    }
}