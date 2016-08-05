using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA_ID_Number.Models
{
    /// <summary>
    ///  South African ID Document
    /// </summary>
    public class SouthAfricaIdDocument : IdDocument
    {
        #region properties
        #endregion 

        #region Public Methods
        /// <summary>
        /// Generate South African ID Number
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="gender"></param>
        /// <param name="race"></param>
        /// <returns></returns>
        public override string GenerateIdNumber(string birthDate, string gender, string race)
        {
            int countryId = 0;
            int personRace = 8;
            var formatedBirthDate =
                DateTime.ParseExact(birthDate, "yyyy-MM-dd", CultureInfo.CurrentCulture).ToString("yyMMdd");

            Random random = new Random();
            long randomNumber = gender.ToLower().Equals("male") ? random.Next(5000, 9999) : random.Next(1000, 5000);

            if (race.ToLower().Trim().Equals("african"))
            {
                personRace = 9;
            }

            return String.Format("{0} {1}{2} {3} {4}", formatedBirthDate, randomNumber, countryId, personRace, GetControlDigit());
        }

        /// <summary>
        /// Checks if the entered ID is valid
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        public override bool ValidateIdNumber(string idNumber)
        {
            bool isValid = false;
            return isValid;
        }
        #endregion



        #region private Methods
        // This method assumes that the 13-digit id number has 
        // valid digits in position 0 through 12.  
        // Stored in a property 'ParseIdString'.  
        // Returns: the valid digit between 0 and 9, or  
        // -1 if the method fails.
        private int GetControlDigit()
        {
            int d = 1;
            try
            {
                int a = 0;
                for (int i = 0; i < 6; i++)
                {
                    //a += int.Parse(this.ParsedIdString[2 * i].ToString()); ToDo
                }
                int b = 0;
                for (int i = 0; i < 6; i++)
                {
                    //b = b * 10 + int.Parse(this.ParsedIdString[2 * i + 1].ToString()); ToDO
                }
                b *= 2;
                int c = 0;
                do
                {
                    c += b % 10;
                    b = b / 10;
                }
                while (b > 0);
                c += a;
                d = 10 - (c % 10);
                if (d == 10) d = 0;
            }
            catch {/*ignore*/} return d;
        }
        #endregion
    }
}