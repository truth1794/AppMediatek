
namespace AppMediatek.view
{
    partial class FrmGestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnModif = new System.Windows.Forms.Button();
            this.btnSuppr = new System.Windows.Forms.Button();
            this.btnAfficheAbs = new System.Windows.Forms.Button();
            this.lstVPersonnel = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrenom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(659, 123);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(135, 36);
            this.btnAjout.TabIndex = 1;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(659, 180);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(135, 36);
            this.btnModif.TabIndex = 2;
            this.btnModif.Text = "Modifier";
            this.btnModif.UseVisualStyleBackColor = true;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnSuppr
            // 
            this.btnSuppr.Location = new System.Drawing.Point(659, 235);
            this.btnSuppr.Name = "btnSuppr";
            this.btnSuppr.Size = new System.Drawing.Size(135, 36);
            this.btnSuppr.TabIndex = 3;
            this.btnSuppr.Text = "Supprimer";
            this.btnSuppr.UseVisualStyleBackColor = true;
            this.btnSuppr.Click += new System.EventHandler(this.btnSuppr_Click);
            // 
            // btnAfficheAbs
            // 
            this.btnAfficheAbs.Location = new System.Drawing.Point(659, 296);
            this.btnAfficheAbs.Name = "btnAfficheAbs";
            this.btnAfficheAbs.Size = new System.Drawing.Size(135, 36);
            this.btnAfficheAbs.TabIndex = 4;
            this.btnAfficheAbs.Text = "Voir absences";
            this.btnAfficheAbs.UseVisualStyleBackColor = true;
            this.btnAfficheAbs.Click += new System.EventHandler(this.btnAfficheAbs_Click);
            // 
            // lstVPersonnel
            // 
            this.lstVPersonnel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colService,
            this.colNom,
            this.colPrenom,
            this.colTel,
            this.colMail,
            this.colIdService});
            this.lstVPersonnel.FullRowSelect = true;
            this.lstVPersonnel.HideSelection = false;
            this.lstVPersonnel.Location = new System.Drawing.Point(12, 67);
            this.lstVPersonnel.Name = "lstVPersonnel";
            this.lstVPersonnel.Size = new System.Drawing.Size(627, 427);
            this.lstVPersonnel.TabIndex = 6;
            this.lstVPersonnel.UseCompatibleStateImageBehavior = false;
            this.lstVPersonnel.View = System.Windows.Forms.View.Details;
            this.lstVPersonnel.SelectedIndexChanged += new System.EventHandler(this.lstVPersonnel_SelectedIndexChanged);
            // 
            // colId
            // 
            this.colId.Text = "ID";
            this.colId.Width = 48;
            // 
            // colService
            // 
            this.colService.Text = "Service";
            this.colService.Width = 66;
            // 
            // colNom
            // 
            this.colNom.Text = "Nom";
            this.colNom.Width = 97;
            // 
            // colPrenom
            // 
            this.colPrenom.Text = "Prenom";
            this.colPrenom.Width = 103;
            // 
            // colTel
            // 
            this.colTel.Text = "Tel";
            this.colTel.Width = 96;
            // 
            // colMail
            // 
            this.colMail.Text = "Mail";
            this.colMail.Width = 177;
            // 
            // colIdService
            // 
            this.colIdService.Text = "IdService";
            this.colIdService.Width = 0;
            // 
            // FrmGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 514);
            this.Controls.Add(this.lstVPersonnel);
            this.Controls.Add(this.btnAfficheAbs);
            this.Controls.Add(this.btnSuppr);
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.btnAjout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmGestion";
            this.Text = "Gestion du personnel";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnModif;
        private System.Windows.Forms.Button btnSuppr;
        private System.Windows.Forms.Button btnAfficheAbs;
        private System.Windows.Forms.ListView lstVPersonnel;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colService;
        private System.Windows.Forms.ColumnHeader colNom;
        private System.Windows.Forms.ColumnHeader colPrenom;
        private System.Windows.Forms.ColumnHeader colTel;
        private System.Windows.Forms.ColumnHeader colMail;
        private System.Windows.Forms.ColumnHeader colIdService;
    }
}