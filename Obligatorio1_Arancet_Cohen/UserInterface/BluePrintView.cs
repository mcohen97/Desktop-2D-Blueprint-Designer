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
    public partial class BluePrintView : UserControl, IUserFeatureControl {

        private Session CurrentSession { get; set; }
        private Blueprint Observed { get; set; }
        private List<IUserFeatureControl> features;

        public BluePrintView(Session aSession, Blueprint aBlueprint) {
            InitializeComponent();
            CurrentSession = aSession;
            Observed = aBlueprint;
            features = new List<IUserFeatureControl>();
            features.Add(new ComponentsInventory(Observed));
            features.Add(new BlueprintCommandsView(Observed));
           
            //Customize();
        }

        
        private void Customize() {
           // UserControl toInclude;
        //if(CurrentSession.UserLogged.HasPermission())    

            

        }

        public Permission GetRequiredPermission() {
            throw new NotImplementedException();
        }

        public void SetSession(Session aSession) {
            throw new NotImplementedException();
        }

        public Button OptionMenuButton() {
            Button option = new Button();
            option.Text = "View Blueprint";
            return option;
        }
    }
}
