using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AppMediatek.controller;
using AppMediatek.Model;

namespace AppMediatek.view
{
    /// <summary>
    /// Fenêtre d'affichage des développeurs et de leurs profils
    /// </summary>
    public partial class FrmAffichAbsence : Form
    {
        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private Boolean modifEnCours = false;
        /// <summary>
        /// Controleur de la fenêtre
        /// </summary>
        private FrmAffichAbsController controller;
        /// <summary>
        /// Controleur de la fenêtre
        /// </summary>
        //private List<Absence> absences = new List<Absence>();
        /// <summary>
        /// object contenant l'ID du personnel selectionne
        /// </summary>
        private int idPersonnel;
        /// <summary>
        /// object contenant le nom du personnel selectionne
        /// </summary>
        private string persoNom;
        /// <summary>
        /// object contenant le prenom du personnel selectionne
        /// </summary>
        private string persoPrenom;
        /// <summary>
        /// object contenant le service du personnel selectionne
        /// </summary>
        private string persoService;
        /// <summary>
        /// object contenant le nombre d'absences du personnel selectionne
        /// </summary>
        private int persoNbAsbences;

        /// <summary>
        /// construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmAffichAbsence(string[] data)
        {
            idPersonnel = int.Parse(data[0]);
            persoNom = data[2];
            persoPrenom = data[3];
            persoService = data[1];
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Initialisations :
        /// Création du controleur, remplissage de la liste, desactivation des boutons
        /// </summary>
        private void Init()
        {
            controller = new FrmAffichAbsController();
            RemplirListeAbsence(idPersonnel);
            btnModif.Enabled = false;
            btnSuppr.Enabled = false;
        }

        /// <summary>
        /// Mise a jour de la liste
        /// </summary>
        private void ListUpdate()
        {
            lstVAbsences.Items.Clear();
            RemplirListeAbsence(idPersonnel);
        }

        /// <summary>
        /// Mise a jour du Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListRefresh(object sender, FormClosingEventArgs e)
        {
            ListUpdate();
            btnModif.Enabled = false;
            btnSuppr.Enabled = false;
            modifEnCours = false;
        }


        /// <summary>
        /// Remplissage de la liste
        /// </summary>
        /// <param name="idPersonnel">ID du personnel selectionne</param> id
        private void RemplirListeAbsence(int idPersonnel)
        {
            List<Absence> absences = controller.GetAbsences(idPersonnel);
            persoNbAsbences = absences.Count;
            string[] perso = new string[4];
            int idPerso = idPersonnel;
            for (int i = 0; i < persoNbAsbences; i++)
            {
                perso[0] = absences[i].DateDebut.ToString();
                perso[1] = absences[i].IdMotif.ToString();
                perso[2] = absences[i].DateFin.ToString();
                perso[3] = absences[i].Motif;
                var lstVItem = new ListViewItem(perso[0]);
                lstVItem.SubItems.Add(perso[2]);
                lstVItem.SubItems.Add(perso[3]);
                lstVItem.SubItems.Add(perso[1]);
                lstVAbsences.Items.Add(lstVItem);
            }
            lblNom.Text = persoNom;
            lblPrenom.Text = persoPrenom;
            lblService.Text = persoService;
            lblNbAbsences.Text = persoNbAsbences.ToString();
        }

        /// <summary>
        /// Bouton gerant la demande d'ajout d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjout_Click(object sender, EventArgs e)
        {
            FrmManipAbsence frm = new FrmManipAbsence(null,null,0, modifEnCours, idPersonnel);
            frm.FormClosing += new FormClosingEventHandler(ListRefresh);
            frm.ShowDialog();
        }

        /// <summary>
        /// Bouton gerant la demande de modification d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModif_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstVAbsences.SelectedIndices;
            if (indices.Count == 1)
            {
                modifEnCours = true;
                ListViewItem data0 = lstVAbsences.SelectedItems[0];
                string dateDebut = data0.Text;
                string dateFin = data0.SubItems[1].Text;
                int idMotif = int.Parse(data0.SubItems[3].Text);
                FrmManipAbsence frm = new FrmManipAbsence(dateDebut, dateFin, idMotif, modifEnCours,idPersonnel);
                frm.FormClosing += new FormClosingEventHandler(ListRefresh);
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Bouton gerant la demande de suppresion d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuppr_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstVAbsences.SelectedIndices;
            DialogResult check = MessageBox.Show("Cette operation va modifier la base de donnee !", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (check == DialogResult.OK && indices.Count == 1)
            {
                ListViewItem data0 = lstVAbsences.SelectedItems[0];
                DateTime dateDebut = DateTime.Parse(data0.Text);
                DateTime dateFin = DateTime.Parse(data0.SubItems[1].Text);
                int idMotif = int.Parse(data0.SubItems[3].Text);
                string motif = data0.SubItems[2].Text;
                controller.DelAbsence(new Absence(this.idPersonnel, dateDebut, idMotif, dateFin, motif));
                ListUpdate();
            }
        }

        /// <summary>
        /// Bouton gerant le retour vers le Form precedent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRetour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evenement gerant la detection de la selection d'une ligne dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstVAbsences_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVAbsences.SelectedIndices.Count != 1)
            {
                btnModif.Enabled = false;
                btnSuppr.Enabled = false;
            }
            else
            {
                btnModif.Enabled = true;
                btnSuppr.Enabled = true;
            }
        }
    }
}
