using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace UserInterface {
    class InputValidations {

        public static void ErrorMessage(Label aMessageLabel,string errMessage) {
            aMessageLabel.ForeColor = Color.Red;
            aMessageLabel.Text = errMessage;
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



    }
}
