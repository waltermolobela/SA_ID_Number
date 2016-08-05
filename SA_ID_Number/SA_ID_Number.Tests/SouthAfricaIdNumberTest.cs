using System;
using System.Collections.Generic;
using System.Globalization;
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
            var id = "hhdsahdshjds";
            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            bool isValidId = southAfricaIdNumberServices.ValidateIdNumber(id);

            Assert.IsFalse(isValidId);
        }

        [Test]
        public void GenerateIdNumber()
        {
            Person person = new Person();
            person.firstName = "Walter";
            person.lastName = "Molobela";
            person.dateOfBirth = DateTime.Now.ToString("yyyy-MM-dd");
            person.gender = "Male";
            person.race = "African";

            person.IdDocument = new SouthAfricaIdDocument();
            person.IdDocument.country = "South Africa";

            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            var id = southAfricaIdNumberServices.GenerateIdNumber(person.dateOfBirth, person.gender, person.race);

            var birthDate = DateTime.ParseExact(person.dateOfBirth, "yyyy-MM-dd", CultureInfo.CurrentCulture).ToString("yyMMdd");

            Assert.AreEqual(birthDate, id.Substring(0,6));
        }
    }
}
