
namespace app_mediatek
{
    partial class Form2
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnModif = new System.Windows.Forms.Button();
            this.btnSuppr = new System.Windows.Forms.Button();
            this.btnAfficheAbs = new System.Windows.Forms.Button();
            this.btnDeco = new System.Windows.Forms.Button();
            this.grpBtns = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabListPerso = new System.Windows.Forms.TabPage();
            this.lstPerso = new System.Windows.Forms.ListBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.picId = new System.Windows.Forms.PictureBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabListPerso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picId)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 95);
            this.btnSave.TabIndex = 0;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnAjout
            // 
            this.btnAjout.Location = new System.Drawing.Point(94, 13);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(75, 95);
            this.btnAjout.TabIndex = 1;
            this.btnAjout.UseVisualStyleBackColor = true;
            // 
            // btnModif
            // 
            this.btnModif.Location = new System.Drawing.Point(175, 13);
            this.btnModif.Name = "btnModif";
            this.btnModif.Size = new System.Drawing.Size(75, 95);
            this.btnModif.TabIndex = 2;
            this.btnModif.UseVisualStyleBackColor = true;
            // 
            // btnSuppr
            // 
            this.btnSuppr.Location = new System.Drawing.Point(256, 13);
            this.btnSuppr.Name = "btnSuppr";
            this.btnSuppr.Size = new System.Drawing.Size(75, 95);
            this.btnSuppr.TabIndex = 3;
            this.btnSuppr.UseVisualStyleBackColor = true;
            // 
            // btnAfficheAbs
            // 
            this.btnAfficheAbs.Location = new System.Drawing.Point(414, 12);
            this.btnAfficheAbs.Name = "btnAfficheAbs";
            this.btnAfficheAbs.Size = new System.Drawing.Size(75, 95);
            this.btnAfficheAbs.TabIndex = 4;
            this.btnAfficheAbs.UseVisualStyleBackColor = true;
            // 
            // btnDeco
            // 
            this.btnDeco.Location = new System.Drawing.Point(496, 12);
            this.btnDeco.Name = "btnDeco";
            this.btnDeco.Size = new System.Drawing.Size(75, 95);
            this.btnDeco.TabIndex = 5;
            this.btnDeco.UseVisualStyleBackColor = true;
            // 
            // grpBtns
            // 
            this.grpBtns.Location = new System.Drawing.Point(0, -4);
            this.grpBtns.Name = "grpBtns";
            this.grpBtns.Size = new System.Drawing.Size(582, 139);
            this.grpBtns.TabIndex = 6;
            this.grpBtns.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabListPerso);
            this.tabControl1.Location = new System.Drawing.Point(0, 141);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 617);
            this.tabControl1.TabIndex = 7;
            // 
            // tabListPerso
            // 
            this.tabListPerso.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabListPerso.Controls.Add(this.lblService);
            this.tabListPerso.Controls.Add(this.cmbService);
            this.tabListPerso.Controls.Add(this.picId);
            this.tabListPerso.Controls.Add(this.lblMail);
            this.tabListPerso.Controls.Add(this.lblTel);
            this.tabListPerso.Controls.Add(this.lblPrenom);
            this.tabListPerso.Controls.Add(this.lblNom);
            this.tabListPerso.Controls.Add(this.txtMail);
            this.tabListPerso.Controls.Add(this.txtTel);
            this.tabListPerso.Controls.Add(this.txtPrenom);
            this.tabListPerso.Controls.Add(this.txtNom);
            this.tabListPerso.Controls.Add(this.lstPerso);
            this.tabListPerso.Location = new System.Drawing.Point(4, 25);
            this.tabListPerso.Name = "tabListPerso";
            this.tabListPerso.Padding = new System.Windows.Forms.Padding(3);
            this.tabListPerso.Size = new System.Drawing.Size(574, 588);
            this.tabListPerso.TabIndex = 0;
            this.tabListPerso.Text = "Liste du personel";
            this.tabListPerso.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lstPerso
            // 
            this.lstPerso.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lstPerso.FormattingEnabled = true;
            this.lstPerso.ItemHeight = 16;
            this.lstPerso.Location = new System.Drawing.Point(0, 0);
            this.lstPerso.Name = "lstPerso";
            this.lstPerso.Size = new System.Drawing.Size(205, 644);
            this.lstPerso.TabIndex = 0;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMail.Location = new System.Drawing.Point(253, 446);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(50, 20);
            this.lblMail.TabIndex = 17;
            this.lblMail.Text = "Mail :";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTel.Location = new System.Drawing.Point(260, 375);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(42, 20);
            this.lblTel.TabIndex = 16;
            this.lblTel.Text = "Tel :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenom.Location = new System.Drawing.Point(226, 309);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(77, 20);
            this.lblPrenom.TabIndex = 15;
            this.lblPrenom.Text = "Prenom :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(248, 243);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(54, 20);
            this.lblNom.TabIndex = 14;
            this.lblNom.Text = "Nom :";
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(308, 439);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(186, 30);
            this.txtMail.TabIndex = 13;
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.Location = new System.Drawing.Point(308, 368);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(186, 30);
            this.txtTel.TabIndex = 12;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrenom.Location = new System.Drawing.Point(308, 302);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(186, 30);
            this.txtPrenom.TabIndex = 11;
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNom.Location = new System.Drawing.Point(308, 236);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(186, 30);
            this.txtNom.TabIndex = 10;
            // 
            // picId
            // 
            this.picId.Location = new System.Drawing.Point(308, 20);
            this.picId.Name = "picId";
            this.picId.Size = new System.Drawing.Size(161, 192);
            this.picId.TabIndex = 18;
            this.picId.TabStop = false;
            // 
            // cmbService
            // 
            this.cmbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Location = new System.Drawing.Point(308, 518);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(186, 33);
            this.cmbService.TabIndex = 19;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(248, 525);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(50, 20);
            this.lblService.TabIndex = 20;
            this.lblService.Text = "Mail :";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 763);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnDeco);
            this.Controls.Add(this.btnAfficheAbs);
            this.Controls.Add(this.btnSuppr);
            this.Controls.Add(this.btnModif);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpBtns);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabListPerso.ResumeLayout(false);
            this.tabListPerso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnModif;
        private System.Windows.Forms.Button btnSuppr;
        private System.Windows.Forms.Button btnAfficheAbs;
        private System.Windows.Forms.Button btnDeco;
        private System.Windows.Forms.GroupBox grpBtns;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabListPerso;
        private System.Windows.Forms.ListBox lstPerso;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.PictureBox picId;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
    }
}