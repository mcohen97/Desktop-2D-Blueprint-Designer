using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Logic;


namespace UserInterface {
    class InputValidations {

        public static void ErrorMessage(Label aMessageLabel,string errMessage) {
            aMessageLabel.ForeColor = Color.Red;
            aMessageLabel.Text = errMessage;
        }

        public static void OkMessage(Label aMessageLabel, string okMessage) {
            aMessageLabel.ForeColor = Color.Green;
            aMessageLabel.Text = okMessage;
        }

        public static void ValidateIfEmpty(TextBox anInput, Label msgLabel) {
            if (string.IsNullOrEmpty(anInput.Text)) {
                ErrorMessage(msgLabel, "Empty field!");
            } 
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
                ErrorMessage(aMsgLabel, "Invalid phone number!!");
            }
            return valid;
        }

        public static bool ValidateID(string anID, Label aMsgLabel) {
            bool valid = DataValidations.IsValidPhoneNumber(anID);
            if (valid) {
                OkMessage(aMsgLabel, "OK");
            } else {
                ErrorMessage(aMsgLabel, "Invalid ID number!!");
            }
            return valid;
        }


    }
}
