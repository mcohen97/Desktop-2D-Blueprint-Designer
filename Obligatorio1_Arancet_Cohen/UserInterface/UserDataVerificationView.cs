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
        public UserDataVerificationView() {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        public Permission GetRequiredPermission() {
            throw new NotImplementedException();
        }
    }
}
