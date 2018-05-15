﻿using System;
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
        private BlueprintController permissionController;

        public ChooseBlueprintView(Session aSession, UserControl loginView) {
            InitializeComponent();
            mother = loginView;
            CurrentSession = aSession;
            permissionController = new BlueprintController(CurrentSession);
        }

        private void FillList() {
            ICollection<IBlueprint> selectedBlueprints;
            if (IsDesigner()) {
                selectedBlueprints = permissionController.GetBlueprints();
            } else {
                selectedBlueprints = permissionController.GetBlueprints(CurrentSession.UserLogged);
            }
            blueprintList.DataSource = selectedBlueprints;
        }

        public Permission GetRequiredPermission() {
            return Permission.READ_BLUEPRINT;
        }

        public Button OptionMenuButton() {
            Button option;
            string optionTitle;
            if (IsDesigner()) {
                optionTitle = "Edit Blueprint";
            } else {
                optionTitle = "View Blueprint";
            }
            option = ButtonCreator.GenerateButton(optionTitle);
            return option;
        }

        private bool IsDesigner() {
            return CurrentSession.UserLogged.HasPermission(Permission.CREATE_BLUEPRINT);
        }

        public void SetSession(Session aSession) {
            CurrentSession = aSession;
        }

        public void SetUp() {
            FillList();

        }
    }
}
