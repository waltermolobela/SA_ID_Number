using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataLayer.Data
{
    /// <summary>
    /// Person Information
    /// </summary>
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int PersonRace { get; set; }
        public string DateOfBirth { get; set; }
        public int IdDocumentId { get; set; }

        public virtual IdDocument IdDocument { get; set; }
    }
}