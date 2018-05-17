using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Logic.Domain;


namespace UserInterface {
    class InputValidations {

        public static void ErrorMessage(Label aMessageLabel,string errMessage) {
            aMessageLabel.ForeColor = Color.DarkRed;
            aMessageLabel.BackColor = Color.Transparent;
            aMessageLabel.Text = errMessage;
        }

        public static void OkMessage(Label aMessageLabel, string okMessage) {
            aMessageLabel.ForeColor = Color.Green;
            aMessageLabel.Text = okMessage;
        }

        public static bool ValidateIfEmpty(TextBox anInput, Label msgLabel) {
            bool valid = true;
            if (string.IsNullOrEmpty(anInput.Text)) {
                ErrorMessage(msgLabel, "Empty field");
                valid = false;
            }
            return valid;
        }

        public static void ClearField(Label msgLabel) {
            msgLabel.Text = "";
        }

        public static bool IsListItemSelected(ListBox aList, Label aMsjLabel,string errorMsg) {
            bool valid = true;
            if (aList.SelectedItem == null) {
                aMsjLabel.ForeColor = Color.Red;
                aMsjLabel.Text = errorMsg;
                valid = false;
            }
            return valid;
        }

        public static bool ValidatePhoneNumber(string aPhoneNumber, Label aMsgLabel) {
            bool valid = DataValidations.IsValidPhoneNumber(aPhoneNumber);
            if (valid) {
                OkMessage(aMsgLabel, "OK");
            } else {
                ErrorMessage(aMsgLabel, "Invalid phone number");
            }
            return valid;
        }

        public static bool ValidateID(string anID, Label aMsgLabel) {
            bool valid = DataValidations.IsValidID(anID);
            if (valid) {
                OkMessage(aMsgLabel, "OK");
            } else {
                ErrorMessage(aMsgLabel, "Invalid ID number");
            }
            return valid;
        }

        public static bool ValidateGreaterThanZero(string aNumber,Label msgLabel ,string errorMsg) {
            bool valid = DataValidations.IsNumberGreaterThanZero(aNumber);
            if (!valid) {
                ErrorMessage(msgLabel, errorMsg);
            } 
            return valid;
        }
    }
}
