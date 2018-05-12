using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface {
    class ButtonCreator {

        public static Button GenerateButton(string title) {
            Button optionButton = new Button();
            optionButton.Width = 100;
            optionButton.Height = 50;
            optionButton.Text = title;
            return optionButton;
        }

    }
}
