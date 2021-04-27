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
            optionButton.Width = 130;
            optionButton.Height = 60;
            optionButton.Text = title;
            optionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(120)))));
            optionButton.BackgroundImage = global::UserInterface.Properties.Resources.gridWhite;
            optionButton.BackgroundImageLayout = ImageLayout.Stretch;
            optionButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            optionButton.FlatAppearance.BorderSize = 2;
            optionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gainsboro;
            optionButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            optionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            optionButton.Font = new System.Drawing.Font("Century Gothic", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            optionButton.ForeColor = System.Drawing.Color.White;
            optionButton.UseVisualStyleBackColor = false;
            optionButton.Top = 50;
            optionButton.Left = 50;

            return optionButton;
        }

    }
}
