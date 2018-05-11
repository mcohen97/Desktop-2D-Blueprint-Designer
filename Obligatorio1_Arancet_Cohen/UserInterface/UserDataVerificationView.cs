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
    public partial class UserDataVerificationView : UserControl, IUserFeatureControl {

        private Session CurrentSession { get; set; }

        public UserDataVerificationView(Session aSession) {
            InitializeComponent();
            CurrentSession = aSession;
        }

        public Permission GetRequiredPermission() {
            return Permission.EDIT_USER;
        }

        public Button OptionMenuButton() {
            Button optionButton = new Button();
            optionButton.Width = 100;
            optionButton.Height = 50;
            optionButton.Text = "Edit Personal Info";
            return optionButton;
        }

        public void SetSession(Session aSession) {
            CurrentSession = aSession;
        }
    }
}
