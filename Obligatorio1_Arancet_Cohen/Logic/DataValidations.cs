using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic {
    class DataValidations {

        public static void AssignStringIfNotNull(out string instanceVariable,string value ) {
            if (String.IsNullOrEmpty(value)) {
                throw new ArgumentNullException();
            }
            instanceVariable = value;
        }

        internal static bool IsValidPhoneNumber(string phoneNumber) {
            Regex regex = new Regex(@"\d\d\d\d-\d\d-\d\d");
            Match match = regex.Match(phoneNumber);
            bool valid = match.Success;
            return valid;
        }

        internal static bool IsValidID(string anID) {
            Regex regex = new Regex(@"\d\.\d\d\d\.\d\d\d-\d");
            Match match = regex.Match(anID);
            bool valid = match.Success;
            return valid;
        }
    }
}
