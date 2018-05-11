using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace UserInterface {
    class FieldMessages {

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




    }
}
