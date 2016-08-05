using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_ID_Number.Models
{
    public class OthersIdDocument : IdDocument
    {
        public override string GenerateIdNumber(string birthDate, string gender, string country)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }
        
        public override bool ValidateIdNumber(string idNumber)
        {
            // Not developed yet.
            throw new NotImplementedException();
        }
    }
}