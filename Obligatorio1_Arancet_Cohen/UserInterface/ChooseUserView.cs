using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace UserInterface {
    public abstract partial class ChooseUserView : UserControl, IUserFeatureControl {

        protected string optionName;

        public ChooseUserView() {
            InitializeComponent();
            FillList();
        }

        public abstract void FillList();

        public abstract Permission GetRequiredPermission();

        public Button OptionMenuButton() {
            Button option = new Button();
            option.Width = 100;
            option.Height = 50;
            option.Text = optionName;
            return option;
        }

        public void SetSession(Session aSession) {
            throw new NotImplementedException();
        }

    }
}
