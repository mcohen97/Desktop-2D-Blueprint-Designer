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
    public partial class CreateUser : UserControl {

        private LoggedInView parent;
        private User created;

        public CreateUser(LoggedInView aControl, User aUser) {
            InitializeComponent();
            parent = aControl;
            created = aUser;
            ShowExtraFields();
        }

        private void ShowExtraFields() {
            if (created.HasPermission(Permission.HOLD_EXTRA_DATA)) {
                onlyClientFields.Show();
            } else {
                onlyClientFields.Hide();
            }
        }

        private void createButton_Click(object sender, EventArgs e) {
            SetUserData();
        }

        private void SetUserData() {
            if (created.HasPermission(Permission.HOLD_EXTRA_DATA)) {
                CreateClient();
            } else {
                CreateDesigner();
            }

        }

        private void CreateDesigner() {
            string userName = userNameText.Text;
            string name = nameTxt.Text;
            string surname = surnameText.Text;
            string pass = passwordText.Text;
            created = new Designer(name, surname, userName, pass, DateTime.Now);
            Registrar();
        }

        

        private void CreateClient() {
            string userName = userNameText.Text;
            string name = nameTxt.Text;
            string surname = surnameText.Text;
            string pass = passwordText.Text;
            string id = idText.Text;
            string tel = telNumberText.Text;
            string address = addressText.Text;
            created = new Client(name, surname, userName, pass, tel, address, id, DateTime.Now);
            Registrar();
        }

        private void Registrar() {
            UsersPortfolio.Instance.Add(created);
            parent.RestartMenu();
        }
    }
}