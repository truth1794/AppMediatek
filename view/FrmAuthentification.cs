using AppMediatek.controller;
using AppMediatek.Model;
using System;
using System.Windows.Forms;

namespace AppMediatek.view
{
    /// <summary>
    /// Fenêtre d'authentification (seuls les developpeurs profil "admin" peuvent accéder à l'application)
    /// </summary>
    public partial class FrmAuthentification : Form
    {
        /// <summary>
        /// Contrôleur de la fenêtre
        /// </summary>
        private FrmAuthentificationController controller;

        /// <summary>
        /// Conrtuction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmAuthentification()
        {
            InitializeComponent();
            Init();
        }
        private void FrmAuthentification_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Initialisations : 
        /// Création du controleur
        /// </summary>
        private void Init()
        {
            controller = new FrmAuthentificationController();
            txtPwd.PasswordChar = '*';
        }

        /// <summary>
        /// Demande au controleur de controler l'authentification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pwd = txtPwd.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
            else
            {
                Responsable responsable = new Responsable(username, pwd);
                if (controller.ControleAuthentification(responsable))
                {
                    FrmGestion frm = new FrmGestion();
                    this.Hide();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Authentification incorrecte ou vous n'êtes pas admin", "Alerte");
                }
            }
        }

    }
}
