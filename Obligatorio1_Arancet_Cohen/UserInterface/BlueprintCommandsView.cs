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
    public partial class BlueprintCommandsView : UserControl, IUserFeatureControl {

        private Blueprint Observed { get; set; }

        public BlueprintCommandsView(Blueprint aBlueprint) {
            InitializeComponent();
        }

        public Permission GetRequiredPermission() {
            return Permission.EDIT_BLUEPRINT;
        }

        public Button OptionMenuButton() {
            throw new NotImplementedException();
        }

        public void SetSession(Session aSession) {
            throw new NotImplementedException();
        }
    }
}
