using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEDOCT.Entities;
using GEDOCT.BLL;
using GEDOCT.MyUtilities;

namespace GEDOCT.Forms
{
    public partial class GestionDiplomes : Form
    {
        string Cin;
        string useMode;
        Diplome D;
        List<ErrorCtrlMsg> frmErrorCtrls;
        List<ErrorCtrlMsg> FormatErrorCtrls = new List<ErrorCtrlMsg>();

        public GestionDiplomes(string Cin, string useMode)
        {
            InitializeComponent();
            loadYears();
            this.Cin = Cin;
            this.useMode = useMode;
        }

        internal GestionDiplomes(string Cin, string useMode, Diplome D)
        {
            InitializeComponent();
            loadYears();
            this.Cin = Cin;
            this.useMode = useMode;
            this.D = D;
        }


        private void loadYears()
        {
            for (int i = 1990; i < DateTime.Now.Year; i++)
            {
                cmbAnnee.Items.Add(i.ToString() + "/" + (i + 1).ToString());
            }
        }


        internal Diplome getDataFromInterface()
        {
            D = new Diplome();
            D.DIPLOME = cmbDiplome.SelectedItem.ToString();
            D.SPECIALITE = txtSpecialite.Text.ToString();

            if (cmbMention.SelectedIndex >= 0)
            {
                D.MENTION = cmbMention.SelectedItem.ToString();
            }
            else
            {
                D.MENTION = string.Empty;
            }

            if (cmbAnnee.SelectedIndex >= 0)
            {
                D.ANNEE = cmbAnnee.SelectedItem.ToString();
            }
            else
            {
                D.ANNEE = string.Empty;
            }
            D.INSTITUTION = txtInstitution.Text.ToString();
            D.CIN = this.Cin;
            return D;
        }

        internal void bindDataToInterface(Diplome D)
        {
            cmbDiplome.SelectedItem = D.DIPLOME;
            txtSpecialite.Text = D.SPECIALITE;
            cmbMention.SelectedItem = D.MENTION;
            cmbAnnee.SelectedItem = D.ANNEE;
            txtInstitution.Text = D.INSTITUTION;
        }

        public void ValidateData()
        {
            int nbErrors = 0;
            string errorMsg;
            string errorMsgs = string.Empty;
            frmErrorCtrls = new List<ErrorCtrlMsg>();
            if (cmbDiplome.SelectedIndex < 0)
            {
                nbErrors++;
                errorMsg = "Diplome";
                errorMsgs += "\n" + errorMsg;
                frmErrorCtrls.Add(new ErrorCtrlMsg(cmbDiplome, pbDiplome, errorMsg));
            }

            if (txtSpecialite.Text == string.Empty)
            {
                nbErrors++;
                errorMsg = "Spécialité";
                errorMsgs += "\n" + errorMsg;
                frmErrorCtrls.Add(new ErrorCtrlMsg(txtSpecialite, pbSpecialite, errorMsg));
            }

            
            if (nbErrors > 0)
            {
                throw new DataValidationException("\t Les champs suivants sont obligatoires, veuillez les compléter svp!\t\n" + errorMsgs);
            }

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (this.useMode == "Ajout")
            {
                try
                {
                    ValidateData();
                    BLDiplome.AddNew(getDataFromInterface());
                    MessageBox.Show("Diplome ajouté avec succès", "Ajout d'un diplome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                catch (DataValidationException exp)
                {
                    MessageBox.Show(exp.ExceptionMessage, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppearanceHandler.SetErrorAppearance(frmErrorCtrls, ToolTipInfo);
                }
            }
            else
            {
                BLDiplome.Update(this.D.ID, getDataFromInterface());
                MessageBox.Show("Diplome mis à jour avec succès", "Modification d'un diplome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void cmbDiplome_Validated(object sender, EventArgs e)
        {
            if (cmbDiplome.SelectedIndex >= 0)
            {
                pbDiplome.ImageLocation = @"Resources\Ok-icon.png";
            }
        }

        private void txtSpecialite_Validated(object sender, EventArgs e)
        {
            if (txtSpecialite.Text != string.Empty)
            {
                pbSpecialite.ImageLocation = @"Resources\Ok-icon.png";
            }
        }

        private void cmbMention_Validated(object sender, EventArgs e)
        {
            if (cmbMention.SelectedIndex >= 0)
            {
                pbMention.ImageLocation = @"Resources\Ok-icon.png";
            }

        }

        private void cmbAnnee_Validated(object sender, EventArgs e)
        {
            if (cmbAnnee.SelectedIndex >= 0)
            {
                pbAnnee.ImageLocation = @"Resources\Ok-icon.png";
            }

        }

        private void txtInstitution_Validated(object sender, EventArgs e)
        {
            if (txtInstitution.Text != string.Empty)
            {
                pbInstitution.ImageLocation = @"Resources\Ok-icon.png";
            }
            else
            {
                pbInstitution.ImageLocation = null;
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
            int exist = existe(frmErrors, pbField);
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


        public void reset()
        {
            txtSpecialite.Text = string.Empty;
            pbSpecialite.ImageLocation = null;

            txtInstitution.Text = string.Empty;
            pbInstitution.ImageLocation = null;

            cmbAnnee.SelectedIndex = -1;
            pbAnnee.ImageLocation = null;

            cmbDiplome.SelectedIndex = -1;
            pbDiplome.ImageLocation = null;

            cmbMention.SelectedIndex = -1;
            pbMention.ImageLocation = null;

        }
     
       
      
    }
}
