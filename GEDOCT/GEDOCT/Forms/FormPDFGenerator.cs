using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace GEDOCT
{
    public partial class FormPDFGenerator : Form
    {
        public FormPDFGenerator()
        {
            InitializeComponent();
        }

        private void FormPDFGenerator_Load(object sender, EventArgs e)
        {
            //DataTable Dt = new DataTable();
            //Dt = DAL.DALFicheInformations.select().Tables[0];
            dataGridView1.DataSource = MyUtilities.DataAccess.DataBaseAccessUtilities.select().Tables[0];
            //dataGridView1.DataSource = DAL.DALDiplome.select().Tables[4];
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (annee_univer.Text == "" || nom.Text == "" || prenom.Text == "" || a.Text == "" || inscri.Text == "" || diplome.Text == "" || specialite.Text == "" || numero.Text == "")
            {
                MessageBox.Show("Tous les champs sont obligatoire ! ");
            }
            else
            {
                Document document = new Document();
                FolderBrowserDialog folder = new FolderBrowserDialog();

                DialogResult result = folder.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folder.SelectedPath))
                {
                    DateTime dn = DateTime.Parse(dataGridView1.SelectedCells[2].Value.ToString());
                    PdfWriter.GetInstance(document, new FileStream(folder.SelectedPath + "\\Attestation d'inscription de " + nom.Text +" " + prenom.Text + ".pdf", FileMode.Create));
                    
                    document.Open();

                    Paragraph p1  = new Paragraph("          République Tunisienne");
                    Paragraph p2  = new Paragraph("Ministre de L'Enseignement Supérieur");
                    Paragraph p3  = new Paragraph("         et de la Recherche Scientifuqye");
                    Paragraph p4  = new Paragraph("         Universite de Monastir Tunisienne");
                    Paragraph p5  = new Paragraph("Faculte des Sciences de Monastire \n \n \n");
                    Paragraph p6  = new Paragraph("                                                          ATTESTATION D'INSCRIPTION");
                    Paragraph p7  = new Paragraph("\n \n                                                           Année Universitaire " + annee_univer.Text + "\n \n ");
                    Paragraph p8  = new Paragraph("Le secrétaire générale de la FACULTES DES SCIENCES DE MONASTIR soussigné, \n atteste que l'etudiant \n \n");
                    Paragraph p9  = new Paragraph("Nom              :     " + nom.Text);
                    Paragraph p10 = new Paragraph("Prénom         :    " + prenom.Text);
                    Paragraph p11 = new Paragraph("Né Le            :     " + dn.Day + "/" + dn.Month + "/" + dn.Year + "             à   :   " + a.Text);
                    Paragraph p12 = new Paragraph("Titulaire de la Carte d'Identité Nationale N         :     " + cin.Text);
                    Paragraph p13 = new Paragraph("est inscrit en :         " + inscri.Text);
                    Paragraph p14 = new Paragraph("Diplôme        :         " + diplome.Text);
                    Paragraph p15 = new Paragraph("Spécialite     :         " + specialite.Text);
                    Paragraph p16 = new Paragraph("Sous le Numéro :         " + numero.Text);
                    Paragraph p17 = new Paragraph("Pour L'année Universitaire en cours        (        " + annee_univer.Text + "      )");
                    Paragraph p18 = new Paragraph("                                                                                                          Faite a Monastir le " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "    \n  ");
                    Paragraph p19 = new Paragraph("                                                                                                                 Le Secrétaire Géneral \n \n ");
                    Paragraph p20 = new Paragraph("______________________________________________________________________________");
                    Paragraph p21 = new Paragraph(" N.B : la présente attestation n'est delivrée qu'une seule fois ");

                    document.Add(p1);
                    document.Add(p2);
                    document.Add(p3);
                    document.Add(p4);
                    document.Add(p5);
                    document.Add(p6);
                    document.Add(p7);
                    document.Add(p8);
                    document.Add(p9);
                    document.Add(p10);
                    document.Add(p11);
                    document.Add(p12);
                    document.Add(p13);
                    document.Add(p14);
                    document.Add(p15);
                    document.Add(p16);
                    document.Add(p17);
                    document.Add(p18);
                    document.Add(p19);
                    document.Add(p20);
                    document.Add(p21);

                    document.Close();

                    MessageBox.Show("le fichier a ete creer avec succees");
                }
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            annee_univer.Text = "";
            nom.Text = "";
            annee_univer.Text = "";
            prenom.Text = ""; a.Text = "";
            inscri.Text = "";
            diplome.Text = "";
            specialite.Text = "";
            numero.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string np = dataGridView1.SelectedCells[1].Value.ToString();
            string nm = "";
            string pn = "";

            for (int i = 0; i< np.Length; i++)
            {
                if (np[i] == ' ')
                    break;
                nm = nm + np[i];
            }

            for (int i = nm.Length; i < np.Length; i++)
            {
                pn = pn + np[i];
            }

            panel2.Hide();
            panel1.Show();

            annee_univer.Text = dataGridView1.SelectedCells[8].Value.ToString();
            nom.Text = nm;
            prenom.Text = pn;
            dateTimePicker1.Value = (DateTime.Parse(dataGridView1.SelectedCells[2].Value.ToString())).Date;
            a.Text = dataGridView1.SelectedCells[3].Value.ToString();
            cin.Text= dataGridView1.SelectedCells[0].Value.ToString();
            inscri.Text = dataGridView1.SelectedCells[4].Value.ToString();
            diplome.Text = dataGridView1.SelectedCells[5].Value.ToString();
            specialite.Text = dataGridView1.SelectedCells[6].Value.ToString();
            numero.Text = dataGridView1.SelectedCells[7].Value.ToString();
        }
    }
}
