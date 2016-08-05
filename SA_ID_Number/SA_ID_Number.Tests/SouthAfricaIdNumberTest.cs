using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SA_ID_Number.Models;

namespace SA_ID_Number.Tests
{
    [TestFixture]
    public class SouthAfricaIdNumberTest
    {
        [Test]
        public void ValidateIdNumber()
        {

        }

        [Test]
        public void GenerateIdNumber()
        {
            Person person = new Person();
            person.firstName = "Walter";
            person.lastName = "Molobela";
            person.dateOfBirth = DateTime.Now.ToString("yyyy-M-d");
            person.gender = "Male";
            person.race = "African";

            person.IdDocument = new SouthAfricaIdDocument();
            person.IdDocument.country = "South Africa";

            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            var id = southAfricaIdNumberServices.GenerateIdNumber(person.dateOfBirth, person.gender, person.IdDocument.country);
            Assert.AreEqual(string.Empty, id);
        }
    }
}
