
namespace AppMediatek.view
{
    partial class FrmAffichAbsence
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
            this.lstVAbsences = new System.Windows.Forms.ListView();
            this.colDateDebut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateFin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMotif = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdMotif = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblNomDef = new System.Windows.Forms.Label();
            this.lblPrenomDef = new System.Windows.Forms.Label();
            this.lblServiceDef = new System.Windows.Forms.Label();
            this.btnSuppr = new System.Windows.Forms.Button();
            this.btnModif = new System.Windows.Forms.Button();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnRetour = new System.Windows.Forms.Button();
            this.lblNbAbsencesDef = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblNbAbsences = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstVAbsences
            // 
            this.lstVAbsences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDateDebut,
            this.colDateFin,
            this.colMotif,
            this.colIdMotif});
            this.lstVAbsences.FullRowSelect = true;
            this.lstVAbsences.HideSelection = false;
            this.lstVAbsences.Location = new System.Drawing.Point(12, 67);
            this.lstVAbsences.Name = "lstVAbsences";
            this.lstVAbsences.Size = new System.Drawing.Size(489, 335);
            this.lstVAbsences.TabIndex = 0;
            this.lstVAbsences.UseCompatibleStateImageBehavior = false;
            this.lstVAbsences.View = System.Windows.Forms.View.Details;
            this.lstVAbsences.SelectedIndexChanged += new System.EventHandler(this.lstVAbsences_SelectedIndexChanged);
            // 
            // colDateDebut
            // 
            this.colDateDebut.Text = "Date Debut";
            this.colDateDebut.Width = 150;
            // 
            // colDateFin
            // 
            this.colDateFin.Text = "Date Fin";
            this.colDateFin.Width = 160;
            // 
            // colMotif
            // 
            this.colMotif.Text = "Motif";
            this.colMotif.Width = 171;
            // 
            // colIdMotif
            // 
            this.colIdMotif.Width = 0;
            // 
            // lblNomDef
            // 
            this.lblNomDef.AutoSize = true;
            this.lblNomDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomDef.Location = new System.Drawing.Point(32, 9);
            this.lblNomDef.Name = "lblNomDef";
            this.lblNomDef.Size = new System.Drawing.Size(53, 18);
            this.lblNomDef.TabIndex = 1;
            this.lblNomDef.Text = "Nom : ";
            // 
            // lblPrenomDef
            // 
            this.lblPrenomDef.AutoSize = true;
            this.lblPrenomDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenomDef.Location = new System.Drawing.Point(12, 37);
            this.lblPrenomDef.Name = "lblPrenomDef";
            this.lblPrenomDef.Size = new System.Drawing.Size(73, 18);
            this.lblPrenomDef.TabIndex = 2;
            this.lblPrenomDef.Text = "Prenom : ";
            // 
            // lblServiceDef
            // 
            this.lblServiceDef.AutoSize = true;
            this.lblServiceDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceDef.Location = new System.Drawing.Point(310, 9);
            this.lblServiceDef.Name = "lblServiceDef";
            this.lblServiceDef.Size = new System.Drawing.Size(69, 18);
            this.lblServiceDef.TabIndex = 3;
            this.lblServiceDef.Text = "Service : ";
            // 
            // btnSuppr
            // 
            this.btnSuppr.Location = new System.Drawing.Point(528, 207);
            this.btnSuppr.Name = "btnSuppr";
            this.btnSuppr.Size = new System.Drawing.Size(135, 36);
            this.btnSuppr.TabIndex = 6;
            this.btnSuppr.Text = "Supprimer";
            this.btnSuppr.UseVisualStyleBackColor = true;
            this.btnSuppr.Click += new System.EventHandler(this.btnSuppr_Click);
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(528, 152);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(135, 36);
            this.btnModif.TabIndex = 5;
            this.btnModif.Text = "Modifier";
            this.btnModif.UseVisualStyleBackColor = true;
            this.btnModif.Click += new System.EventHandler(this.btnModif_Click);
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(528, 95);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(135, 36);
            this.btnAjout.TabIndex = 4;
            this.btnAjout.Text = "Ajouter";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // btnRetour
            // 
            this.btnRetour.Location = new System.Drawing.Point(528, 305);
            this.btnRetour.Name = "btnRetour";
            this.btnRetour.Size = new System.Drawing.Size(135, 36);
            this.btnRetour.TabIndex = 7;
            this.btnRetour.Text = "Retour";
            this.btnRetour.UseVisualStyleBackColor = true;
            this.btnRetour.Click += new System.EventHandler(this.btnRetour_Click);
            // 
            // lblNbAbsencesDef
            // 
            this.lblNbAbsencesDef.AutoSize = true;
            this.lblNbAbsencesDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbAbsencesDef.Location = new System.Drawing.Point(226, 37);
            this.lblNbAbsencesDef.Name = "lblNbAbsencesDef";
            this.lblNbAbsencesDef.Size = new System.Drawing.Size(153, 18);
            this.lblNbAbsencesDef.TabIndex = 8;
            this.lblNbAbsencesDef.Text = "Nombre d\'absences : ";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(87, 9);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(59, 20);
            this.lblNom.TabIndex = 9;
            this.lblNom.Text = "label1";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenom.Location = new System.Drawing.Point(87, 37);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(59, 20);
            this.lblPrenom.TabIndex = 10;
            this.lblPrenom.Text = "label2";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(385, 8);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(59, 20);
            this.lblService.TabIndex = 11;
            this.lblService.Text = "label3";
            // 
            // lblNbAbsences
            // 
            this.lblNbAbsences.AutoSize = true;
            this.lblNbAbsences.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbAbsences.Location = new System.Drawing.Point(385, 36);
            this.lblNbAbsences.Name = "lblNbAbsences";
            this.lblNbAbsences.Size = new System.Drawing.Size(59, 20);
            this.lblNbAbsences.TabIndex = 12;
            this.lblNbAbsences.Text = "label4";
            // 
            // FrmAffichAbsence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 411);
            this.Controls.Add(this.lblNbAbsences);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblNbAbsencesDef);
            this.Controls.Add(this.btnRetour);
            this.Controls.Add(this.btnSuppr);
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.lblServiceDef);
            this.Controls.Add(this.lblPrenomDef);
            this.Controls.Add(this.lblNomDef);
            this.Controls.Add(this.lstVAbsences);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmAffichAbsence";
            this.Text = "Absences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstVAbsences;
        private System.Windows.Forms.Label lblNomDef;
        private System.Windows.Forms.Label lblPrenomDef;
        private System.Windows.Forms.Label lblServiceDef;
        private System.Windows.Forms.ColumnHeader colDateDebut;
        private System.Windows.Forms.ColumnHeader colDateFin;
        private System.Windows.Forms.ColumnHeader colMotif;
        private System.Windows.Forms.Button btnSuppr;
        private System.Windows.Forms.Button btnModif;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnRetour;
        private System.Windows.Forms.Label lblNbAbsencesDef;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.Label lblNbAbsences;
        private System.Windows.Forms.ColumnHeader colIdMotif;
    }
}