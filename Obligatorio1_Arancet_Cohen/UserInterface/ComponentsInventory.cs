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
    public partial class ComponentsInventory : UserControl, IUserFeatureControl {

        Blueprint observed;

        public ComponentsInventory(Blueprint aBlueprint) {
            InitializeComponent();
            observed = aBlueprint;
            UpdateList();
        }

        void UpdateList() {

        }

        public Permission GetRequiredPermission() {
            return Permission.READ_BLUEPRINT;
        }

        public Button OptionMenuButton() {
            throw new NotImplementedException();
        }

        public void SetSession(Session aSession) {
            throw new NotImplementedException();
        }
    }
}
