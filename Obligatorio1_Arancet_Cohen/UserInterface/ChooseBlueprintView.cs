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
    public partial class ChooseBlueprintView : UserControl, IUserFeatureControl {

        private Session CurrentSession { get; set; }
        private UserControl mother;

        public ChooseBlueprintView(Session aSession, UserControl loginView) {
            InitializeComponent();
            mother = loginView;
            CurrentSession = aSession;
        }

        public Permission GetRequiredPermission() {
            return Permission.READ_BLUEPRINT;
        }

        public Button OptionMenuButton() {
            Button option = new Button();
            option.Width = 100;
            option.Height = 50;
            option.Text = "Open Blueprint";
            return option;

        }

        public void SetSession(Session aSession) {
            CurrentSession = aSession;
        }
    }
}
