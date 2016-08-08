using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer.Data;

namespace SA_ID_Number_Services.BusinessLogic
{
    public class OthersIdDocument : IdDocumentServices
    {
        public override string GenerateIdNumber(string birthDate, string gender)
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