using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AppMediatek.controller;
using AppMediatek.Model;

namespace AppMediatek.view
{
    /// <summary>
    /// Fenêtre d'affichage du personnels et de ses informations
    /// </summary>
    public partial class FrmGestion : Form
    {
        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private Boolean modifEnCours = false;
        /// <summary>
        /// Controleur de la fenêtre
        /// </summary>
        private FrmGestionController controller;

        /// <summary>
        /// construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmGestion()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Initialisations :
        /// Création du controleur, remplissage de la liste et desactivation des boutons
        /// </summary>
        private void Init()
        {
            controller = new FrmGestionController();
            RemplirListePersonnels();
            btnAfficheAbs.Enabled = false;
            btnModif.Enabled = false;
            btnSuppr.Enabled = false;
        }

        /// <summary>
        /// Mise a jour du Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListRefresh(object sender, FormClosingEventArgs e)
        {
            ListUpdate();
            btnAfficheAbs.Enabled = false;
            btnModif.Enabled = false;
            btnSuppr.Enabled = false;
        }

        /// <summary>
        /// Mise a jour de la liste
        /// </summary>
        private void ListUpdate()
        {
            lstVPersonnel.Items.Clear();
            RemplirListePersonnels();
        }
        /// <summary>
        /// Remplir la liste du personnels
        /// </summary>
        private void RemplirListePersonnels()
        {
            List<Personnel> lePersonnel = controller.GetLePersonnel();
            string[] perso = new string[8];
            for (int i = 0; i < lePersonnel.Count; i++)
            {
                perso[0] = lePersonnel[i].Idpersonnel.ToString();
                perso[2] = lePersonnel[i].Service;
                perso[3] = lePersonnel[i].Nom;
                perso[4] = lePersonnel[i].Prenom;
                perso[5] = lePersonnel[i].Tel;
                perso[6] = lePersonnel[i].Mail;
                perso[7] = lePersonnel[i].Idservice.ToString();
                var lstVItem = new ListViewItem(perso[0]);
                for (int k = 2; k < 8; k++)
                {
                    lstVItem.SubItems.Add(perso[k]);
                }
                lstVPersonnel.Items.Add(lstVItem);
            }
        }

        /// <summary>
        /// Bouton gerant la demande d'affichage des absences du personnel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAfficheAbs_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstVPersonnel.SelectedIndices;
            if (indices.Count == 1)
            {
                modifEnCours = true;
                ListViewItem data0 = lstVPersonnel.SelectedItems[0];
                string[] data = new string[7];
                data[0] = data0.Text;
                for (int k = 1; k < 7; k++)
                {
                    data[k] = data0.SubItems[k].Text;
                }
                //string selectionData = lstVPersonnel.Items[0].Text;
                FrmAffichAbsence frm = new FrmAffichAbsence(data);
                frm.FormClosing += new FormClosingEventHandler(ListRefresh);
                //this.Hide();
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Bouton gerant l'ajout d'un personnel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjout_Click(object sender, EventArgs e)
        {
            FrmAjoutModif frm = new FrmAjoutModif(null,modifEnCours);
            frm.FormClosing += new FormClosingEventHandler(ListRefresh);
            //this.Hide();
            frm.ShowDialog();
        }

        /// <summary>
        /// Bouton gerant la modificationd'un personnel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModif_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstVPersonnel.SelectedIndices;
            if (indices.Count == 1)
            {
                modifEnCours = true;
                ListViewItem data0 = lstVPersonnel.SelectedItems[0];
                string[] data = new string[7];
                data[0] = data0.Text;
                for (int k = 1; k < 7; k++)
                {
                    data[k] = data0.SubItems[k].Text;
                }
                //string selectionData = lstVPersonnel.Items[0].Text;
                FrmAjoutModif frm = new FrmAjoutModif(data, modifEnCours);
                frm.FormClosing += new FormClosingEventHandler(ListRefresh);
                //this.Hide();
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Bouton gerant la suppression d'un personnel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuppr_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstVPersonnel.SelectedIndices;
            DialogResult check = MessageBox.Show("Cette operation va modifier la base de donnee !", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (check == DialogResult.OK && indices.Count == 1)
            {
                ListViewItem data0 = lstVPersonnel.SelectedItems[0];
                int idPerso = int.Parse(data0.Text);
                int idService = int.Parse(data0.SubItems[6].Text);
                string service = data0.SubItems[1].Text;
                string nom = data0.SubItems[2].Text;
                string prenom = data0.SubItems[3].Text;
                string tel = data0.SubItems[4].Text;
                string mail = data0.SubItems[5].Text;
                controller.DelPersonnel(new Personnel(idPerso, idService, service, nom, prenom, tel, mail));
                ListUpdate();
            }
        }

        /// <summary>
        /// Evenement gerant la detection de la selection d'une ligne dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstVPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstVPersonnel.SelectedIndices.Count != 1)
            {
                btnAfficheAbs.Enabled = false;
                btnModif.Enabled = false;
                btnSuppr.Enabled = false;
            }
            else
            {
                btnAfficheAbs.Enabled = true;
                btnModif.Enabled = true;
                btnSuppr.Enabled = true;
            }
        }
    }
}
