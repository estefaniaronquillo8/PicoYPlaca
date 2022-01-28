using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicoYPlaca.Helper
{
    // Class for validation of fields (TextBox)
    public static class Validation
    {
        // Boolean method to validate only letters on "txtLicenseLetters" TextBox. For the first 3 digits of the License Plate
        public static bool letterFieldValidation(this TextBox textBox)
        {            
            if (textBox.TextLength == 3)
            {
                if (!Regex.IsMatch(textBox.Text, @"^[a-zA-Z]+$"))
                {                    
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }

        // Boolean method to validate only numbers on "txtLicenseNumbers" TextBox. For the last 3-4 digits of the License Plate
        public static bool numberFieldValidation(this TextBox textBox)
        {
            int parsedValue; 
            
            if (textBox.TextLength == 4 || textBox.TextLength == 3)
            {
                if (!int.TryParse(textBox.Text, out parsedValue))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
