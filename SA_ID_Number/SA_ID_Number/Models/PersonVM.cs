using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_ID_Number.Models
{
    public class PersonVM
    {                   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string IdNumber { get; set; }
    }
}