using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using DataLayer.Data;

namespace SA_ID_Number_Services.BusinessLogic
{
    /// <summary>
    ///  South African ID Document
    /// </summary>
    public class SouthAfricaIdDocument : IdDocumentServices
    {
        #region properties
        private const int CountryId = 0;  
        #endregion 

        #region Public Methods
        /// <summary>
        /// Generate South African ID Number
        /// </summary>
        /// <param name="birthDate"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        public override string GenerateIdNumber(string birthDate, string gender)
        { 
            try
            {
                PersonRace = 8;
                DateOfBirth =
                    DateTime.ParseExact(birthDate, "yyyy-MM-dd", CultureInfo.CurrentCulture).ToString("yyMMdd");

                Random random = new Random();
                int randomNumber = gender.ToLower().Equals("male") ? random.Next(5000, 9999) : random.Next(1000, 5000);

                return String.Format("{0} {1} {2}{3}{4}", DateOfBirth, randomNumber, CountryId, PersonRace, GetControlDigit());
            }
            catch (Exception ex)
            {
                return ex.Message;
            } 
        }    
       
        /// <summary>
        /// Checks if the entered ID is valid
        /// </summary>
        /// <param name="idNumber"></param>
        /// <returns></returns>
        public override bool ValidateIdNumber(string idNumber)
        {
            try
            {
                Regex regex = new Regex("[0-9]{13}");
                Match match = regex.Match(idNumber);

                if (!match.Success)
                {
                    return false;
                }

                if (!ValidateDate(idNumber.Substring(0, 6)))
                {
                    return false;
                }  

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }  
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


        private static bool ValidateDate(String date)
        {
            int month = int.Parse(date.Substring(2, 2));

            if (month < 1 || month > 12)
            {
                return false;
            }
            return true;
        }  
        #endregion
    }
}