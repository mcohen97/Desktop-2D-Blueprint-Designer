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
    public partial class LoginView : UserControl, IUserFeatureControl {
        public LoginView() {
            InitializeComponent();
            PasswordText.PasswordChar = '*';
        }

        public Permission GetRequiredPermission() {
            return Permission.EDIT_USER;
        }
    }
}
