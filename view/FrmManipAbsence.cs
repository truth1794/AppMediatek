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
    public partial class FrmManipAbsence : Form
    {
        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private bool modifEnCours = false;
        /// <summary>
        /// Controleur de la fenêtre
        /// </summary>
        private FrmManipAbsController controller;

        private List<Absence> absences = new List<Absence>();

        private int idPersonnel;
        private string dateDebutToChange;

        /// <summary>
        /// construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmManipAbsence(string dateDebut, string dateFin, int idMotif, bool modifEnCours, int idPersonnel)
        {
            //dateTDebut.da
            //idPersonnel = int.Parse(data[0]);
            //persoNom = data[2];
            //persoPrenom = data[3];
            //persoService = data[1];
            InitializeComponent();
            Init(dateDebut, dateFin, idMotif, modifEnCours, idPersonnel);
        }

        /// <summary>
        /// Initialisations :
        /// Création du controleur et remplissage des listes
        /// </summary>
        private void Init(string dateDebut, string dateFin, int idMotif, bool modifEnCours, int idPersonnel)
        {
            controller = new FrmManipAbsController();
            if (modifEnCours)
            {
                dateTDebut.Value = DateTime.Parse(dateDebut);
                dateTFin.Value = DateTime.Parse(dateFin);
            }
            else
            {
                dateTDebut.Value = DateTime.Today;
                dateTFin.Value = DateTime.Today;
            }
            List<Motif> lesMotifs = controller.GetMotifs();
            for (int i = 0; i < lesMotifs.Count; i++)
            {
                cmbMotif.Items.Add(lesMotifs[i].Nom);
            }
            cmbMotif.SelectedIndex = idMotif - 1;
            this.modifEnCours = modifEnCours;
            this.idPersonnel = idPersonnel;
            dateDebutToChange = dateDebut;
            //RemplirListeAbsents();
            //EnCourseModifPersonnel(false);
            //EnCoursModifAbsent(false);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cmbMotif.SelectedIndex == -1)
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
            else if(DateTime.Compare(dateTDebut.Value,dateTFin.Value) > 0)
            {
                MessageBox.Show("La date de fin est anterieure a la date de debut.", "Information");
            }
            else
            {
                DialogResult check = MessageBox.Show("Cette operation va modifier la base de donnee !", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (check == DialogResult.OK)
                {
                    if (modifEnCours)
                    {
                        UpdateAbsence();
                    }
                    else
                    {
                        AddAbsence();
                    }
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {

        }


        private void AddAbsence()
        {
            controller.AddAbsence(new Absence(
                idPersonnel,
                dateTDebut.Value,
                cmbMotif.SelectedIndex + 1,
                dateTFin.Value,
                null));
        }

        private void UpdateAbsence()
        {
            Absence updatedAbsence = new Absence(idPersonnel, dateTDebut.Value, cmbMotif.SelectedIndex + 1, dateTFin.Value, null);
            Absence AbsenceToUpdate = new Absence(idPersonnel, DateTime.Parse(dateDebutToChange), 1, DateTime.Today, null);
            controller.UpdateAbsence(updatedAbsence, AbsenceToUpdate);
        }
        ///// <summary>
        ///// Affiche les développeurs
        ///// </summary>
        //private void RemplirListePersonnels()
        //{
        //    //List<Personnel> lePersonnel = controller.GetLePersonnel();
        //    //bdgPersonnels.DataSource = lePersonnel;
        //    //dgvDeveloppeurs.DataSource = bdgPersonnels;
        //    //dgvDeveloppeurs.Columns["iddeveloppeur"].Visible = false;
        //    //dgvDeveloppeurs.Columns["pwd"].Visible = false;
        //    //dgvDeveloppeurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        //    List<Personnel> lePersonnel = controller.GetLePersonnel();
        //    List<string> personnelNom = new List<string>();
        //    for (int i = 0; i < lePersonnel.Count; i++)
        //    {
        //        personnelNom.Add(lePersonnel[i].Nom + " " + lePersonnel[i].Prenom);
        //    }
        //    lstPerso.Items.AddRange(personnelNom.ToArray());
        //}

        /// <summary>
        /// Affiche les développeurs
        /// </summary>
        //private void RemplirListeAbsence(int idPersonnel)
        //{
        //    absences = controller.GetAbsences(idPersonnel);
        //    persoNbAsbences = absences.Count;
        //    string[] perso = new string[4];
        //    int idPerso = idPersonnel;
        //    for (int i = 0; i < persoNbAsbences; i++)
        //    {
        //        perso[0] = absences[i].DateDebut.ToString();
        //        perso[1] = absences[i].IdMotif.ToString();
        //        perso[2] = absences[i].DateFin.ToString();
        //        perso[3] = absences[i].Motif;
        //        var lstVItem = new ListViewItem(perso[0]);
        //        lstVItem.SubItems.Add(perso[2]);
        //        lstVItem.SubItems.Add(perso[3]);
        //        lstVAbsences.Items.Add(lstVItem);
        //    }
        //}




        //private void btnAjout_Click(object sender, EventArgs e)
        //{
        //    FrmAjoutModif frm = new FrmAjoutModif(null, modifEnCours);
        //    //this.Hide();
        //    frm.ShowDialog();
        //}

        //private void btnModif_Click(object sender, EventArgs e)
        //{
        //    ListView.SelectedIndexCollection indices = lstVPersonnel.SelectedIndices;
        //    if (indices.Count == 1)
        //    {
        //        modifEnCours = true;
        //        ListViewItem data0 = lstVPersonnel.SelectedItems[0];
        //        string[] data = new string[7];
        //        data[0] = data0.Text;
        //        for (int k = 1; k < 7; k++)
        //        {
        //            data[k] = data0.SubItems[k].Text;
        //        }
        //        //string selectionData = lstVPersonnel.Items[0].Text;
        //        FrmAjoutModif frm = new FrmAjoutModif(data, modifEnCours);
        //        //this.Hide();
        //        frm.ShowDialog();
        //    }
        //}

        //private void btnSuppr_Click(object sender, EventArgs e)
        //{
        //    ListView.SelectedIndexCollection indices = lstVPersonnel.SelectedIndices;
        //    if (indices.Count == 1)
        //    {
        //        ListViewItem data0 = lstVPersonnel.SelectedItems[0];
        //        int idPerso = int.Parse(data0.Text);
        //        int idService = int.Parse(data0.SubItems[6].Text);
        //        string service = data0.SubItems[1].Text;
        //        string nom = data0.SubItems[2].Text;
        //        string prenom = data0.SubItems[3].Text;
        //        string tel = data0.SubItems[4].Text;
        //        string mail = data0.SubItems[5].Text;
        //        controller.DelPersonnel(new Personnel(idPerso, idService, service, nom, prenom, tel, mail));
        //        ListUpdate();
        //    }
        //}
    }
}
