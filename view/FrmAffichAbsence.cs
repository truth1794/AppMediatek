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
        /// Objet pour gérer la liste des développeurs
        /// </summary>
        private readonly BindingSource bdgPersonnels = new BindingSource();
        /// <summary>
        /// Objet pour gérer la liste des profils
        /// </summary>
        private readonly BindingSource bdgAbsences = new BindingSource();
        /// <summary>
        /// Controleur de la fenêtre
        /// </summary>
        private FrmAffichAbsController controller;

        private List<Absence> absences = new List<Absence>();

        private int idPersonnel;
        private string persoNom;
        private string persoPrenom;
        private string persoService;
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
        /// Création du controleur et remplissage des listes
        /// </summary>
        private void Init()
        {
            controller = new FrmAffichAbsController();
            RemplirListeAbsence(idPersonnel);
            lblNom.Text = persoNom;
            lblPrenom.Text = persoPrenom;
            lblService.Text = persoService;
            lblNbAbsences.Text = persoNbAsbences.ToString();
            //RemplirListeAbsents();
            //EnCourseModifPersonnel(false);
            //EnCoursModifAbsent(false);
        }
        protected override void OnActivated(EventArgs e)
        {
            ListUpdate();
            modifEnCours = false;
        }

        private void ListUpdate()
        {
            lstVAbsences.Items.Clear();
            RemplirListeAbsence(idPersonnel);
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
        private void RemplirListeAbsence(int idPersonnel)
        {
            absences = controller.GetAbsences(idPersonnel);
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
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            FrmManipAbsence frm = new FrmManipAbsence(null,null,0, modifEnCours, idPersonnel);
            frm.ShowDialog();
        }

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
                //string selectionData = lstVPersonnel.Items[0].Text;
                FrmManipAbsence frm = new FrmManipAbsence(dateDebut, dateFin, idMotif, modifEnCours,idPersonnel);
                //this.Hide();
                frm.ShowDialog();
            }
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstVAbsences.SelectedIndices;
            if (indices.Count == 1)
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
