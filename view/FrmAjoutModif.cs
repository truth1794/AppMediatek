using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AppMediatek.controller;
using AppMediatek.Model;

namespace AppMediatek.view
{
    public partial class FrmAjoutModif : Form
    {
        private FrmAjoutModifController controller;
        private bool modifEnCours = false;
        private int idPersonnel;
        public FrmAjoutModif(string[] selectData,bool modif)
        {
            InitializeComponent();
            Init(selectData);
            modifEnCours = modif;
        }

        private void Init(string[] selectData)
        {
            controller = new FrmAjoutModifController();
            PopulateFields(selectData);
        }

        private void PopulateFields(string[] data)
        {
            List<Service> lesServices = controller.GetServices();
            for (int i = 0; i < lesServices.Count; i++)
            {
                cmbService.Items.Add(lesServices[i].Nom);
            }
            if (data != null)
            {
                cmbService.SelectedIndex = int.Parse(data[6]) - 1;
                txtNom.Text = data[2];
                txtPrenom.Text = data[3];
                txtTel.Text = data[4];
                txtMail.Text = data[5];
                idPersonnel = int.Parse(data[0]);
            }
        }

        private void AddPerso(Personnel personnel)
        {
            controller.AddPersonnel(personnel);
        }

        private void UpdatePerso(Personnel personnel)
        {
            controller.UpdatePersonnel(personnel);
        }


        private void btnValider_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string tel = txtTel.Text;
            string mail = txtMail.Text;
            int idService = cmbService.SelectedIndex + 1;
            string service = cmbService.Text;
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) || string.IsNullOrEmpty(tel)
                    || string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(idService.ToString()) || string.IsNullOrEmpty(service))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
            else
            {
                DialogResult check = MessageBox.Show("Cette operation va modifier la base de donnee !", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (check == DialogResult.OK)
                {
                    if (modifEnCours)
                    {
                        UpdatePerso(new Personnel(idPersonnel, idService, service, nom, prenom, tel, mail));
                    }
                    else
                    {
                        AddPerso(new Personnel(0, idService, service, nom, prenom, tel, mail));
                    }
                    this.Close();
                }  
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
