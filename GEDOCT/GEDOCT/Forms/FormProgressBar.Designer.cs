namespace GEDOCT.Forms
{
    partial class FormProgressBar
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
            this.lbChargement = new System.Windows.Forms.Label();
            this.PBSuppression = new System.Windows.Forms.ProgressBar();
            this.TMSuppression = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblNbElementsSelectionnes = new System.Windows.Forms.Label();
            this.lblSlash = new System.Windows.Forms.Label();
            this.lblNbElementsSupprimes = new System.Windows.Forms.Label();
            this.lblAfficherDetails = new System.Windows.Forms.LinkLabel();
            this.lblFlecheDetail = new System.Windows.Forms.Label();
            this.lblElement = new System.Windows.Forms.Label();
            this.lblIdentifier = new System.Windows.Forms.Label();
            this.lblCarteCIN = new System.Windows.Forms.Label();
            this.lblCIN = new System.Windows.Forms.Label();
            this.BGProgressBar = new System.ComponentModel.BackgroundWorker();
            this.pbDoctorant = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoctorant)).BeginInit();
            this.SuspendLayout();
            // 
            // lbChargement
            // 
            this.lbChargement.AutoSize = true;
            this.lbChargement.Location = new System.Drawing.Point(13, 12);
            this.lbChargement.Name = "lbChargement";
            this.lbChargement.Size = new System.Drawing.Size(121, 13);
            this.lbChargement.TabIndex = 0;
            this.lbChargement.Text = "Suppression en cours ...";
            // 
            // PBSuppression
            // 
            this.PBSuppression.Location = new System.Drawing.Point(16, 45);
            this.PBSuppression.Name = "PBSuppression";
            this.PBSuppression.Size = new System.Drawing.Size(484, 14);
            this.PBSuppression.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Eléments";
            // 
            // lblNbElementsSelectionnes
            // 
            this.lblNbElementsSelectionnes.Location = new System.Drawing.Point(426, 29);
            this.lblNbElementsSelectionnes.Name = "lblNbElementsSelectionnes";
            this.lblNbElementsSelectionnes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNbElementsSelectionnes.Size = new System.Drawing.Size(27, 13);
            this.lblNbElementsSelectionnes.TabIndex = 4;
            this.lblNbElementsSelectionnes.Text = "0";
            this.lblNbElementsSelectionnes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSlash
            // 
            this.lblSlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSlash.Location = new System.Drawing.Point(419, 29);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(10, 13);
            this.lblSlash.TabIndex = 5;
            this.lblSlash.Text = "/";
            // 
            // lblNbElementsSupprimes
            // 
            this.lblNbElementsSupprimes.Location = new System.Drawing.Point(397, 29);
            this.lblNbElementsSupprimes.Name = "lblNbElementsSupprimes";
            this.lblNbElementsSupprimes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNbElementsSupprimes.Size = new System.Drawing.Size(25, 13);
            this.lblNbElementsSupprimes.TabIndex = 6;
            this.lblNbElementsSupprimes.Text = "0";
            // 
            // lblAfficherDetails
            // 
            this.lblAfficherDetails.AutoSize = true;
            this.lblAfficherDetails.LinkColor = System.Drawing.Color.Black;
            this.lblAfficherDetails.Location = new System.Drawing.Point(16, 82);
            this.lblAfficherDetails.Name = "lblAfficherDetails";
            this.lblAfficherDetails.Size = new System.Drawing.Size(76, 13);
            this.lblAfficherDetails.TabIndex = 7;
            this.lblAfficherDetails.TabStop = true;
            this.lblAfficherDetails.Text = "Afficher détails";
            this.lblAfficherDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAfficherDetails_LinkClicked);
            // 
            // lblFlecheDetail
            // 
            this.lblFlecheDetail.AutoSize = true;
            this.lblFlecheDetail.Location = new System.Drawing.Point(88, 82);
            this.lblFlecheDetail.Name = "lblFlecheDetail";
            this.lblFlecheDetail.Size = new System.Drawing.Size(19, 13);
            this.lblFlecheDetail.TabIndex = 8;
            this.lblFlecheDetail.Text = ">>";
            // 
            // lblElement
            // 
            this.lblElement.AutoSize = true;
            this.lblElement.Location = new System.Drawing.Point(120, 144);
            this.lblElement.Name = "lblElement";
            this.lblElement.Size = new System.Drawing.Size(63, 13);
            this.lblElement.TabIndex = 9;
            this.lblElement.Text = "Doctorant : ";
            // 
            // lblIdentifier
            // 
            this.lblIdentifier.AutoSize = true;
            this.lblIdentifier.Location = new System.Drawing.Point(248, 144);
            this.lblIdentifier.Name = "lblIdentifier";
            this.lblIdentifier.Size = new System.Drawing.Size(0, 13);
            this.lblIdentifier.TabIndex = 10;
            // 
            // lblCarteCIN
            // 
            this.lblCarteCIN.AutoSize = true;
            this.lblCarteCIN.Location = new System.Drawing.Point(120, 114);
            this.lblCarteCIN.Name = "lblCarteCIN";
            this.lblCarteCIN.Size = new System.Drawing.Size(128, 13);
            this.lblCarteCIN.TabIndex = 11;
            this.lblCarteCIN.Text = "Titulaire du carte CIN N° :";
            // 
            // lblCIN
            // 
            this.lblCIN.AutoSize = true;
            this.lblCIN.Location = new System.Drawing.Point(254, 114);
            this.lblCIN.Name = "lblCIN";
            this.lblCIN.Size = new System.Drawing.Size(0, 13);
            this.lblCIN.TabIndex = 12;
            // 
            // BGProgressBar
            // 
            this.BGProgressBar.WorkerReportsProgress = true;
            this.BGProgressBar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGProgressBar_DoWork);
            this.BGProgressBar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGProgressBar_ProgressChanged);
            // 
            // pbDoctorant
            // 
            this.pbDoctorant.Location = new System.Drawing.Point(19, 114);
            this.pbDoctorant.Name = "pbDoctorant";
            this.pbDoctorant.Size = new System.Drawing.Size(76, 72);
            this.pbDoctorant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDoctorant.TabIndex = 13;
            this.pbDoctorant.TabStop = false;
            // 
            // FormProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 203);
            this.Controls.Add(this.pbDoctorant);
            this.Controls.Add(this.lblCIN);
            this.Controls.Add(this.lblCarteCIN);
            this.Controls.Add(this.lblIdentifier);
            this.Controls.Add(this.lblElement);
            this.Controls.Add(this.lblFlecheDetail);
            this.Controls.Add(this.lblAfficherDetails);
            this.Controls.Add(this.lblNbElementsSupprimes);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.lblNbElementsSelectionnes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PBSuppression);
            this.Controls.Add(this.lbChargement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(533, 242);
            this.MinimumSize = new System.Drawing.Size(533, 146);
            this.Name = "FormProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormProgressBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDoctorant)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbChargement;
        private System.Windows.Forms.ProgressBar PBSuppression;
        private System.Windows.Forms.Timer TMSuppression;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNbElementsSelectionnes;
        private System.Windows.Forms.Label lblSlash;
        private System.Windows.Forms.Label lblNbElementsSupprimes;
        private System.Windows.Forms.LinkLabel lblAfficherDetails;
        private System.Windows.Forms.Label lblFlecheDetail;
        private System.Windows.Forms.Label lblElement;
        private System.Windows.Forms.Label lblIdentifier;
        private System.Windows.Forms.Label lblCarteCIN;
        private System.Windows.Forms.Label lblCIN;
        private System.ComponentModel.BackgroundWorker BGProgressBar;
        private System.Windows.Forms.PictureBox pbDoctorant;
    }
}