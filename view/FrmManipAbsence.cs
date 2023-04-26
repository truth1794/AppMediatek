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

        /// <summary>
        /// Entier contenant l'ID du personnel selectionne
        /// </summary>
        private int idPersonnel;
        /// <summary>
        /// chaine contenant la date de debut de l'absence a changer
        /// </summary>
        private string dateDebutToChange;

        /// <summary>
        /// construction des composants graphiques et appel des autres initialisations
        /// </summary>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="idMotif"></param>
        /// <param name="modifEnCours"></param>
        /// <param name="idPersonnel"></param>
        public FrmManipAbsence(string dateDebut, string dateFin, int idMotif, bool modifEnCours, int idPersonnel)
        {
            InitializeComponent();
            Init(dateDebut, dateFin, idMotif, modifEnCours, idPersonnel);
        }

        /// <summary>
        /// Initialisations :
        /// Création du controleur et remplissage des listes
        /// </summary>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="idMotif"></param>
        /// <param name="modifEnCours"></param>
        /// <param name="idPersonnel"></param>
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
        }

        /// <summary>
        /// Bouton de validation de la modification ou l'ajout d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton d'annulation de la modification ou l'ajout d'une absence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Appel de la fonction pour ajouter une absence
        /// </summary>
        private void AddAbsence()
        {
            controller.AddAbsence(new Absence(
                idPersonnel,
                dateTDebut.Value,
                cmbMotif.SelectedIndex + 1,
                dateTFin.Value,
                null));
        }

        /// <summary>
        /// Appel de la fonction pour mettre a jour une absence
        /// </summary>
        private void UpdateAbsence()
        {
            Absence updatedAbsence = new Absence(idPersonnel, dateTDebut.Value, cmbMotif.SelectedIndex + 1, dateTFin.Value, null);
            Absence AbsenceToUpdate = new Absence(idPersonnel, DateTime.Parse(dateDebutToChange), 1, DateTime.Today, null);
            controller.UpdateAbsence(updatedAbsence, AbsenceToUpdate);
        }
    }
}
