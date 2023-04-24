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
    public partial class FrmGestion : Form
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
        private FrmGestionController controller;

        private List<Personnel> lePersonnel = new List<Personnel>();
        /// <summary>
        /// construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmGestion()
        {
            InitializeComponent();
            Init();
        }

        public void FrmGestion_Load(object sender, EventArgs e)
        {

        }

        //public void Populate_LstPerso()
        //{
        //    List<Personnel> lePersonnel = controller.GetLePersonnel();
        //    List<string> personnelNom = new List<string>();
        //    for (int i = 0; i < lePersonnel.Count; i++)
        //    {
        //        personnelNom.Add(lePersonnel[i].Nom + " " + lePersonnel[i].Prenom);
        //    }
        //    lstPerso.Items.AddRange(personnelNom.ToArray());
        //}

        /// <summary>
        /// Initialisations :
        /// Création du controleur et remplissage des listes
        /// </summary>
        private void Init()
        {
            controller = new FrmGestionController();
            RemplirListePersonnels();
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
            lstVPersonnel.Items.Clear();
            RemplirListePersonnels();
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
        private void RemplirListePersonnels()
        {
            lePersonnel = controller.GetLePersonnel();
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
                //this.Hide();
                frm.ShowDialog();
            }
        }

        private void SetupListView()
        {
            //lstVPersonnel.Columns.Add("ID");
            //lstVPersonnel.Columns.Add("Service");
            //lstVPersonnel.Columns.Add("Nom");
            //lstVPersonnel.Columns.Add("Prenom");
            //lstVPersonnel.Columns.Add("Tel");
            //lstVPersonnel.Columns.Add("Mail");
        }


        private void btnAjout_Click(object sender, EventArgs e)
        {
            FrmAjoutModif frm = new FrmAjoutModif(null,modifEnCours);
            //this.Hide();
            frm.ShowDialog();
        }

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
                //this.Hide();
                frm.ShowDialog();
            }
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = lstVPersonnel.SelectedIndices;
            if (indices.Count == 1)
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



        //    /// <summary>
        //    /// Affiche les profils
        //    /// </summary>
        //    private void RemplirListeProfils()
        //    {
        //        List<Profil> lesProfils = controller.GetLesProfils();
        //        bdgProfils.DataSource = lesProfils;
        //        cboProfil.DataSource = bdgProfils;
        //    }

        //    /// <summary>
        //    ///  Demande de modification d'un développeur
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnDemandeModifDev_Click(object sender, EventArgs e)
        //    {
        //        if (dgvDeveloppeurs.SelectedRows.Count > 0)
        //        {
        //            EnCourseModifDeveloppeur(true);
        //            Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
        //            txtNom.Text = developpeur.Nom;
        //            txtPrenom.Text = developpeur.Prenom;
        //            txtTel.Text = developpeur.Tel;
        //            txtMail.Text = developpeur.Mail;
        //            cboProfil.SelectedIndex = cboProfil.FindStringExact(developpeur.Profil.Nom);
        //            // le profil peut être changé que si ce n'est pas un admin
        //            cboProfil.Enabled = !developpeur.Profil.Equals(ADMIN);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
        //        }
        //    }

        //    /// <summary>
        //    /// Demande de suppression d'un développeur
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnDemandeSupprDev_Click(object sender, EventArgs e)
        //    {
        //        if (dgvDeveloppeurs.SelectedRows.Count > 0)
        //        {
        //            Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
        //            if (developpeur.Profil.Equals(ADMIN))
        //            {
        //                MessageBox.Show("Un admin ne peut pas être supprimé", "Information");
        //            }
        //            else if (MessageBox.Show("Voulez-vous vraiment supprimer " + developpeur.Nom + " " + developpeur.Prenom + " ?",
        //                "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //            {
        //                controller.DelDeveloppeur(developpeur);
        //                RemplirListeDeveloppeurs();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
        //        }
        //    }

        //    /// <summary>
        //    /// Demande de changement du pwd
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnDemandeChangePwd_Click(object sender, EventArgs e)
        //    {
        //        if (dgvDeveloppeurs.SelectedRows.Count > 0)
        //        {
        //            EnCoursModifPwd(true);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
        //        }
        //    }

        //    /// <summary>
        //    /// Demande d'enregistrement de l'ajout ou de la modification d'un développeur
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnEnregDev_Click(object sender, EventArgs e)
        //    {
        //        if (!txtNom.Text.Equals("") && !txtPrenom.Text.Equals("") && !txtTel.Text.Equals("") && !txtMail.Text.Equals("") && cboProfil.SelectedIndex != -1)
        //        {
        //            Profil profil = (Profil)bdgProfils.List[bdgProfils.Position];
        //            if (enCoursDeModifDeveloppeur)
        //            {
        //                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
        //                developpeur.Nom = txtNom.Text;
        //                developpeur.Prenom = txtPrenom.Text;
        //                developpeur.Tel = txtTel.Text;
        //                developpeur.Mail = txtMail.Text;
        //                developpeur.Profil = profil;
        //                controller.UpdateDeveloppeur(developpeur);
        //            }
        //            else
        //            {
        //                Developpeur developpeur = new Developpeur(0, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, profil);
        //                controller.AddDeveloppeur(developpeur);
        //            }
        //            RemplirListeDeveloppeurs();
        //            EnCourseModifDeveloppeur(false);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tous les champs doivent être remplis.", "Information");
        //        }
        //    }

        //    /// <summary>
        //    /// Annule la demande d'ajout ou de modification d'un développeur
        //    /// Vide les zones de saisie du développeur
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnAnnulDev_Click(object sender, EventArgs e)
        //    {
        //        if (MessageBox.Show("Voulez-vous vraiment annuler ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            EnCourseModifDeveloppeur(false);
        //        }
        //    }

        //    /// <summary>
        //    /// Demande d'enregistrement du nouveau pwd
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnEnregPwd_Click(object sender, EventArgs e)
        //    {
        //        if (!txtPwd1.Text.Equals("") && !txtPwd2.Text.Equals("") && txtPwd1.Text.Equals(txtPwd2.Text))
        //        {
        //            if (controller.PwdFort(txtPwd1.Text))
        //            {
        //                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
        //                developpeur.Pwd = txtPwd1.Text;
        //                controller.UpdatePwd(developpeur);
        //                EnCoursModifPwd(false);
        //            }
        //            else
        //            {
        //                MessageBox.Show("le pwd doit contenir entre 8 et 30 caractères constitués de : au moins une minuscule, une majuscule, un chiffre, un caractère spécial et pas d'espace", "Information");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Les 2 zones doivent être remplies et de contenu identique", "Information");
        //        }
        //    }

        //    /// <summary>
        //    /// Annulation de demande d'enregistrement d'un nouveau pwd
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnAnnulPwd_Click(object sender, EventArgs e)
        //    {
        //        EnCoursModifPwd(false);
        //    }

        //    /// <summary>
        //    /// Modification d'affichage suivant si on est en cours de modif ou d'ajout d'un developpeur
        //    /// </summary>
        //    /// <param name="modif"></param>
        //    private void EnCourseModifDeveloppeur(Boolean modif)
        //    {
        //        enCoursDeModifDeveloppeur = modif;
        //        grbLesDeveloppeurs.Enabled = !modif;
        //        if (modif)
        //        {
        //            grbDeveloppeur.Text = "modifier un développeur";
        //        }
        //        else
        //        {
        //            grbDeveloppeur.Text = "ajouter un développeur";
        //            txtNom.Text = "";
        //            txtPrenom.Text = "";
        //            txtTel.Text = "";
        //            txtMail.Text = "";
        //        }
        //    }

        //    /// <summary>
        //    /// Modification d'affichage suivant si on est ou non en cours de modif du pwd
        //    /// </summary>
        //    /// <param name="modif"></param>
        //    private void EnCoursModifPwd(Boolean modif)
        //    {
        //        grbPwd.Enabled = modif;
        //        grbLesDeveloppeurs.Enabled = !modif;
        //        grbDeveloppeur.Enabled = !modif;
        //        txtPwd1.Text = "";
        //        txtPwd2.Text = "";
        //    }

        //    /// <summary>
        //    /// Demande de suppression d'un profil
        //    /// à condition que ce ne soit pas le profil "admin"
        //    /// et qu'il ne soit pas attribué
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnDelProfil_Click(object sender, EventArgs e)
        //    {
        //        Profil profil = (Profil)bdgProfils.List[bdgProfils.Position];
        //        if (profil.Nom.Equals(ADMIN))
        //        {
        //            MessageBox.Show("Le profil 'admin' ne peut pas être supprimé", "Information");
        //        }
        //        else if (((List<Developpeur>)bdgDeveloppeurs.DataSource).Exists(x => x.Profil.Idprofil == profil.Idprofil))
        //        {
        //            MessageBox.Show("Le profil " + profil.Nom + " ne peut pas être supprimé car il est utilisé");
        //        }
        //        else if (MessageBox.Show("Voulez-vous vraiment supprimer " + profil.Nom + " ?",
        //                "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        {
        //            controller.DelProfil(profil);
        //            RemplirListeProfils();
        //        }
        //    }

        //    /// <summary>
        //    /// Demande d'ajout d'un profil
        //    /// à condition qu'il n'existe pas déjà
        //    /// </summary>
        //    /// <param name="sender"></param>
        //    /// <param name="e"></param>
        //    private void BtnAddProfil_Click(object sender, EventArgs e)
        //    {
        //        string nom = txtProfil.Text.ToString().ToLower();
        //        if (string.IsNullOrEmpty(nom))
        //        {
        //            MessageBox.Show("Saisir un profil", "Information");
        //        }
        //        else if (cboProfil.Items.Contains(nom))
        //        {
        //            MessageBox.Show("Profil déjà présent dans la liste", "Information");
        //        }
        //        else
        //        {
        //            controller.AddProfil(new Profil(0, nom));
        //            txtProfil.Text = "";
        //            RemplirListeProfils();
        //        }
        //    }
    }
}
