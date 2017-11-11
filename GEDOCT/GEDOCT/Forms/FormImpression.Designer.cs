namespace GEDOCT.Forms
{
    partial class FormImpression
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImpression));
            this.plFicheImpression = new System.Windows.Forms.Panel();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            this.pbFSM = new System.Windows.Forms.PictureBox();
            this.grpImpression = new System.Windows.Forms.GroupBox();
            this.grpFicheImpression = new System.Windows.Forms.GroupBox();
            this.grpGererImpression = new System.Windows.Forms.GroupBox();
            this.btnAfficherRapport = new System.Windows.Forms.Button();
            this.plPagination = new System.Windows.Forms.Panel();
            this.lblNumPage = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnDebut = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnFin = new System.Windows.Forms.Button();
            this.lblNavigation = new System.Windows.Forms.Label();
            this.cmbValeur = new System.Windows.Forms.ComboBox();
            this.lblValeur = new System.Windows.Forms.Label();
            this.cmbCritere = new System.Windows.Forms.ComboBox();
            this.lblCritere = new System.Windows.Forms.Label();
            this.plFicheImpression.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFSM)).BeginInit();
            this.grpImpression.SuspendLayout();
            this.grpFicheImpression.SuspendLayout();
            this.grpGererImpression.SuspendLayout();
            this.plPagination.SuspendLayout();
            this.SuspendLayout();
            // 
            // plFicheImpression
            // 
            this.plFicheImpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plFicheImpression.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.plFicheImpression.Controls.Add(this.pbHeader);
            this.plFicheImpression.Controls.Add(this.pbFSM);
            this.plFicheImpression.Location = new System.Drawing.Point(12, 12);
            this.plFicheImpression.Name = "plFicheImpression";
            this.plFicheImpression.Size = new System.Drawing.Size(1061, 146);
            this.plFicheImpression.TabIndex = 0;
            // 
            // pbHeader
            // 
            this.pbHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbHeader.Image = ((System.Drawing.Image)(resources.GetObject("pbHeader.Image")));
            this.pbHeader.Location = new System.Drawing.Point(145, 4);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(911, 138);
            this.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHeader.TabIndex = 1;
            this.pbHeader.TabStop = false;
            // 
            // pbFSM
            // 
            this.pbFSM.Image = ((System.Drawing.Image)(resources.GetObject("pbFSM.Image")));
            this.pbFSM.Location = new System.Drawing.Point(4, 4);
            this.pbFSM.Name = "pbFSM";
            this.pbFSM.Size = new System.Drawing.Size(138, 138);
            this.pbFSM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFSM.TabIndex = 0;
            this.pbFSM.TabStop = false;
            // 
            // grpImpression
            // 
            this.grpImpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImpression.Controls.Add(this.grpFicheImpression);
            this.grpImpression.Controls.Add(this.grpGererImpression);
            this.grpImpression.Location = new System.Drawing.Point(12, 165);
            this.grpImpression.Name = "grpImpression";
            this.grpImpression.Size = new System.Drawing.Size(1061, 397);
            this.grpImpression.TabIndex = 1;
            this.grpImpression.TabStop = false;
            // 
            // grpFicheImpression
            // 
            this.grpFicheImpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFicheImpression.Location = new System.Drawing.Point(238, 20);
            this.grpFicheImpression.Name = "grpFicheImpression";
            this.grpFicheImpression.Size = new System.Drawing.Size(817, 371);
            this.grpFicheImpression.TabIndex = 1;
            this.grpFicheImpression.TabStop = false;
            // 
     
            // grpGererImpression
            // 
            this.grpGererImpression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpGererImpression.Controls.Add(this.btnAfficherRapport);
            this.grpGererImpression.Controls.Add(this.plPagination);
            this.grpGererImpression.Controls.Add(this.cmbValeur);
            this.grpGererImpression.Controls.Add(this.lblValeur);
            this.grpGererImpression.Controls.Add(this.cmbCritere);
            this.grpGererImpression.Controls.Add(this.lblCritere);
            this.grpGererImpression.Location = new System.Drawing.Point(7, 20);
            this.grpGererImpression.Name = "grpGererImpression";
            this.grpGererImpression.Size = new System.Drawing.Size(223, 371);
            this.grpGererImpression.TabIndex = 0;
            this.grpGererImpression.TabStop = false;
            this.grpGererImpression.Text = "Choisissez les champs à afficher";
            // 
            // btnAfficherRapport
            // 
            this.btnAfficherRapport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfficherRapport.Image = ((System.Drawing.Image)(resources.GetObject("btnAfficherRapport.Image")));
            this.btnAfficherRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAfficherRapport.Location = new System.Drawing.Point(43, 292);
            this.btnAfficherRapport.Name = "btnAfficherRapport";
            this.btnAfficherRapport.Size = new System.Drawing.Size(138, 40);
            this.btnAfficherRapport.TabIndex = 5;
            this.btnAfficherRapport.Text = "Afficher Rapport";
            this.btnAfficherRapport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAfficherRapport.UseVisualStyleBackColor = true;
            // 
            // plPagination
            // 
            this.plPagination.Controls.Add(this.lblNumPage);
            this.plPagination.Controls.Add(this.lblPage);
            this.plPagination.Controls.Add(this.btnDebut);
            this.plPagination.Controls.Add(this.button3);
            this.plPagination.Controls.Add(this.button2);
            this.plPagination.Controls.Add(this.btnFin);
            this.plPagination.Controls.Add(this.lblNavigation);
            this.plPagination.Location = new System.Drawing.Point(6, 121);
            this.plPagination.Name = "plPagination";
            this.plPagination.Size = new System.Drawing.Size(211, 146);
            this.plPagination.TabIndex = 4;
            // 
            // lblNumPage
            // 
            this.lblNumPage.AutoSize = true;
            this.lblNumPage.Location = new System.Drawing.Point(82, 99);
            this.lblNumPage.Name = "lblNumPage";
            this.lblNumPage.Size = new System.Drawing.Size(0, 13);
            this.lblNumPage.TabIndex = 6;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(34, 122);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(39, 15);
            this.lblPage.TabIndex = 5;
            this.lblPage.Text = "Page :";
            // 
            // btnDebut
            // 
            this.btnDebut.Image = ((System.Drawing.Image)(resources.GetObject("btnDebut.Image")));
            this.btnDebut.Location = new System.Drawing.Point(37, 69);
            this.btnDebut.Name = "btnDebut";
            this.btnDebut.Size = new System.Drawing.Size(30, 30);
            this.btnDebut.TabIndex = 4;
            this.btnDebut.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(109, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(73, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnFin
            // 
            this.btnFin.Image = ((System.Drawing.Image)(resources.GetObject("btnFin.Image")));
            this.btnFin.Location = new System.Drawing.Point(145, 69);
            this.btnFin.Name = "btnFin";
            this.btnFin.Size = new System.Drawing.Size(30, 30);
            this.btnFin.TabIndex = 1;
            this.btnFin.UseVisualStyleBackColor = true;
            // 
            // lblNavigation
            // 
            this.lblNavigation.AutoSize = true;
            this.lblNavigation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavigation.Location = new System.Drawing.Point(12, 9);
            this.lblNavigation.Name = "lblNavigation";
            this.lblNavigation.Size = new System.Drawing.Size(186, 19);
            this.lblNavigation.TabIndex = 0;
            this.lblNavigation.Text = "Navigation dans le rapport";
            // 
            // cmbValeur
            // 
            this.cmbValeur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValeur.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbValeur.FormattingEnabled = true;
            this.cmbValeur.Location = new System.Drawing.Point(64, 68);
            this.cmbValeur.Name = "cmbValeur";
            this.cmbValeur.Size = new System.Drawing.Size(153, 23);
            this.cmbValeur.TabIndex = 3;
            // 
            // lblValeur
            // 
            this.lblValeur.AutoSize = true;
            this.lblValeur.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValeur.Location = new System.Drawing.Point(6, 72);
            this.lblValeur.Name = "lblValeur";
            this.lblValeur.Size = new System.Drawing.Size(40, 15);
            this.lblValeur.TabIndex = 2;
            this.lblValeur.Text = "Valeur";
            // 
            // cmbCritere
            // 
            this.cmbCritere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCritere.DropDownWidth = 180;
            this.cmbCritere.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCritere.FormattingEnabled = true;
            this.cmbCritere.Items.AddRange(new object[] {
            "Spécialité",
            "Niveau ou nombre d\'inscriptions",
            "Dérogataires",
            "Fiche par Doctorant"});
            this.cmbCritere.Location = new System.Drawing.Point(64, 38);
            this.cmbCritere.Name = "cmbCritere";
            this.cmbCritere.Size = new System.Drawing.Size(153, 23);
            this.cmbCritere.TabIndex = 1;
            this.cmbCritere.SelectedIndexChanged += new System.EventHandler(this.cmbCritere_SelectedIndexChanged);
            // 
            // lblCritere
            // 
            this.lblCritere.AutoSize = true;
            this.lblCritere.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCritere.Location = new System.Drawing.Point(6, 42);
            this.lblCritere.Name = "lblCritere";
            this.lblCritere.Size = new System.Drawing.Size(42, 15);
            this.lblCritere.TabIndex = 0;
            this.lblCritere.Text = "Critère";
            // 
            // FormImpression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 574);
            this.Controls.Add(this.grpImpression);
            this.Controls.Add(this.plFicheImpression);
            this.Name = "FormImpression";
            this.Text = "Gérer les impressions";
            this.plFicheImpression.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFSM)).EndInit();
            this.grpImpression.ResumeLayout(false);
            this.grpFicheImpression.ResumeLayout(false);
            this.grpGererImpression.ResumeLayout(false);
            this.grpGererImpression.PerformLayout();
            this.plPagination.ResumeLayout(false);
            this.plPagination.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plFicheImpression;
        private System.Windows.Forms.PictureBox pbFSM;
        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.GroupBox grpImpression;
        private System.Windows.Forms.GroupBox grpFicheImpression;
        private System.Windows.Forms.GroupBox grpGererImpression;
        private System.Windows.Forms.ComboBox cmbValeur;
        private System.Windows.Forms.Label lblValeur;
        private System.Windows.Forms.ComboBox cmbCritere;
        private System.Windows.Forms.Label lblCritere;
        private System.Windows.Forms.Panel plPagination;
        private System.Windows.Forms.Label lblNavigation;
        private System.Windows.Forms.Button btnDebut;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnFin;
        private System.Windows.Forms.Button btnAfficherRapport;
        private System.Windows.Forms.Label lblNumPage;
        private System.Windows.Forms.Label lblPage;


    }
}