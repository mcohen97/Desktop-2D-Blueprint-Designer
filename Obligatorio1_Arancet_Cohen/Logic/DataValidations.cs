using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic {
    public class DataValidations {

        public static void AssignStringIfNotNull(out string instanceVariable,string value ) {
            if (String.IsNullOrEmpty(value)) {
                throw new ArgumentNullException();
            }
            instanceVariable = value;
        }

        public static bool IsValidPhoneNumber(string phoneNumber) {
            Regex regex = new Regex(@"\d\d\d\d-\d\d-\d\d");
            Match match = regex.Match(phoneNumber);
            bool valid = match.Success;
            return valid;
        }

        public static bool IsValidID(string anID) {
            Regex regex = new Regex(@"\d\.\d\d\d\.\d\d\d-\d");
            Match match = regex.Match(anID);
            bool valid = match.Success;
            return valid;
        }

        public static bool IsValidPhoneNumber(object aPhoneNumber) {
            throw new NotImplementedException();
        }
    }
}
