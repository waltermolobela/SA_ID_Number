using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SA_ID_Number.Models
{
    /// <summary>
    /// Person Information
    /// </summary>
    public class Person
    {
        [Key]
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string race { get; set; }
        public string dateOfBirth { get; set; }
        public int IdDocumentId { get; set; }

        public virtual IdDocument IdDocument { get; set; }
    }
}