using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using GEDOCT.Entities;
using GEDOCT.BLL;
using GEDOCT.MyUtilities;

namespace GEDOCT.Forms
{
    public partial class FormProgressBar : Form
    {
        int nbElementSelectionnes;
        List<FicheInformations> listDoctorants=new List<FicheInformations>();
        List<Inscription> listInscriptions = new List<Inscription>();
        List<Diplome> listDiplomes = new List<Diplome>();
        Random rand = new Random();
        delegate void setTextCallBack(string text , Label lbl);
        delegate void setPictureCallBack(PictureBox picBox);
        string deletedSubject = string.Empty;
        DataGridView dgvDocts;
        DataGridView dgvInscrits;
        DataGridView dgvDiplomes;
        public bool deleted = false;
        public FormProgressBar()
        {
            InitializeComponent();
        }

        internal FormProgressBar(int nbElementSelectionnes , List<FicheInformations> listDoctorants , DataGridView dgvDocts)
        {
            InitializeComponent();
            this.nbElementSelectionnes = nbElementSelectionnes;
            this.listDoctorants = listDoctorants;
            this.deletedSubject = "Doctorant";
            this.lblElement.Text = "Nom & Prénom : ";
            this.dgvDocts = dgvDocts;
        }

        internal FormProgressBar(int nbElementSelectionnes, List<Inscription> listInscriptions, DataGridView dgvInscrits)
        {
            InitializeComponent();
            this.nbElementSelectionnes = nbElementSelectionnes;
            this.listInscriptions = listInscriptions;
            this.deletedSubject = "Inscription";
            this.lblElement.Text = "Identifiant de l'inscription : ";
            this.dgvInscrits = dgvInscrits;
        }

        internal FormProgressBar(int nbElementSelectionnes, List<Diplome> listDiplomes ,DataGridView dgvDiplomes)
        {
            InitializeComponent();
            this.nbElementSelectionnes = nbElementSelectionnes;
            this.listDiplomes = listDiplomes;
            this.deletedSubject = "Diplome";
            this.lblElement.Text = "Identifiant du diplome : ";
            this.dgvDiplomes = dgvDiplomes;
        }
        private void FormProgressBar_Load(object sender, EventArgs e)
        {
            lblNbElementsSelectionnes.Text = nbElementSelectionnes.ToString();
            this.Text = "0 %";
            BGProgressBar.RunWorkerAsync();
        }

        private void lblAfficherDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.ClientSize.Height<200)
            {
                this.ClientSize = new Size(533, 200);
                lblFlecheDetail.Visible = false;
                lblElement.Visible = true;
                lblIdentifier.Visible = true;
                lblCarteCIN.Visible = true;
                lblCIN.Visible = true;
            }
            else
            {
                this.ClientSize = new Size(533, 146);
                lblFlecheDetail.Visible = true;
                lblElement.Visible = false;
                lblIdentifier.Visible = false;
                lblCarteCIN.Visible = false;
                lblCIN.Visible = false;
            }
        }


        private void setText(string text , Label lbl)
        {
            if (lbl.InvokeRequired)
            {
                setTextCallBack d = new setTextCallBack(setText);
                this.Invoke(d, new object[] { text , lbl});
            }
            else
            lbl.Text = text;
        }

        private void setPictureBox(PictureBox picBox)
        {
            if (picBox.InvokeRequired)
            {
                setPictureCallBack d = new setPictureCallBack(setPictureBox);
                this.Invoke(d, new object[] { picBox });
            }
            else
                pbDoctorant = picBox;
        }


		private void ThreadProcSafeNbDeletedElements(string value)
		{
            this.setText(value,lblNbElementsSupprimes);
		}

        private void ThreadProcSafeIdentifier(string value)
        {
            this.setText(value, lblIdentifier);
        }
        private void ThreadProcSafeDeletedStudentCIN(string value)
        {
            this.setText(value, lblCIN);
        }

       

        private void BGProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread demoThread, demoThread1, demoThread2;
            if (this.deletedSubject == "Doctorant")
            {
                for (int i = 0; i < listDoctorants.Count; i++)
                {
                    if (nbElementSelectionnes > 0)
                    {
                    
                        Thread.Sleep(rand.Next(500, 2000));
                        demoThread = new Thread(() => ThreadProcSafeNbDeletedElements((i + 1).ToString()));
                        demoThread1 = new Thread(() => ThreadProcSafeIdentifier(listDoctorants[i].NOMPRENOM));
                        demoThread2 = new Thread(() => ThreadProcSafeDeletedStudentCIN(listDoctorants[i].CIN));
                        ImageUtilities.getPhoto(pbDoctorant, listDoctorants[i].CIN);
                        demoThread.Start();
                        demoThread1.Start();
                        demoThread2.Start();
                        BLFicheInformation.delete(listDoctorants[i].CIN);
                        ImageUtilities.deletePhoto(listDoctorants[i].CIN);
                        BGProgressBar.ReportProgress((i + 1) * 100 / nbElementSelectionnes);
                        
                    }
                }
            }
            else if (this.deletedSubject == "Inscription")
            {
                ImageUtilities.getPhoto(pbDoctorant, listInscriptions[0].CIN);
                demoThread2 = new Thread(() => ThreadProcSafeDeletedStudentCIN(listInscriptions[0].CIN));
                demoThread2.Start();
                for (int i = 0; i < listInscriptions.Count; i++)
                {
                    if (nbElementSelectionnes > 0)
                    {
                        Thread.Sleep(rand.Next(500, 2000));
                        demoThread = new Thread(() => ThreadProcSafeNbDeletedElements((i + 1).ToString()));
                        demoThread1 = new Thread(() => ThreadProcSafeIdentifier(listInscriptions[i].ID)); 
                        demoThread.Start();
                        demoThread1.Start();
                        BLInscription.Delete(listInscriptions[i].ID);
                        BGProgressBar.ReportProgress((i + 1) * 100 / nbElementSelectionnes);
                        
                    }
                }
            }
            else
            {
                ImageUtilities.getPhoto(pbDoctorant, listDiplomes[0].CIN);
                demoThread2 = new Thread(() => ThreadProcSafeDeletedStudentCIN(listDiplomes[0].CIN));
                demoThread2.Start();
                for (int i = 0; i < listDiplomes.Count; i++)
                {
                    if (nbElementSelectionnes > 0)
                    {
                        Thread.Sleep(rand.Next(500, 2000));
                        demoThread = new Thread(() => ThreadProcSafeNbDeletedElements((i + 1).ToString()));
                        demoThread1 = new Thread(() => ThreadProcSafeIdentifier(listDiplomes[i].ID));
                        demoThread.Start();
                        demoThread1.Start();
                        BLDiplome.Delete(listDiplomes[i].ID);
                        BGProgressBar.ReportProgress((i + 1) * 100 / nbElementSelectionnes);
                    }

                }
            }

            MessageBox.Show("Suppression terminée", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.deleted = true;
            this.Invoke((Action)(() => { this.Dispose(); }));
        }

        private void BGProgressBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PBSuppression.Value = e.ProgressPercentage;
            this.Text = e.ProgressPercentage.ToString() + " %";
        }

    }
}
