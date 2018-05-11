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

    public partial class EditBlueprintView : UserControl {

        private Blueprint selectedBluePrint;
        private Session CurrentSession { get; set; }
        private LoggedInView parent;

        public EditBlueprintView(Session aSession, LoggedInView aParent, Blueprint aBlueprint) {
            InitializeComponent();
            CurrentSession = aSession;
            parent = aParent;
            selectedBluePrint = aBlueprint; 
        }
    }
}
