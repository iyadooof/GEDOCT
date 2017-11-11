namespace GEDOCT.Forms
{
    partial class GestionInscriptions
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionInscriptions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbFiche = new System.Windows.Forms.PictureBox();
            this.pbFicheInscrit = new System.Windows.Forms.PictureBox();
            this.grpFicheInscrits = new System.Windows.Forms.GroupBox();
            this.pbComment = new System.Windows.Forms.PictureBox();
            this.pbNiveau = new System.Windows.Forms.PictureBox();
            this.pbAnnee = new System.Windows.Forms.PictureBox();
            this.lblNbCaracteresSaisis = new System.Windows.Forms.Label();
            this.lblCaratèresTotal = new System.Windows.Forms.Label();
            this.btnTerminer = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.txtCommentaire = new System.Windows.Forms.TextBox();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.cmbNiveau = new System.Windows.Forms.ComboBox();
            this.lblNiveau = new System.Windows.Forms.Label();
            this.cmbAnnee = new System.Windows.Forms.ComboBox();
            this.lblAnnee = new System.Windows.Forms.Label();
            this.ToolTipErrorInfo = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFiche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFicheInscrit)).BeginInit();
            this.grpFicheInscrits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnnee)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbFiche);
            this.panel1.Controls.Add(this.pbFicheInscrit);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 81);
            this.panel1.TabIndex = 0;
            // 
            // pbFiche
            // 
            this.pbFiche.Image = ((System.Drawing.Image)(resources.GetObject("pbFiche.Image")));
            this.pbFiche.Location = new System.Drawing.Point(78, 4);
            this.pbFiche.Name = "pbFiche";
            this.pbFiche.Size = new System.Drawing.Size(480, 73);
            this.pbFiche.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFiche.TabIndex = 1;
            this.pbFiche.TabStop = false;
            // 
            // pbFicheInscrit
            // 
            this.pbFicheInscrit.Image = ((System.Drawing.Image)(resources.GetObject("pbFicheInscrit.Image")));
            this.pbFicheInscrit.Location = new System.Drawing.Point(4, 4);
            this.pbFicheInscrit.Name = "pbFicheInscrit";
            this.pbFicheInscrit.Size = new System.Drawing.Size(68, 73);
            this.pbFicheInscrit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFicheInscrit.TabIndex = 0;
            this.pbFicheInscrit.TabStop = false;
            // 
            // grpFicheInscrits
            // 
            this.grpFicheInscrits.Controls.Add(this.pbComment);
            this.grpFicheInscrits.Controls.Add(this.pbNiveau);
            this.grpFicheInscrits.Controls.Add(this.pbAnnee);
            this.grpFicheInscrits.Controls.Add(this.lblNbCaracteresSaisis);
            this.grpFicheInscrits.Controls.Add(this.lblCaratèresTotal);
            this.grpFicheInscrits.Controls.Add(this.btnTerminer);
            this.grpFicheInscrits.Controls.Add(this.btnValider);
            this.grpFicheInscrits.Controls.Add(this.txtCommentaire);
            this.grpFicheInscrits.Controls.Add(this.lblCommentaire);
            this.grpFicheInscrits.Controls.Add(this.cmbNiveau);
            this.grpFicheInscrits.Controls.Add(this.lblNiveau);
            this.grpFicheInscrits.Controls.Add(this.cmbAnnee);
            this.grpFicheInscrits.Controls.Add(this.lblAnnee);
            this.grpFicheInscrits.Location = new System.Drawing.Point(13, 101);
            this.grpFicheInscrits.Name = "grpFicheInscrits";
            this.grpFicheInscrits.Size = new System.Drawing.Size(561, 205);
            this.grpFicheInscrits.TabIndex = 1;
            this.grpFicheInscrits.TabStop = false;
            // 
            // pbComment
            // 
            this.pbComment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbComment.Location = new System.Drawing.Point(526, 56);
            this.pbComment.Name = "pbComment";
            this.pbComment.Size = new System.Drawing.Size(20, 20);
            this.pbComment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbComment.TabIndex = 64;
            this.pbComment.TabStop = false;
            // 
            // pbNiveau
            // 
            this.pbNiveau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbNiveau.Location = new System.Drawing.Point(526, 29);
            this.pbNiveau.Name = "pbNiveau";
            this.pbNiveau.Size = new System.Drawing.Size(20, 20);
            this.pbNiveau.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbNiveau.TabIndex = 63;
            this.pbNiveau.TabStop = false;
            // 
            // pbAnnee
            // 
            this.pbAnnee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAnnee.Location = new System.Drawing.Point(256, 29);
            this.pbAnnee.Name = "pbAnnee";
            this.pbAnnee.Size = new System.Drawing.Size(20, 20);
            this.pbAnnee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAnnee.TabIndex = 62;
            this.pbAnnee.TabStop = false;
            // 
            // lblNbCaracteresSaisis
            // 
            this.lblNbCaracteresSaisis.Location = new System.Drawing.Point(403, 59);
            this.lblNbCaracteresSaisis.Name = "lblNbCaracteresSaisis";
            this.lblNbCaracteresSaisis.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNbCaracteresSaisis.Size = new System.Drawing.Size(25, 13);
            this.lblNbCaracteresSaisis.TabIndex = 9;
            this.lblNbCaracteresSaisis.Text = "0";
            this.lblNbCaracteresSaisis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaratèresTotal
            // 
            this.lblCaratèresTotal.AutoSize = true;
            this.lblCaratèresTotal.Location = new System.Drawing.Point(428, 59);
            this.lblCaratèresTotal.Name = "lblCaratèresTotal";
            this.lblCaratèresTotal.Size = new System.Drawing.Size(89, 13);
            this.lblCaratèresTotal.TabIndex = 8;
            this.lblCaratèresTotal.Text = "/1024 caractères";
            // 
            // btnTerminer
            // 
            this.btnTerminer.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminer.Image")));
            this.btnTerminer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminer.Location = new System.Drawing.Point(277, 157);
            this.btnTerminer.Name = "btnTerminer";
            this.btnTerminer.Size = new System.Drawing.Size(88, 30);
            this.btnTerminer.TabIndex = 7;
            this.btnTerminer.Text = "Terminer";
            this.btnTerminer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTerminer.UseVisualStyleBackColor = true;
            this.btnTerminer.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnValider.Image = ((System.Drawing.Image)(resources.GetObject("btnValider.Image")));
            this.btnValider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValider.Location = new System.Drawing.Point(183, 157);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(88, 30);
            this.btnValider.TabIndex = 6;
            this.btnValider.Text = "Valider";
            this.btnValider.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // txtCommentaire
            // 
            this.txtCommentaire.Location = new System.Drawing.Point(105, 56);
            this.txtCommentaire.MaxLength = 350;
            this.txtCommentaire.Multiline = true;
            this.txtCommentaire.Name = "txtCommentaire";
            this.txtCommentaire.Size = new System.Drawing.Size(415, 81);
            this.txtCommentaire.TabIndex = 5;
            this.txtCommentaire.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCommentaire_KeyPress);
            this.txtCommentaire.Validated += new System.EventHandler(this.txtCommentaire_Validated);
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.AutoSize = true;
            this.lblCommentaire.Location = new System.Drawing.Point(31, 59);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(68, 13);
            this.lblCommentaire.TabIndex = 4;
            this.lblCommentaire.Text = "Commentaire";
            // 
            // cmbNiveau
            // 
            this.cmbNiveau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNiveau.FormattingEnabled = true;
            this.cmbNiveau.Location = new System.Drawing.Point(376, 29);
            this.cmbNiveau.Name = "cmbNiveau";
            this.cmbNiveau.Size = new System.Drawing.Size(144, 21);
            this.cmbNiveau.TabIndex = 3;
            this.cmbNiveau.Validated += new System.EventHandler(this.cmbNiveau_Validated);
            // 
            // lblNiveau
            // 
            this.lblNiveau.AutoSize = true;
            this.lblNiveau.Location = new System.Drawing.Point(324, 32);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(41, 13);
            this.lblNiveau.TabIndex = 2;
            this.lblNiveau.Text = "Niveau";
            // 
            // cmbAnnee
            // 
            this.cmbAnnee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnnee.FormattingEnabled = true;
            this.cmbAnnee.Location = new System.Drawing.Point(106, 29);
            this.cmbAnnee.Name = "cmbAnnee";
            this.cmbAnnee.Size = new System.Drawing.Size(144, 21);
            this.cmbAnnee.TabIndex = 1;
            this.cmbAnnee.Validated += new System.EventHandler(this.cmbAnnee_Validated);
            // 
            // lblAnnee
            // 
            this.lblAnnee.AutoSize = true;
            this.lblAnnee.Location = new System.Drawing.Point(31, 32);
            this.lblAnnee.Name = "lblAnnee";
            this.lblAnnee.Size = new System.Drawing.Size(38, 13);
            this.lblAnnee.TabIndex = 0;
            this.lblAnnee.Text = "Année";
            // 
            // GestionInscriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 319);
            this.Controls.Add(this.grpFicheInscrits);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(602, 358);
            this.MinimumSize = new System.Drawing.Size(602, 358);
            this.Name = "GestionInscriptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des inscriptions";
            this.Load += new System.EventHandler(this.GestionInscriptions_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFiche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFicheInscrit)).EndInit();
            this.grpFicheInscrits.ResumeLayout(false);
            this.grpFicheInscrits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnnee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbFicheInscrit;
        private System.Windows.Forms.PictureBox pbFiche;
        private System.Windows.Forms.GroupBox grpFicheInscrits;
        private System.Windows.Forms.TextBox txtCommentaire;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.ComboBox cmbNiveau;
        private System.Windows.Forms.Label lblNiveau;
        private System.Windows.Forms.ComboBox cmbAnnee;
        private System.Windows.Forms.Label lblAnnee;
        private System.Windows.Forms.Button btnTerminer;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label lblCaratèresTotal;
        private System.Windows.Forms.Label lblNbCaracteresSaisis;
        private System.Windows.Forms.PictureBox pbComment;
        private System.Windows.Forms.PictureBox pbNiveau;
        private System.Windows.Forms.PictureBox pbAnnee;
        private System.Windows.Forms.ToolTip ToolTipErrorInfo;
    }
}