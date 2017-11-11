using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using GEDOCT.BLL;
using GEDOCT.Entities;
using GEDOCT.MyUtilities;


namespace GEDOCT.Forms
{
    public partial class GestionInscriptions : Form
    {
        Inscription I;
        string Cin;
        string useMode;
        List<ErrorCtrlMsg> ErrorCtrls;     

        public GestionInscriptions(string Cin, string useMode)
        {
            InitializeComponent();
            loadYears();
            loadNiveaux();
            this.Cin = Cin;
            this.useMode = useMode;
        }

        internal GestionInscriptions(string Cin, string useMode, Inscription I)
        {
            InitializeComponent();
            loadYears();
            loadNiveaux();
            this.Cin = Cin;
            this.useMode = useMode;
            this.I = I;
        }

      
        internal Inscription getInscriptionFromInterface()
        {
            I = new Inscription();
            I.CIN = this.Cin;
            I.COMMENTAIRE = txtCommentaire.Text;
            I.NIVEAU = cmbNiveau.SelectedItem.ToString();
            I.ANNEEUNIVERSITAIRE = cmbAnnee.SelectedItem.ToString();
            return I;
        }

     
        internal void bindDataToInerface(Inscription I)
        {
            cmbAnnee.SelectedItem = I.ANNEEUNIVERSITAIRE;
            cmbNiveau.SelectedItem = I.NIVEAU;
            txtCommentaire.Text = I.COMMENTAIRE;
        }

        private void reset()
        {
            cmbAnnee.SelectedIndex = -1;
            pbAnnee.ImageLocation = null;
            cmbNiveau.SelectedIndex = -1;
            pbNiveau.ImageLocation = null;
            txtCommentaire.Clear();
            if (pbComment.ImageLocation != null)
            {
                pbComment.ImageLocation = null;
            }
            lblNbCaracteresSaisis.Text = "0";
        }

        private void loadYears()
        {
            for (int i = 1990; i < DateTime.Now.Year; i++)
            {
                cmbAnnee.Items.Add(i.ToString()+"/"+(i+1).ToString());
            }
        }

        private void loadNiveaux()
        {
            cmbNiveau.Items.Add("1ère année");
            for (int i = 2; i < 8; i++)
            {
                cmbNiveau.Items.Add(i.ToString()+"ème année");
            }
        }

        public void ValidateData()
        {
            int nbErrors=0;
            string MsgError;
            string MsgErrors = string.Empty;
            ErrorCtrls = new List<ErrorCtrlMsg>();
            if (cmbAnnee.SelectedIndex < 0)
            {
                nbErrors++;
                MsgError="Année";
                MsgErrors += MsgError + "\n";
                ErrorCtrls.Add(new ErrorCtrlMsg(cmbAnnee,pbAnnee,MsgError));
            }

            if (cmbNiveau.SelectedIndex < 0)
            {
                nbErrors++;
                MsgError = "Niveau";
                MsgErrors += MsgError + "\n";
                ErrorCtrls.Add(new ErrorCtrlMsg(cmbNiveau, pbNiveau, MsgError));
            }

          

            if (nbErrors > 0)
            {
                throw new DataValidationException("\t Veuillez compléter les champs obligatoires suivants\n\n\n"+MsgErrors);
            }
        }

      
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (this.useMode == "Ajout")
            {
                try
                {
                    ValidateData();
                    BLInscription.AddNew(getInscriptionFromInterface());
                    MessageBox.Show("Inscription ajoutée avec succès", "Ajout d'inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                catch (DataValidationException Exp)
                {
                    MessageBox.Show(Exp.ExceptionMessage,"Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    AppearanceHandler.SetErrorAppearance(ErrorCtrls,ToolTipErrorInfo);
                }
            }
            else
            {
                BLInscription.Update(this.I.ID,getInscriptionFromInterface());
                MessageBox.Show("Inscription mis à jour avec succès", "Mise à jour d'inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

        private void txtCommentaire_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            i = int.Parse(lblNbCaracteresSaisis.Text);
            if (e.KeyChar == (Char)Keys.Back)
            {
                if (i > 0)
                {
                    if (txtCommentaire.SelectionLength >= 1)
                    {
                        i -= txtCommentaire.SelectionLength;
                        lblNbCaracteresSaisis.Text = i.ToString();
                    }
                    else
                    {
                        i--;
                        lblNbCaracteresSaisis.Text = i.ToString();

                    }
                }
            }
            else
                if (i < 350)
                {
                    i++;
                    lblNbCaracteresSaisis.Text = i.ToString();
                }

            
        }

        private void GestionInscriptions_Load(object sender, EventArgs e)
        {
            
            if (this.useMode == "Modif")
            {
                lblNbCaracteresSaisis.Text = txtCommentaire.Text.Length.ToString();
            }
        }

        private void txtCommentaire_Validated(object sender, EventArgs e)
        {
            if (txtCommentaire.Text != string.Empty)
            {
                pbComment.ImageLocation = @"Resources\Ok-icon.png";
            }
            else
            {
                pbComment.ImageLocation = null;
            }
        }

        private void cmbAnnee_Validated(object sender, EventArgs e)
        {
            if (cmbAnnee.SelectedIndex >= 0)
            {
                pbAnnee.ImageLocation = @"Resources\Ok-icon.png";
            }
            else
            {

                if (pbAnnee.ImageLocation != @"Resources\No-icon.png")
                {
                    pbAnnee.ImageLocation = @"Resources\No-icon.png";
                }
            }
        }

        private void cmbNiveau_Validated(object sender, EventArgs e)
        {
            if (cmbNiveau.SelectedIndex >= 0)
            {
                pbNiveau.ImageLocation = @"Resources\Ok-icon.png";
            }
            else
            {

                if (pbNiveau.ImageLocation != @"Resources\No-icon.png")
                {
                    pbNiveau.ImageLocation = @"Resources\No-icon.png";
                }
            }
        }

      
       

        public int existe(List<ErrorCtrlMsg> frmErrors, PictureBox pbField)
        {
            int i = 0;
            while (i < frmErrors.Count() && frmErrors[i].pictureErrorControl != pbField)
            {
                i++;
            }
            if (i < frmErrors.Count())
            {
                return i;
            }
            else
                return -1;
        }

        public bool supprimer(List<ErrorCtrlMsg> frmErrors, PictureBox pbField)
        {
            int exist=existe(frmErrors, pbField);
            if (exist > -1)
            {
                frmErrors.RemoveAt(exist);
                return true;
            }
            else
            {
                return false;
            }
        }

     

    }
}
