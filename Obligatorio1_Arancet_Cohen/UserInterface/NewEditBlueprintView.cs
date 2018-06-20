using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
using Logic.Domain;

namespace UserInterface
{
    public partial class NewEditBlueprintView : UserControl, IUserFeatureControl
    {
        private Session CurrentSession { get; set; }
        private LoggedInView parent;
        private BlueprintController permissionController;

        public NewEditBlueprintView(Session aSession, LoggedInView aControl)
        {
            InitializeComponent();
            parent = aControl;
            CurrentSession = aSession;
            permissionController = new BlueprintController(CurrentSession);
        }

        public void SetUp()
        {
            FillList();
        }

        private void FillList()
        {
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        public Permission GetRequiredPermission()
        {
            throw new NotImplementedException();
        }

        public Button OptionMenuButton()
        {
            throw new NotImplementedException();
        }

       
    }
}
