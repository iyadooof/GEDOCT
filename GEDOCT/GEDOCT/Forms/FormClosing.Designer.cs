namespace GEDOCT.Forms
{
    partial class FormClosing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClosing));
            this.chbSHow = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pbMsg = new System.Windows.Forms.PictureBox();
            this.btnOui = new System.Windows.Forms.Button();
            this.btnNon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMsg)).BeginInit();
            this.SuspendLayout();
            // 
            // chbSHow
            // 
            this.chbSHow.AutoSize = true;
            this.chbSHow.Location = new System.Drawing.Point(12, 177);
            this.chbSHow.Name = "chbSHow";
            this.chbSHow.Size = new System.Drawing.Size(100, 17);
            this.chbSHow.TabIndex = 0;
            this.chbSHow.Text = "Ne plus afficher";
            this.chbSHow.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(160, 45);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(184, 16);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Voulez vous vraiment quitter ?";
            // 
            // pbMsg
            // 
            this.pbMsg.Image = ((System.Drawing.Image)(resources.GetObject("pbMsg.Image")));
            this.pbMsg.Location = new System.Drawing.Point(25, 25);
            this.pbMsg.Name = "pbMsg";
            this.pbMsg.Size = new System.Drawing.Size(64, 64);
            this.pbMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMsg.TabIndex = 2;
            this.pbMsg.TabStop = false;
            // 
            // btnOui
            // 
            this.btnOui.Location = new System.Drawing.Point(169, 124);
            this.btnOui.Name = "btnOui";
            this.btnOui.Size = new System.Drawing.Size(75, 23);
            this.btnOui.TabIndex = 3;
            this.btnOui.Text = "Oui";
            this.btnOui.UseVisualStyleBackColor = true;
            this.btnOui.Click += new System.EventHandler(this.btnOui_Click);
            // 
            // btnNon
            // 
            this.btnNon.Location = new System.Drawing.Point(250, 124);
            this.btnNon.Name = "btnNon";
            this.btnNon.Size = new System.Drawing.Size(75, 23);
            this.btnNon.TabIndex = 4;
            this.btnNon.Text = "Non";
            this.btnNon.UseVisualStyleBackColor = true;
            this.btnNon.Click += new System.EventHandler(this.btnNon_Click);
            // 
            // FormClosing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 206);
            this.Controls.Add(this.btnNon);
            this.Controls.Add(this.btnOui);
            this.Controls.Add(this.pbMsg);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.chbSHow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormClosing";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fermeture";
            this.Load += new System.EventHandler(this.FormClosing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMsg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox pbMsg;
        private System.Windows.Forms.Button btnOui;
        private System.Windows.Forms.Button btnNon;
        public System.Windows.Forms.CheckBox chbSHow;
    }
}