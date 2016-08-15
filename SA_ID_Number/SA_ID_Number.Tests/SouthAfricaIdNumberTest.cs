using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using SA_ID_Number.Models;
using SA_ID_Number_Services.BusinessLogic;

namespace SA_ID_Number.Tests
{
    [TestFixture]
    public class SouthAfricaIdNumberTest
    {
        [Test]
        public void ValidateIdNumber()
        {
            var id = "1608312105082";
            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            bool isValidId = southAfricaIdNumberServices.ValidateIdNumber(id);

            Assert.IsTrue(isValidId);
            Assert.AreEqual(13, id.Length);
        }

        [Test]
        public void GenerateIdNumber()
        {
            PersonVM person = new PersonVM();
            person.DateOfBirth = DateTime.Now.ToString("yyyy-MM-dd");
            person.Gender = "Male";    

            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            var id = southAfricaIdNumberServices.GenerateIdNumber(person.DateOfBirth, person.Gender);

            var birthDate = DateTime.ParseExact(person.DateOfBirth, "yyyy-MM-dd", CultureInfo.CurrentCulture).ToString("yyMMdd");

            Assert.AreEqual(birthDate, id.Substring(0,6));
            Assert.AreEqual(13, Regex.Replace(id, @"\s+", "").Length);
        }
    }
}
