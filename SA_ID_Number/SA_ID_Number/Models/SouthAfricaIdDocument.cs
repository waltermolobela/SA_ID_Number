﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA_ID_Number.Models
{
    public class SouthAfricaIdDocument : IdDocument
    {
        public override string GenerateIdNumber(string birthDate, string gender, string country)
        {
            string id = string.Empty;
            return id;
        }
    }
}