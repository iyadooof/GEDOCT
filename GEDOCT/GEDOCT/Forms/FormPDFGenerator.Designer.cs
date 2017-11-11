namespace GEDOCT
{
    partial class FormPDFGenerator
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
            this.btnNouveau = new System.Windows.Forms.Button();
            this.prenom = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.specialite = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.diplome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inscri = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.a = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.nom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.annee_univer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNouveau
            // 
            this.btnNouveau.Location = new System.Drawing.Point(412, 401);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(75, 23);
            this.btnNouveau.TabIndex = 53;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // prenom
            // 
            this.prenom.Location = new System.Drawing.Point(183, 127);
            this.prenom.Name = "prenom";
            this.prenom.Size = new System.Drawing.Size(197, 20);
            this.prenom.TabIndex = 50;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(65, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Prenom : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(40, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(438, 31);
            this.label11.TabIndex = 48;
            this.label11.Text = "ATTESTATION D\'INSCRIPTION";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(183, 286);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(197, 20);
            this.numero.TabIndex = 45;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "Sous le Numéro :";
            // 
            // specialite
            // 
            this.specialite.Location = new System.Drawing.Point(183, 260);
            this.specialite.Name = "specialite";
            this.specialite.Size = new System.Drawing.Size(197, 20);
            this.specialite.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Specialite :";
            // 
            // diplome
            // 
            this.diplome.Location = new System.Drawing.Point(183, 234);
            this.diplome.Name = "diplome";
            this.diplome.Size = new System.Drawing.Size(197, 20);
            this.diplome.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Diplome :";
            // 
            // inscri
            // 
            this.inscri.Location = new System.Drawing.Point(183, 208);
            this.inscri.Name = "inscri";
            this.inscri.Size = new System.Drawing.Size(197, 20);
            this.inscri.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Est inscrit en :";
            // 
            // cin
            // 
            this.cin.Location = new System.Drawing.Point(289, 182);
            this.cin.Name = "cin";
            this.cin.Size = new System.Drawing.Size(197, 20);
            this.cin.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Titulaire de la Carte d\'Identité Nationale N :";
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(383, 152);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(102, 20);
            this.a.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "A :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(126, 153);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Né Le :";
            // 
            // nom
            // 
            this.nom.Location = new System.Drawing.Point(183, 101);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(197, 20);
            this.nom.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Nom :";
            // 
            // annee_univer
            // 
            this.annee_univer.Location = new System.Drawing.Point(183, 75);
            this.annee_univer.Name = "annee_univer";
            this.annee_univer.Size = new System.Drawing.Size(197, 20);
            this.annee_univer.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Annnée Universitaire :";
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(318, 401);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 23);
            this.btnValider.TabIndex = 27;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNouveau);
            this.panel1.Controls.Add(this.btnValider);
            this.panel1.Controls.Add(this.annee_univer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.prenom);
            this.panel1.Controls.Add(this.nom);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.a);
            this.panel1.Controls.Add(this.numero);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cin);
            this.panel1.Controls.Add(this.specialite);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.inscri);
            this.panel1.Controls.Add(this.diplome);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 427);
            this.panel1.TabIndex = 54;
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 400);
            this.panel2.TabIndex = 55;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(510, 374);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // FormPDFGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Name = "FormPDFGenerator";
            this.Text = "FormPDFGenerator";
            this.Load += new System.EventHandler(this.FormPDFGenerator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.TextBox prenom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox specialite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox diplome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox inscri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox annee_univer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}