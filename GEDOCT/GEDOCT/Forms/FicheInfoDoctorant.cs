using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;


using GEDOCT.Forms;
using GEDOCT.Entities;
using GEDOCT.BLL;
using GEDOCT.MyUtilities;

namespace GEDOCT
{
    public partial class FicheInfoDoctorant : Form
    {
        string useMode = string.Empty;
        NotifyIcon ni = new NotifyIcon();
        string lastSelectedValue=string.Empty;
        FicheInformations CurFi,NewFi;
        ListFicheInformations listFicheInfo;
        ListInscription listInscriptions;
        ListDiplome listDiplomes;
        Inscription I;
        Diplome D;
        List<ErrorCtrlMsg> FrmErrorCtrls;
        List<TextBox> paramCtrlTxt = new List<TextBox>();
        List<ComboBox> paramCtrlCmb = new List<ComboBox>();
        Control[] paramControls;
        int NbFormatErrors = 0;
        string FormatErrorMsg;
        List<ErrorCtrlMsg> FormatErrorCtrls = new List<ErrorCtrlMsg>();
        List<EmptyCtrlMsg> EmptyCtrls = new List<EmptyCtrlMsg>();
        public FicheInfoDoctorant()
        {
            InitializeComponent();
            SetUseMode("Consulter");
        }

        private void FicheInfoDoctorant_Load(object sender, EventArgs e)
        {
            AppearanceHandler.HideControls(new Control[]{cmbValeur,txtRecherche});
            cmbRecherche.SelectedIndex = 0;
        }


        // Mode d'utilisation de l'interface principale
        private void SetUseMode(string mode)
        {
            useMode = mode;   
            switch (mode)
            {
                case "Consulter":
                    {

                        if (txtCinConsult.Text == string.Empty)
                        {
                            AppearanceHandler.HideControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
                        }
                        else
                        {
                            AppearanceHandler.ShowControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
                        }
                        plInscritsDiplomes.Visible = true;
                        plFicheInfo.Visible = false;

                        if (cmbRecherche.SelectedIndex < 0 && dgvDoctorants.Rows.Count>0)
                        {
                            this.lastSelectedValue = "Tous";
                            cmbRecherche.SelectedIndex = 0;
                            dgvDoctorants.ClearSelection();
                        }

                        if ((cmbRecherche.SelectedIndex > 0) && (cmbRecherche.SelectedIndex < 3))
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, true);
                            AppearanceHandler.SetReadOnlyAppearance(txtRecherche, false);
                        }
                        else if (cmbRecherche.SelectedIndex >= 3)
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, true);
                            AppearanceHandler.SetEnabledAppearance(cmbValeur, true);
                        }
                        else
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, true);
                        }

                        AppearanceHandler.SetEnabledAppearance(dgvDoctorants, true);

                        paramControls = new Control[] { grpConfirmation,lblPhoto };
                        AppearanceHandler.HideControls(paramControls);
                        AppearanceHandler.ShowControls(grpGestion);
                        this.Text = "Gestion des Doctorants - Consultation";

                        paramCtrlTxt.Clear();
                        foreach (Control c in grpInfosDoctorant.Controls)
                        {
                            if (c.GetType() == typeof(TextBox))
                            {
                                paramCtrlTxt.Add((TextBox)c);
                            }
                            
                        }

                        foreach (Control c in grpInfosPersos.Controls)
                        {
                            if (c.GetType() == typeof(TextBox))
                            {
                                paramCtrlTxt.Add((TextBox)c);
                            }
                        }
                        foreach (Control c in grpInfosProfs.Controls)
                        {
                            if (c.GetType() == typeof(TextBox))
                            {
                                paramCtrlTxt.Add((TextBox)c);
                            }
                        }
                        AppearanceHandler.SetReadOnlyAppearance(paramCtrlTxt,true);

                       
                        break;
                    }
                case "Ajouter":
                    {
                        dgvDoctorants.ClearSelection();
                        plFicheInfo.Visible = true;
                        plInscritsDiplomes.Visible = false;
                        if ((cmbRecherche.SelectedIndex > 0) && (cmbRecherche.SelectedIndex < 3))
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, false);
                            AppearanceHandler.SetReadOnlyAppearance(txtRecherche, true);
                        }
                        else if (cmbRecherche.SelectedIndex >= 3)
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, false);
                            AppearanceHandler.SetEnabledAppearance(cmbValeur, false);
                        }
                        else
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, false);
                        }

                        AppearanceHandler.SetEnabledAppearance(dgvDoctorants, false);
                        paramControls = new Control[] { grpConfirmation, lblPhoto };
                        AppearanceHandler.ShowControls(paramControls);
                        AppearanceHandler.HideControls(grpGestion);
                        this.Text = "Gestion des Doctorants - Nouveau doctorant";
                        dgvDiplomes.DataSource = null;
                        dgvInscriptions.DataSource = null;
                        initialiseDgvDiplome();
                        initialiseDgvInscription();
                        lblNbCaracteresSaisis.Text = "0";
                        
                        break;
                    }
                case "Modifier":
                    {
                        try
                        {
                            bindFicheInformationToInterface(NewFi);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        plFicheInfo.Visible = true;
                        plInscritsDiplomes.Visible = false;
                        if ((cmbRecherche.SelectedIndex > 0) && (cmbRecherche.SelectedIndex < 3))
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, false);
                            AppearanceHandler.SetReadOnlyAppearance(txtRecherche, true);
                        }
                        else if (cmbRecherche.SelectedIndex >= 3)
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, false);
                            AppearanceHandler.SetEnabledAppearance(cmbValeur, false);
                        }
                        else
                        {
                            AppearanceHandler.SetEnabledAppearance(cmbRecherche, false);
                        }

                        AppearanceHandler.SetEnabledAppearance(dgvDoctorants, false);
                        AppearanceHandler.SetEnabledAppearance(dgvInscriptions, true);
                        AppearanceHandler.SetEnabledAppearance(dgvDiplomes, true);

                        paramControls = new Control[] { grpConfirmation, lblPhoto };
                        AppearanceHandler.ShowControls(paramControls);
                        AppearanceHandler.HideControls(grpGestion);
                        this.Text = "Gestion des Doctorants - Mise à jour des informations d'un doctorant";
                        
                        lblNbCaracteresSaisis.Text = txtSujet.Text.Length.ToString();
                       

                       
                        break;
                    }
            }
        }


        public void initialiseDgvDiplome()
        {
            dgvDiplomes.Columns.Clear();
            dgvDiplomes.Columns.Add("Annee", "Année");
            dgvDiplomes.Columns.Add("Diplome", "Diplome");
            dgvDiplomes.Columns.Add("Specialite", "Spécialité");
            dgvDiplomes.Columns.Add("Mention", "Mention");
            dgvDiplomes.Columns.Add("Institution", "Institution");
        }

        public void initialiseDgvInscription()
        {
            dgvInscriptions.Columns.Clear();
            dgvInscriptions.Columns.Add("AnneeUniversitaire", "Année Universitaire");
            dgvInscriptions.Columns.Add("Niveau", "Niveau");
            dgvInscriptions.Columns.Add("Commentaire", "Commentaire");
        }

       

        public void bindDataToDgvDoctorants()
        { 
            listFicheInfo = BLFicheInformation.getAll();
            if (listFicheInfo != null)
            {
                dgvDoctorants.Columns.Clear();
                dgvDoctorants.DataSource = listFicheInfo.dt;
                renetializeDgvDoctorants();
                AppearanceHandler.ShowControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
            }
            else
            {
                dgvDoctorants.Columns.Clear();
                dgvDoctorants.DataSource = null;
                initialiseDgvDoctorants();
            }

        }

        public void initialiseDgvDoctorants()
        {
            dgvDoctorants.Columns.Add("NomPrenom", "Nom & Prénom");
            dgvDoctorants.Columns.Add("Specialite", "Spécialité");
        }

        public void renetializeDgvDoctorants()
        {
            for (int i = 0; i < dgvDoctorants.ColumnCount; i++)
            {
                if (dgvDoctorants.Columns[i].Name == "NomPrenom")
                {
                    dgvDoctorants.Columns[i].HeaderText = "Nom & Prénom";
                    continue;
                }
                else
                    if (dgvDoctorants.Columns[i].Name == "Specialite")
                    {
                        dgvDoctorants.Columns[i].HeaderText = "Spécialité";
                        continue;
                    }
                dgvDoctorants.Columns[i].Visible = false;
            }
        }


        public void bindDataToDgvInscriptions(String Cin)
        {

            listInscriptions = BLInscription.GetByCIN(Cin);
            if (listInscriptions != null)
            {
                dgvInscriptions.Columns.Clear();
                dgvInscriptions.DataSource = listInscriptions.dt;

                for (int i = 0; i < dgvInscriptions.ColumnCount; i++)
                {
                    if (dgvInscriptions.Columns[i].Name == "AnneeUniversitaire")
                    {
                        dgvInscriptions.Columns[i].HeaderText = "Année Universitaire";
                        break;
                    }
                }
                dgvInscriptions.Columns["id"].Visible = false;
                dgvInscriptions.Columns["Cin"].Visible = false;
                dgvInscriptions.ClearSelection();
            }
            else
            {
                initialiseDgvInscription();
            }

        }

        public void bindDataToDgvDiplomes(String Cin)
        {

            listDiplomes = BLDiplome.GetByCIN(Cin);
            if (listDiplomes != null)
            {
                dgvDiplomes.Columns.Clear();
                dgvDiplomes.DataSource = listDiplomes.dt;

                for (int i = 0; i < dgvDiplomes.ColumnCount; i++)
                {
                    if (dgvDiplomes.Columns[i].Name == "Annee")
                    {
                        dgvDiplomes.Columns[i].HeaderText = "Année";
                        continue;
                    }
                    if (dgvDiplomes.Columns[i].Name == "Specialite")
                    {
                        dgvDiplomes.Columns[i].HeaderText = "Spécialité";
                        continue;
                    }
                }
                dgvDiplomes.Columns["id"].Visible = false;
                dgvDiplomes.Columns["Cin"].Visible = false;
                dgvDiplomes.ClearSelection();
            }
            else
            {
                initialiseDgvDiplome();
            }
           

        }

        private DataRow getSelectedDataRowFromFicheInfo(int i)
        {
            if (this.listFicheInfo.dt != null && this.dgvDoctorants.SelectedRows != null)
            {
                if (this.dgvDoctorants.SelectedRows.Count > 0)
                {
                    string CurrentRowId = "'" + this.dgvDoctorants.SelectedRows[i].Cells["CIN"].Value.ToString() + "'";
                    DataRow[] SelectionResult = null;
                    SelectionResult = this.listFicheInfo.dt.Select("CIN = " + CurrentRowId + "");
                    if (SelectionResult != null && SelectionResult.Length != 0)
                        return SelectionResult[0];
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        private DataRow getSelectedDataRowFromDgvInscription(int i)
        {
            if (this.listInscriptions.dt != null && this.dgvInscriptions.SelectedRows != null)
            {
                if (this.dgvInscriptions.SelectedRows.Count > 0)
                {
                    string CurrentRowId = "'" + this.dgvInscriptions.SelectedRows[i].Cells["ID"].Value.ToString() + "'";
                    DataRow[] SelectionResult = null;
                    SelectionResult = this.listInscriptions.dt.Select("ID = " + CurrentRowId + "");
                    if (SelectionResult != null && SelectionResult.Length != 0)
                        return SelectionResult[0];
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }



        private DataRow getSelectedDataRowFromDgvDiplome(int i)
        {
            if (this.listDiplomes.dt != null && this.dgvDiplomes.SelectedRows != null)
            {
                if (this.dgvDiplomes.SelectedRows.Count > 0)
                {
                    string CurrentRowId = "'" + this.dgvDiplomes.SelectedRows[i].Cells["ID"].Value.ToString() + "'";
                    DataRow[] SelectionResult = null;
                    SelectionResult = this.listDiplomes.dt.Select("ID = " + CurrentRowId + "");
                    if (SelectionResult != null && SelectionResult.Length != 0)
                        return SelectionResult[0];
                    else
                        return null;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }


        private void dgvDoctorants_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoctorants.SelectedRows.Count > 0)
            {
                NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
                bindFicheInformationToInterface2(NewFi);
                dgvDiplomes.DataSource = null;
                dgvInscriptions.DataSource = null;
                bindDataToDgvInscriptions(NewFi.CIN);
                bindDataToDgvDiplomes(NewFi.CIN);
                lblNbCaracteresSaisis.Text = txtSujet.Text.Length.ToString();
            }
           
           
        }

        
        internal FicheInformations getFicheInformationFromInterface()
        {
            NewFi = new FicheInformations();
            NewFi.CIN = txtCin.Text;
            NewFi.NOMPRENOM = txtNomPrenom.Text;

            string day = Convert.ToDateTime(dtpNaissance.Text).Day.ToString();
            string month = Convert.ToDateTime(dtpNaissance.Text).Month.ToString();
            string year = Convert.ToDateTime(dtpNaissance.Text).Year.ToString();


            if (int.Parse(day) < 10)
            {
                day = "0" + day;
            }


            if (int.Parse(month) < 10)
            {
                month = "0" + month;
            }

            


            NewFi.DATENAISSANCE =month+"/"+day+"/"+year;
            NewFi.VILLENAISSANCE = txtLieu.Text;

            if (cmbCivilite.SelectedIndex >= 0)
            {
                NewFi.CIVILITE = cmbCivilite.SelectedItem.ToString();
            }
            else
            {
                NewFi.CIVILITE = "";
            }

            if (cmbNationalite.SelectedIndex >= 0)
            {
                NewFi.NATIONALITE = cmbNationalite.SelectedItem.ToString();
            }
            else
            {
                NewFi.NATIONALITE = "";
            }

            if (cmbPaysOrigine.SelectedIndex >= 0)
            {
                NewFi.PAYSORIGINE = cmbPaysOrigine.SelectedItem.ToString();
            }
            else
            {
                NewFi.PAYSORIGINE = "";
            }

            NewFi.ADRESSE = txtAdresse.Text;
            NewFi.GOUVERNORAT = txtGouvernorat.Text;
            NewFi.VILLE = txtVille.Text;
            NewFi.CODEPOSTAL = txtCodePostal.Text;
            NewFi.TELEPHONE = txtTelephone.Text;
            NewFi.EMAIL = txtEmail.Text;
            NewFi.PROFESSION = txtProfession.Text;
            NewFi.EMPLOYEUR = txtEmployeur.Text;
            NewFi.SPECIALITE = txtSpecialite.Text;
            NewFi.LABOUNITEERECHERCHE = txtLaboRecherche.Text;
            NewFi.LABOUNITEERECHERCHECOTUTELLE = txtLaboRechercheCotutelle.Text;
            NewFi.ENCADRANT = txtEncadrant.Text;
            NewFi.COENCADRANT = txtCoEncadrant.Text;
            NewFi.SUJET = txtSujet.Text;
            return NewFi;
        }

        internal void bindFicheInformationToInterface(FicheInformations fi)
        {
            txtCin.Text = fi.CIN;
            txtNomPrenom.Text = fi.NOMPRENOM;
            dtpNaissance.Value = DateTime.ParseExact(fi.DATENAISSANCE, "dd/mm/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            txtLieu.Text = fi.VILLENAISSANCE;
            cmbCivilite.SelectedItem = fi.CIVILITE;
            cmbNationalite.SelectedItem = fi.NATIONALITE;
            cmbPaysOrigine.SelectedItem = fi.PAYSORIGINE;
            txtAdresse.Text = fi.ADRESSE;
            txtGouvernorat.Text = fi.GOUVERNORAT;
            txtVille.Text = fi.VILLE;
            txtCodePostal.Text = fi.CODEPOSTAL;
            txtTelephone.Text = fi.TELEPHONE;
            txtEmail.Text = fi.EMAIL;
            txtProfession.Text = fi.PROFESSION;
            txtEmployeur.Text = fi.EMPLOYEUR;
            txtSpecialite.Text = fi.SPECIALITE;
            txtLaboRecherche.Text = fi.LABOUNITEERECHERCHE;
            txtLaboRechercheCotutelle.Text = fi.LABOUNITEERECHERCHECOTUTELLE;
            txtEncadrant.Text = fi.ENCADRANT;
            txtCoEncadrant.Text = fi.COENCADRANT;
            txtSujet.Text = fi.SUJET;
            ImageUtilities.getPhoto(pbDoctorant,fi.CIN);
            
        }


        internal void bindFicheInformationToInterface2(FicheInformations fi)
        {
            txtCinConsult.Text = fi.CIN;
            txtNomPrenomConsult.Text = fi.NOMPRENOM;
            txtDateNaissanceConsult.Text = fi.DATENAISSANCE;
            txtCiviliteConsult.Text = fi.CIVILITE;
            txtNationaliteConsult.Text = fi.NATIONALITE;
            txtPaysOrigineConsult.Text = fi.PAYSORIGINE;
            txtAdresseConsult.Text = fi.ADRESSE;
            txtNbInscritsConsult.Text = BLInscription.GetInscriptionsNumber(fi.CIN).ToString();
            txtTelConsult.Text = fi.TELEPHONE;
            txtEmailConsult.Text = fi.EMAIL;
            txtProfessionConsult.Text = fi.PROFESSION;
            txtSpecialiteConsult.Text = fi.SPECIALITE;
            txtLaboRechercheConsult.Text = fi.LABOUNITEERECHERCHE;
            txtLaboRechercheCotutelleConsult.Text = fi.LABOUNITEERECHERCHECOTUTELLE;
            txtEncadrantConsult.Text = fi.ENCADRANT;
            txtCoEncadrantConsult.Text = fi.COENCADRANT;
            txtSujetConsult.Text = fi.SUJET;
            ImageUtilities.getPhoto(pbDoctorantt, fi.CIN);
        }




        private void reset()
        {
            txtCin.Clear();
            txtNomPrenom.Clear();
            txtLieu.Clear();
            cmbCivilite.SelectedIndex = -1;
            cmbNationalite.Items.Clear();
            cmbPaysOrigine.SelectedIndex = -1;
            txtAdresse.Clear();
            txtGouvernorat.Clear();
            txtVille.Clear();
            txtCodePostal.Clear();
            txtTelephone.Clear();
            txtEmail.Clear();
            txtProfession.Clear();
            txtEmployeur.Clear();
            txtSpecialite.Clear();
            txtLaboRecherche.Clear();
            txtLaboRechercheCotutelle.Clear();
            txtEncadrant.Clear();
            txtCoEncadrant.Clear();
            txtSujet.Clear();
            dtpNaissance.Text = DateTime.Now.ToString();
            pbDoctorant.Image = null;
        }
        private void reset2()
        {
            txtCinConsult.Text = string.Empty;
            txtNomPrenomConsult.Text = string.Empty;
            txtDateNaissanceConsult.Text = string.Empty;
            txtCiviliteConsult.Text = string.Empty;
            txtNationaliteConsult.Text = string.Empty;
            txtPaysOrigineConsult.Text = string.Empty;
            txtAdresseConsult.Text = string.Empty;
            txtNbInscritsConsult.Text = string.Empty;
            txtTelConsult.Text = string.Empty;
            txtEmailConsult.Text = string.Empty;
            txtProfessionConsult.Text = string.Empty;
            txtSpecialiteConsult.Text = string.Empty;
            txtLaboRechercheConsult.Text = string.Empty;
            txtLaboRechercheCotutelleConsult.Text = string.Empty;
            txtEncadrantConsult.Text = string.Empty;
            txtCoEncadrantConsult.Text = string.Empty;
            txtSujetConsult.Text = string.Empty;
            pbDoctorantt.Image = null;
            AppearanceHandler.HideControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
           
        }

        #region

        /*******************************  Gestion des erreurs et validation **********************************/

        public void ValidateData()
        {
            int NbErrors = 0;
            string ErrorMsg;
            string ErrorMsgs = string.Empty;
            FrmErrorCtrls = new List<ErrorCtrlMsg>();
            this.FrmErrorCtrls.Clear();

            if (this.txtCin.Text == "")
            {
                NbErrors++;
                ErrorMsg = "CIN";
                this.FrmErrorCtrls.Add(new ErrorCtrlMsg(this.txtCin ,pbCin, ErrorMsg));
            }

            if (this.txtNomPrenom.Text == "") 
            {
                NbErrors++;
                ErrorMsg = "Nom et Prénom";
                this.FrmErrorCtrls.Add(new ErrorCtrlMsg(this.txtNomPrenom ,pbNomPrenom, ErrorMsg));
            }

            if (NbErrors > 0)
            {
                foreach (ErrorCtrlMsg errMsg in FrmErrorCtrls)
                {
                    ErrorMsgs += "- " + errMsg.ErrorMsg + "\n";
                }
                throw new DataValidationException("\t Données suivantes sont obligatoires\n\n\n" + ErrorMsgs);
            }
        }

        public void FormatData()
        {
            string FormatErrorMsgs = string.Empty;

            foreach (ErrorCtrlMsg frmError in FormatErrorCtrls)
            {
                FormatErrorMsgs += "\n" + frmError.ErrorMsg;
            }
            if (this.NbFormatErrors > 0)
            {
                throw new DataValidationException("\t Données saisies suivantes sont invalides\n\n\n" + FormatErrorMsgs);
            }
        }

        #endregion

        private void btnAjouterInscrit_Click(object sender, EventArgs e)
        {
            NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
            GestionInscriptions gi = new GestionInscriptions(NewFi.CIN, "Ajout");
            gi.ShowDialog();
            bindDataToDgvInscriptions(NewFi.CIN);
            dgvInscriptions.ClearSelection();
            txtNbInscritsConsult.Text = BLInscription.GetInscriptionsNumber(NewFi.CIN).ToString();
        }

        private void btnModifierInscrit_Click(object sender, EventArgs e)
        {
            if (dgvInscriptions.Rows.Count > 0)
            {
                if (dgvInscriptions.SelectedRows.Count > 0)
                {
                    NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
                    I = new Inscription(getSelectedDataRowFromDgvInscription(0));
                    GestionInscriptions gi = new GestionInscriptions(NewFi.CIN, "Modif", I);
                    gi.bindDataToInerface(I);
                    gi.ShowDialog();
                    bindDataToDgvInscriptions(NewFi.CIN);
                    dgvInscriptions.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner une inscription à mettre à jour", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a aucune inscription à modifier", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
        }

        private void btnSupprimerInscrit_Click(object sender, EventArgs e)
        {
            DialogResult choice;
            FormProgressBar fpb;
            List<Inscription> listInscriptions = new List<Inscription>();
            if (dgvInscriptions.Rows.Count > 0)
            {
                if (dgvInscriptions.SelectedRows.Count > 0)
                {
                    if (dgvInscriptions.SelectedRows.Count == 1)
                    {
                        choice = MessageBox.Show("Voulez-vous supprimer définitivement cette inscription ?", "Suppression d'inscription", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (choice == DialogResult.OK)
                        {
                            listInscriptions.Clear();
                            listInscriptions.Add(new Inscription(getSelectedDataRowFromDgvInscription(0)));
                            fpb = new FormProgressBar(dgvInscriptions.SelectedRows.Count, listInscriptions, dgvInscriptions);
                            fpb.ShowDialog();
                            NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
                            bindDataToDgvInscriptions(NewFi.CIN);
                        }

                    }
                    else
                    {
                        choice = MessageBox.Show("Voulez-vous supprimer définitivement ces inscriptions ?", "Suppression des inscriptions", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (choice == DialogResult.OK)
                        {
                            listInscriptions.Clear();
                            for (int i = 0; i < dgvInscriptions.SelectedRows.Count; i++)
                            {
                                listInscriptions.Add(new Inscription(getSelectedDataRowFromDgvInscription(i)));
                            }
                            fpb = new FormProgressBar(dgvInscriptions.SelectedRows.Count, listInscriptions, dgvInscriptions);
                            fpb.ShowDialog();
                            NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
                            bindDataToDgvInscriptions(NewFi.CIN);
                        }
                    }

                    txtNbInscritsConsult.Text = BLInscription.GetInscriptionsNumber(NewFi.CIN).ToString();
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner une ou des inscriptions à supprimer", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a aucune inscription à supprimer", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnAjouterDiplome_Click(object sender, EventArgs e)
        {
            NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
            GestionDiplomes gd = new GestionDiplomes(NewFi.CIN, "Ajout");
            gd.ShowDialog();
            bindDataToDgvDiplomes(NewFi.CIN);
            dgvDiplomes.ClearSelection();
        }

        private void btnModifierDiplome_Click(object sender, EventArgs e)
        {
            if (dgvDiplomes.Rows.Count > 0)
            {
                if (dgvDiplomes.SelectedRows.Count > 0)
                {
                    NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
                    D = new Diplome(getSelectedDataRowFromDgvDiplome(0));
                    GestionDiplomes gd = new GestionDiplomes(NewFi.CIN, "Modif", D);
                    gd.bindDataToInterface(D);
                    gd.ShowDialog();
                    bindDataToDgvDiplomes(NewFi.CIN);
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner un diplome à modifier", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a aucun diplome à modifier", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimerDiplome_Click(object sender, EventArgs e)
        {
            DialogResult choice;
            List<Diplome> listDiplomes = new List<Diplome>();
            FormProgressBar fpb;
            if (dgvDiplomes.Rows.Count > 0)
            {
                if (dgvDiplomes.SelectedRows.Count > 0)
                {
                    NewFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
                    if (dgvDiplomes.SelectedRows.Count == 1)
                    {
                        choice = MessageBox.Show("Voulez-vous supprimer définitivement ce diplome", "Suppression d'un diplome", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (choice == DialogResult.OK)
                        {
                            listDiplomes.Clear();
                            listDiplomes.Add(new Diplome(getSelectedDataRowFromDgvDiplome(0)));
                            fpb = new FormProgressBar(dgvDiplomes.SelectedRows.Count, listDiplomes, dgvDiplomes);
                            fpb.ShowDialog();
                            bindDataToDgvDiplomes(NewFi.CIN);
                        }
                    }
                    else
                    {
                        choice = MessageBox.Show("Voulez-vous supprimer définitivement ces diplomes ?", "Suppression d'un/des diplome(s)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (choice == DialogResult.OK)
                        {
                            listDiplomes.Clear();
                            for (int i = 0; i < dgvDiplomes.SelectedRows.Count; i++)
                            {
                                listDiplomes.Add(new Diplome(getSelectedDataRowFromDgvDiplome(i)));
                            }
                            fpb = new FormProgressBar(dgvDiplomes.SelectedRows.Count, listDiplomes, dgvDiplomes);
                            fpb.ShowDialog();
                            bindDataToDgvDiplomes(NewFi.CIN);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner un/des diplome(s) à supprimer", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a aucun diplome à supprimer", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNouveauDoct_Click(object sender, EventArgs e)
        {
            SetUseMode("Ajouter");
            reset();
        }
     
        private void btnModifierDoct_Click(object sender, EventArgs e)
        {
            if (dgvDoctorants.Rows.Count > 0)
            {
                if (dgvDoctorants.SelectedRows.Count > 0)
                {
                    SetUseMode("Modifier");
                    this.CurFi = new FicheInformations(getSelectedDataRowFromFicheInfo(0));
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner un doctorant à modifier", "Mise à jour impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a aucun doctorant à modifier","Mise à jour impossible",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnSupprimerDoct_Click(object sender, EventArgs e)
        {
            DialogResult choice;
            FormProgressBar fpb = null;
            List<FicheInformations> listDoctorants=new List<FicheInformations>();
            if (dgvDoctorants.Rows.Count > 0)
            {
                if (dgvDoctorants.SelectedRows.Count > 0)
                {
                    if (dgvDoctorants.SelectedRows.Count == 1)
                    {
                        choice = MessageBox.Show("Voulez vous supprimer définitivement ce doctorant ?", "Suppression d'un doctorant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign, true);

                        if (choice == DialogResult.Yes)
                        {
                            listDoctorants.Clear();
                            listDoctorants.Add(new FicheInformations(getSelectedDataRowFromFicheInfo(0)));
                            fpb = new FormProgressBar(dgvDoctorants.SelectedRows.Count, listDoctorants, dgvDoctorants);
                            fpb.Text = "Suppression d'un doctorant";
                            fpb.ShowDialog();
                            bindDataToDgvDoctorants();
                            if (dgvDoctorants.Rows.Count == 0)
                            {
                                reset2();
                                dgvDiplomes.DataSource = null;
                                initialiseDgvDiplome();
                                dgvInscriptions.DataSource = null;
                                initialiseDgvInscription();
                            }
                            
                        }
                    }
                    else
                    {
                        listDoctorants.Clear();

                        choice = MessageBox.Show("Voulez vous supprimer définitivement ces doctorants?", "Suppression d'un doctorant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign, true);
                        if (choice == DialogResult.Yes)
                        {

                            for (int i = 0; i < dgvDoctorants.SelectedRows.Count; i++)
                            {
                                listDoctorants.Add(new FicheInformations(getSelectedDataRowFromFicheInfo(i)));
                            }

                            fpb = new FormProgressBar(dgvDoctorants.SelectedRows.Count, listDoctorants, dgvDoctorants);
                            fpb.Text = "Suppression des doctorants";
                            fpb.ShowDialog();
                            bindDataToDgvDoctorants();
                            if(dgvDoctorants.SelectedRows.Count==dgvDoctorants.Rows.Count)
                            {

                                reset2();
                                dgvDiplomes.DataSource = null;
                                initialiseDgvDiplome();
                                dgvInscriptions.DataSource = null;
                                initialiseDgvInscription();                                
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Veuillez selectionner un/des doctorant(s) à supprimer", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
            }
            else
            {
                MessageBox.Show("Il n'y a aucun doctorant à supprimer", "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnImprimerDoct_Click(object sender, EventArgs e)
        {
            
            if (this.dgvDoctorants.Rows.Count>0) 
            {
                if (this.dgvDoctorants.SelectedRows.Count > 0) 
                {
                    if (this.NewFi != null)
                    {
                        FormImpression print = new FormImpression(NewFi.CIN);
                        print.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("Veuillez selectionner un doctorant à imprimer", " Impression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else 
            {
                MessageBox.Show("Il n'y a aucun doctorant à imprimer", " Impression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnImpressions_Click(object sender, EventArgs e)
        {
            FormPDFGenerator f11 = new FormPDFGenerator();
            f11.Show();
        }



        public void getCurrentStudent(string CIN)
        {

            int i = 0;
            while ((i < dgvDoctorants.Rows.Count) && (dgvDoctorants.Rows[i].Cells["CIN"].Value.ToString() != CIN))
            {
                i++;
            }

            if (i < dgvDoctorants.Rows.Count)
            {
                dgvDoctorants.Rows[i].Selected = true;
            }

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (this.useMode == "Ajouter")
            {

                try
                {
                    ValidateData();
                    FormatData();                    
                    NewFi = getFicheInformationFromInterface();
                    string lastInsertedDoct = NewFi.CIN;
                    BLFicheInformation.AddNew(NewFi);
                    ImageUtilities.savePhotoDoctorant(pbDoctorant, NewFi.CIN);
                    MessageBox.Show("Doctorant sauvegardé avec succès", "Ajout d'un nouveau doctorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindDataToDgvDoctorants();
                    dgvDoctorants.ClearSelection();
                    try
                    {
                        if (cmbRecherche.SelectedItem != null && cmbRecherche.SelectedItem.ToString() == "Spécialité")
                        {
                            ComboUtilities.bindDataToCmbValeur(Program.cnn, cmbValeur, "FicheInformation", "Specialite", "Specialite");
                            dgvDoctorants.ClearSelection();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    SetUseMode("Consulter");   
                    getCurrentStudent(lastInsertedDoct);
                    AppearanceHandler.ResetInitialAppearance(this.EmptyCtrls, this.ToolTipErrorsInfos);
                }
                catch (DataValidationException Ex)
                {
                    MessageBox.Show(Ex.ExceptionMessage, "GP : Erreur dans la saisie des données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppearanceHandler.SetErrorAppearance(this.FrmErrorCtrls, this.ToolTipErrorsInfos);
                }
                catch (MyException MyEx)
                {
                    MessageBox.Show(MyEx.MyExceptionMessage, "Gp : " + MyEx.MyExceptionTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    ValidateData();
                    FormatData();
                    ImageUtilities.savePhotoDoctorant(pbDoctorant,NewFi.CIN);
                    NewFi = getFicheInformationFromInterface();
                    string lastInsertedDoct = NewFi.CIN;
                    BLFicheInformation.update(CurFi, NewFi);
                    MessageBox.Show("Doctorant modifié avec succès", "Modification d'un doctorant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindDataToDgvDoctorants();
                    dgvDoctorants.ClearSelection();

                    if (cmbRecherche.SelectedItem.ToString() == "Spécialité")
                    {
                        ComboUtilities.bindDataToCmbValeur(Program.cnn, cmbValeur, "FicheInformation", "Specialite", "Specialite");
                        dgvDoctorants.ClearSelection();
                    } 

                    SetUseMode("Consulter");
                    getCurrentStudent(lastInsertedDoct);
                    AppearanceHandler.ResetInitialAppearance(this.EmptyCtrls, this.ToolTipErrorsInfos);
                }
                catch (DataValidationException Ex)
                {
                    MessageBox.Show(Ex.ExceptionMessage, "GP : Erreur dans la saisie des données", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AppearanceHandler.SetErrorAppearance(this.FrmErrorCtrls, this.ToolTipErrorsInfos);
                }
                catch (MyException MyEx)
                {
                    MessageBox.Show(MyEx.MyExceptionMessage, "Gp : " + MyEx.MyExceptionTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
             SetUseMode("Consulter");
             AppearanceHandler.ResetInitialAppearance(this.FrmErrorCtrls, ToolTipErrorsInfos);
             AppearanceHandler.ResetInitialAppearance(EmptyCtrls, ToolTipErrorsInfos);        
        }

        
        private void lblPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog OFDLoadPhotoDoct=new OpenFileDialog();
            OFDLoadPhotoDoct.Title = "Insert an image ";
            OFDLoadPhotoDoct.InitialDirectory = "c:";
            OFDLoadPhotoDoct.FileName = "";
            OFDLoadPhotoDoct.Filter = "All files (*.*)|*.*|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";
            OFDLoadPhotoDoct.Multiselect = false;
            if (OFDLoadPhotoDoct.ShowDialog() == DialogResult.OK)
            {
                pbDoctorant.ImageLocation = OFDLoadPhotoDoct.FileName;
            }
        }

        

        private void cmbRecherche_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbRecherche.SelectedItem.ToString())
            {
                case "Tous":

                    this.lastSelectedValue = "Tous";
                    bindDataToDgvDoctorants();
                    AppearanceHandler.HideControls(txtRecherche);
                    AppearanceHandler.HideControls(cmbValeur);
                    
                    break;
                case "Spécialité":
                    if (lastSelectedValue != "Tous")
                    {
                        this.lastSelectedValue = "Spécialité";
                    }
                   
                    AppearanceHandler.ShowControls(cmbValeur);
                    AppearanceHandler.HideControls(txtRecherche);
                    ComboUtilities.bindDataToCmbValeur(Program.cnn, cmbValeur, "FicheInformation", "Specialite", "Specialite");
                    break;

                default :    
                    txtRecherche.Text = string.Empty;
                    AppearanceHandler.ShowControls(txtRecherche);
                    AppearanceHandler.HideControls(cmbValeur);
                    break;

            }
            
        }

       
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            if (this.lastSelectedValue == "Tous")
            {
                if (listFicheInfo!=null)
                {
                    DataView dv = new DataView(listFicheInfo.dt);
                    {
                        switch (cmbRecherche.SelectedItem.ToString().Trim())
                        {
                            case "CIN":
                                dv.RowFilter = string.Format("Cin LIKE '%{0}%'", txtRecherche.Text);
                                break;
                            case "Nom et Prénom":
                                dv.RowFilter = string.Format("NomPrenom LIKE '%{0}%'", txtRecherche.Text);
                                break;
                        }

                        dgvDoctorants.DataSource = dv;
                        if (dgvDoctorants.RowCount == 0)
                        {
                            dgvInscriptions.DataSource = null;
                            dgvDiplomes.DataSource = null;
                            reset2();
                            initialiseDgvDiplome();
                            initialiseDgvInscription();
                            AppearanceHandler.HideControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
                        }
                        else
                        {
                            AppearanceHandler.ShowControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
                        }

                    }
                }
                }
                else
                {
                    listFicheInfo = BLFicheInformation.getAll();
                    if (listFicheInfo != null)
                    {
                        DataView dv = new DataView(listFicheInfo.dt);
                        dgvDoctorants.DataSource = null;
                        dgvDoctorants.Columns.Clear();

                        switch (cmbRecherche.SelectedItem.ToString().Trim())
                        {
                            case "CIN":
                                dv.RowFilter = string.Format("Cin LIKE '%{0}%'", txtRecherche.Text);
                                break;
                            case "Nom et Prénom":
                                dv.RowFilter = string.Format("NomPrenom LIKE '%{0}%'", txtRecherche.Text);
                                break;
                        }

                       
                        dgvDoctorants.DataSource = dv;
                        renetializeDgvDoctorants();
                        if (dgvDoctorants.RowCount == 0)
                        {
                            dgvInscriptions.DataSource = null;
                            dgvDiplomes.DataSource = null;
                            reset2();
                            initialiseDgvDiplome();
                            initialiseDgvInscription();
                            AppearanceHandler.HideControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
                        }
                        else
                        {
                            AppearanceHandler.ShowControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
                        }
                    }
                }

            
        }


        private void cmbValeur_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lastSelectedValue == "Tous")
            {
                DataView dv = new DataView(listFicheInfo.dt);
                if (cmbValeur.SelectedIndex > -1)
                {
                    if (cmbRecherche.SelectedItem.ToString()=="Spécialité")
                    {
                            dv.RowFilter = "Specialite LIKE'%" + cmbValeur.SelectedValue.ToString().Replace("'", "''") + "%'";
                    }
                }
                dgvDoctorants.DataSource = dv;

            }
            else
            {
                if (cmbValeur.SelectedIndex > -1)
                {
                    if (cmbRecherche.SelectedItem.ToString() == "Spécialité")
                    {
                        listFicheInfo = BLFicheInformation.getByCretrium("Specialite", SqlDbType.NVarChar, cmbValeur.SelectedValue.ToString());

                        if (listFicheInfo != null)
                        {
                            dgvDoctorants.Columns.Clear();
                            dgvDoctorants.DataSource = listFicheInfo.dt;
                            renetializeDgvDoctorants();
                            AppearanceHandler.ShowControls(new Control[] { grpGestionInscrits, grpGestionDiplomes });
                        }

                    }
                }
 
            }
        }

        

        private void cmbCivilite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] nationaliteMasculin = new string[] 
            { 
                "Afghan","Albanais","Algérien","Allemand","Américain","Angolais","Argentin","Arménien","Australien","Autrichien","Bahaméen"
            ,"Bangladais","Belge","Benin","Biélorusse","Bosniaque","Botswanais","Bouthan","Brésilien","Britannique","Bulgare","Burkinabè","Cambodgien","Camerounais"
            ,"Canadien","Chilien","Chinois","Chypriote","Colombien","Congolais","Croate","Cubain","Danois","Dominicain","Ecossais","Egyptien","Equatorien"
            ,"Espagnol","Estonien","Ethiopien","Européen","Finlandais","Français","Gabonais","Georgien","Grec","Guatemala","Guinéen"
            ,"Haïtien","Hollandais","Hong-Kong","Hongrois","Indien","Indonésien","Irakien","Iranien","Irlandais","Islandais","Italien","Ivoirien"
            ,"Jamaïcain","Japonais","Jordanien","Kazakh","Kirghiz","Kurde","Letton","Libanais","Libyen","Liechtenstein","Lituanien","Luxembourgeois","Macédonien"
            ,"Madagascar","Malaisien","Malien","Maltais","Marocain","Mauritanien","Mauritien","Mexicain","Monégasque","Mongol"
            ,"Mozambique","Néo-Zélandais","Népalais","Nigérien","Nord Coréen","Norvégien","Pakistanais","Palestinien","Panaméen","Paraguayen","Péruvien"
            ,"Philippiens","Polonais","Portoricain","Portugais","Qatar","Roumain","Russe","Rwandais","Saoudien","Sénégalais","Serbe","Serbo-Croate","Singapour"
            ,"Slovaque","Soviétique","Sri-Lankais","Sud-Africain","Sud-Coréen","Suédois","Suisse","Syrien","Tadjik","Taïwanais","Tanzanien","Tchadien"
            ,"Tchèque","Thaïlandais","Tunisien","Turc","Ukranien","Uruguayen","Vénézuélien","Vietnamien","Yougoslave","Zimbabwéen"
            };



           string[] nationaliteFeminin = new string[]
           {
               "Afghane","Albanaise","Algérienne","Allemande","Américaine"
            ,"Angolaise","Argentine","Arménienne","Australienne","Autrichienne","Bahaméenne","Bangladaise","Belgique","Beninoise"
            ,"Biélorusse","Bosniaque","Botswanaise","Bouthanaise","Brésilienne","Britannique","Bulgare"
            ,"Burkinabè","Cambodge","Camerounaise","Canadienne","Chilienne","Chinoise","Chypriote","Colombienne","Congolaise","Croate","Cubaine","Danoise"
            ,"Dominicaine","Ecossaise","Egyptienne","Equatorienne","Espagnole","Estonienne","Ethiopienne","Européenne","Finlandaise"
            ,"Française","Gabonaise","Georgienne","Grece","Guatemala","Guinéenne","Haïtienne","Hollandaise","Hong-Kong","Hongroise"
            ,"Indienne","Indonésienne","Irakienne","Iranienne","Irlandaise","Islandaise","Italienne","Ivoirienne","Jamaïcaine"
            ,"Japonaise","Jordanienne","Kazakhstan","Kirghize","Kurde","Lettone","Libanaise","Libyenne","Liechtensteinne","Lituanienne"
            ,"Luxembourgeoise","Macédonienne","Madagascar","Malaisienne","Malienne","Maltaise","Marocaine","Mauritanienne","Mauritienne"
            ,"Mexicaine","Monégasque","Mongole","Mozambique","Néo-Zélandaise","Népalaise","Nigérienne","Nord Coréenne","Norvégienne"
            ,"Pakistanaise","Palestinienne","Panaméenne","Paraguayenne","Péruvienne","Philippines","Polonaise","Portoricaine","Portugaise"
            ,"Qatar","Roumaine","Russe","Rwandaise","Saoudienne","Sénégalaise","Serbe","Serbo-Croate","Singapourienne","Slovaque","Soviétique"
            ,"Sri-Lankaise","Sud-Africaine","Sud-Coréenne","Suédoise","Suisse","Syrienne","Tadjikistan"
            ,"Taïwanaise","Tanzanienne","Tchadienne","Tchèque","Thaïlandaise","Tunisienne","Turque"
            ,"Ukranienne","Uruguayenne","Vénézuélienne","Vietnamienne","Yougoslave","Zimbabwéenne"
           };
           if (cmbCivilite.SelectedIndex > 0)
           {
               cmbNationalite.Items.Clear();
               for (int i = 0; i < nationaliteFeminin.Length; i++)
               {   
                   cmbNationalite.Items.Add(nationaliteFeminin[i]);
               }

           }
           else
           {
               cmbNationalite.Items.Clear();
               for (int i = 0; i < nationaliteMasculin.Length; i++)
               {
                   cmbNationalite.Items.Add(nationaliteMasculin[i]);
               }
           }
        }

        
        public int existe(List<ErrorCtrlMsg> FormatErrorCtrl , PictureBox pbField)
        {
            
                int i = 0;
                while (i < FormatErrorCtrl.Count() && FormatErrorCtrl[i].pictureErrorControl != pbField)
                {
                    i++;
                }

                if (i < FormatErrorCtrl.Count())
                {
                    return i;
                }
                else
                {
                    return -1;
                }
           
        }

        public bool supprimerError(List<ErrorCtrlMsg> FormatErrorCtrl, PictureBox pbField)
        {
            int exist = existe(FormatErrorCtrl,pbField);
            if (exist > -1)
            {
                FormatErrorCtrl.RemoveAt(exist);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtCin_Validated(object sender, EventArgs e)
        {
            if (txtCin.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtCin.Text.Length && t == true; i++)
                    if (!char.IsNumber(txtCin.Text[i]) && !char.IsControl(txtCin.Text[i]))
                        t = false;
                if (txtCin.Text.Length != 8)
                    t = false;
                if (t == false && pbCin.ImageLocation != @"Resources\No-icon.png")
                    pbCin.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbCin.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtCin, pbCin, "Cin"));
                }

            }
            else
                pbCin.ImageLocation = null;
        }

        private void txtNomPrenom_Validated(object sender, EventArgs e)
        {
            if (txtNomPrenom.Text != string.Empty)
            {
                bool t = true;
                int p = 0;
                for (int i = 0; i < txtNomPrenom.Text.Length && t == true; i++)
                {
                    if (!char.IsLetter(txtNomPrenom.Text[i]) && !char.IsControl(txtNomPrenom.Text[i]) && !char.IsWhiteSpace(txtNomPrenom.Text[i]))
                        t = false;
                    if (char.IsWhiteSpace(txtNomPrenom.Text[i]))
                        p = i;
                }
                if (p == 0 || p == txtNomPrenom.Text.Length-1)
                    t = false;
                if (t == false && pbNomPrenom.ImageLocation != @"Resources\No-icon.png")
                    pbNomPrenom.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbNomPrenom.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtNomPrenom, pbNomPrenom, "Nom & Prénom"));
                }
            }

            else
                pbNomPrenom.ImageLocation = null;
        }

        private void txtLieu_Validated(object sender, EventArgs e)
        {
            if (txtLieu.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtLieu.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtLieu.Text[i]) && !char.IsControl(txtLieu.Text[i]) && !char.IsWhiteSpace(txtLieu.Text[i]))
                        t = false;
                if (t == false && pbLieu.ImageLocation != @"Resources\No-icon.png")
                    pbLieu.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbLieu.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtLieu, pbLieu, "Lieu"));
                }
            }
            else
                pbLieu.ImageLocation = null;
        }

        private void txtAdresse_Validated(object sender, EventArgs e)
        {
            if (txtAdresse.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtAdresse.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtAdresse.Text[i]) && !char.IsControl(txtAdresse.Text[i]) && !char.IsWhiteSpace(txtAdresse.Text[i]))
                        t = false;
                if (t == false && pbAdresse.ImageLocation != @"Resources\No-icon.png")
                    pbAdresse.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbAdresse.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtAdresse, pbAdresse, "Adresse"));
                }
            }
            else
                pbAdresse.ImageLocation = null;
        }

        private void txtGouvernorat_Validated(object sender, EventArgs e)
        {
            if (txtGouvernorat.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtGouvernorat.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtGouvernorat.Text[i]) && !char.IsControl(txtGouvernorat.Text[i]) && !char.IsWhiteSpace(txtGouvernorat.Text[i]))
                        t = false;
                if (t == false && pbGouvernorat.ImageLocation != @"Resources\No-icon.png")
                    pbGouvernorat.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbGouvernorat.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtGouvernorat, pbGouvernorat, "Gouvernorat"));
                }
            }
            else
                pbGouvernorat.ImageLocation = null;
        }

        private void txtVille_Validated(object sender, EventArgs e)
        {
            if (txtVille.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtVille.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtVille.Text[i]) && !char.IsControl(txtVille.Text[i]) && !char.IsWhiteSpace(txtVille.Text[i]))
                        t = false;
                if (t == false && pbVille.ImageLocation != @"Resources\No-icon.png")
                    pbVille.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbVille.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtVille, pbVille, "Ville"));
                }
            }
            else
                pbVille.ImageLocation = null;
        }

        private void txtCodePostal_Validated(object sender, EventArgs e)
        {
            if (txtCodePostal.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtCodePostal.Text.Length && t == true; i++)
                    if (!char.IsNumber(txtCodePostal.Text[i]) && !char.IsControl(txtCodePostal.Text[i]))
                        t = false;
                if (txtCodePostal.Text.Length < 4)
                    t = false;
                if (t == false && pbCodePostal.ImageLocation != @"Resources\No-icon.png")
                    pbCodePostal.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbCodePostal.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtCodePostal, pbCodePostal, "Code postal"));
                }
            }
            else
                pbCodePostal.ImageLocation = null;
        }

        private void txtTelephone_Validated(object sender, EventArgs e)
        {
            if (txtTelephone.Text != string.Empty)
            {
                string paramRegex = "[+]{0,1}[ 0-9]{6,30}";

                if (!DataFormatValidation.isString(txtTelephone.Text, paramRegex) && txtTelephone.Text.Length > 7 && txtTelephone.Text.Length < 14)
                {
                    if (supprimerError(FormatErrorCtrls, pbTelephone))
                    {
                        NbFormatErrors--;
                    }
                    pbTelephone.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtTelephone, pbTelephone, "Téléphone"));

                }
                else
                {
                    if (existe(FormatErrorCtrls, pbTelephone) == -1)
                    {
                        if (pbTelephone.ImageLocation != @"Resources\No-icon.png")
                        {
                            pbTelephone.ImageLocation = @"Resources\No-icon.png";
                        }
                        NbFormatErrors++;
                        FormatErrorMsg = "Téléphone";
                        FormatErrorCtrls.Add(new ErrorCtrlMsg(txtTelephone, pbTelephone, FormatErrorMsg));
                    }
                }
            }
            else
                pbTelephone.ImageLocation = null;
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            if (txtEmail.Text != string.Empty)
            {
                if (!DataFormatValidation.ValidMail(txtEmail.Text))
                {
                    if (supprimerError(FormatErrorCtrls, pbEmail))
                    {
                        NbFormatErrors--;
                    }
                    pbEmail.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtEmail, pbEmail, "Email"));

                }
                else
                {
                    if (existe(FormatErrorCtrls, pbEmail) == -1)
                    {
                        if (pbEmail.ImageLocation != @"Resources\No-icon.png")
                        {
                            pbEmail.ImageLocation = @"Resources\No-icon.png";
                        }
                        NbFormatErrors++;
                        FormatErrorMsg = "Email";
                        FormatErrorCtrls.Add(new ErrorCtrlMsg(txtEmail, pbEmail, FormatErrorMsg));
                    }
                }
            }
            else
                pbEmail.ImageLocation = null;
        }

        private void txtProfession_Validated(object sender, EventArgs e)
        {
            if (txtProfession.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtProfession.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtProfession.Text[i]) && !char.IsControl(txtProfession.Text[i]) && !char.IsWhiteSpace(txtProfession.Text[i]))
                        t = false;
                if (t == false && pbProfession.ImageLocation != @"Resources\No-icon.png")
                    pbProfession.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbProfession.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtProfession, pbProfession, "Profession"));
                }
            }
            else
                pbProfession.ImageLocation = null;
        }

        private void txtEmployeur_Validated(object sender, EventArgs e)
        {
            if (txtEmployeur.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtEmployeur.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtEmployeur.Text[i]) && !char.IsControl(txtEmployeur.Text[i]) && !char.IsWhiteSpace(txtEmployeur.Text[i]))
                        t = false;
                if (t == false && pbEmployeur.ImageLocation != @"Resources\No-icon.png")
                    pbEmployeur.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbEmployeur.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtEmployeur, pbEmployeur, "Employeur"));
                }
            }
            else
                pbEmployeur.ImageLocation = null;
        }

        private void txtSpecialite_Validated(object sender, EventArgs e)
        {
            if (txtSpecialite.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtSpecialite.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtSpecialite.Text[i]) && !char.IsControl(txtSpecialite.Text[i]) && !char.IsWhiteSpace(txtSpecialite.Text[i]))
                        t = false;
                if (t == false && pbSpecialite.ImageLocation != @"Resources\No-icon.png")
                    pbSpecialite.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbSpecialite.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtSpecialite, pbSpecialite, "Spécialité"));
                }
            }
            else
                pbSpecialite.ImageLocation = null;
        }

        private void txtLaboRecherche_Validated(object sender, EventArgs e)
        {
            if (txtLaboRecherche.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtLaboRecherche.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtLaboRecherche.Text[i]) && !char.IsControl(txtLaboRecherche.Text[i]) && !char.IsWhiteSpace(txtLaboRecherche.Text[i]))
                        t = false;
                if (t == false && pbLaboRecherche.ImageLocation != @"Resources\No-icon.png")
                    pbLaboRecherche.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbLaboRecherche.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtLaboRecherche, pbLaboRecherche, "Labo Recherche"));
                }
            }
            else
                pbLaboRecherche.ImageLocation = null;
        }

        private void txtLaboRechercheCotutelle_Validated(object sender, EventArgs e)
        {
            if (txtLaboRechercheCotutelle.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtLaboRechercheCotutelle.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtLaboRechercheCotutelle.Text[i]) && !char.IsControl(txtLaboRechercheCotutelle.Text[i]) && !char.IsWhiteSpace(txtLaboRechercheCotutelle.Text[i]))
                        t = false;
                if (t == false && pbLaboRechercheCotutelle.ImageLocation != @"Resources\No-icon.png")
                    pbLaboRechercheCotutelle.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbLaboRechercheCotutelle.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtLaboRechercheCotutelle, pbLaboRechercheCotutelle, "Labo Recherche Cotutelle"));
                }
            }
            else
                pbLaboRechercheCotutelle.ImageLocation = null;
        }

        private void txtEncadrant_Validated(object sender, EventArgs e)
        {
            if (txtEncadrant.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtEncadrant.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtEncadrant.Text[i]) && !char.IsControl(txtEncadrant.Text[i]) && !char.IsWhiteSpace(txtEncadrant.Text[i]))
                        t = false;
                if (t == false && pbEncadrant.ImageLocation != @"Resources\No-icon.png")
                    pbEncadrant.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbEncadrant.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtEncadrant, pbEncadrant, "Encadrant"));
                }
            }
            else
                pbEncadrant.ImageLocation = null;
        }

        private void txtCoEncadrant_Validated(object sender, EventArgs e)
        {
            if (txtCoEncadrant.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtCoEncadrant.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtCoEncadrant.Text[i]) && !char.IsControl(txtCoEncadrant.Text[i]) && !char.IsWhiteSpace(txtCoEncadrant.Text[i]))
                        t = false;
                if (t == false && pbCoEncadrant.ImageLocation != @"Resources\No-icon.png")
                    pbCoEncadrant.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbCoEncadrant.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtCoEncadrant, pbCoEncadrant, "CoEncadrant"));
                }
            }
            else
                pbCoEncadrant.ImageLocation = null;
        }

        private void txtSujet_Validated(object sender, EventArgs e)
        {
            if (txtSujet.Text != string.Empty)
            {
                bool t = true;
                for (int i = 0; i < txtSujet.Text.Length && t == true; i++)
                    if (!char.IsLetter(txtSujet.Text[i]) && !char.IsControl(txtSujet.Text[i]) && !char.IsWhiteSpace(txtSujet.Text[i]))
                        t = false;
                if (t == false && pbSujet.ImageLocation != @"Resources\No-icon.png")
                    pbSujet.ImageLocation = @"Resources\No-icon.png";
                else
                {
                    pbSujet.ImageLocation = @"Resources\Ok-icon.png";
                    EmptyCtrls.Add(new EmptyCtrlMsg(txtSujet, pbSujet, "Sujet"));
                }
            }
            else
                pbSujet.ImageLocation = null;
        }

    
        private void cmbCivilite_Validated(object sender, EventArgs e)
        {
             if (cmbCivilite.SelectedIndex >= 0)
             {
                 pbCivilite.ImageLocation = @"Resources\Ok-icon.png";
                 EmptyCtrls.Add(new EmptyCtrlMsg(cmbCivilite, pbCivilite, "Civilité"));
             }                  
        }

        private void cmbNationalite_Validated(object sender, EventArgs e)
        {
             if (cmbNationalite.SelectedIndex >= 0)
             {
                 pbNationalite.ImageLocation = @"Resources\Ok-icon.png";
                 EmptyCtrls.Add(new EmptyCtrlMsg(cmbNationalite, pbNationalite, "Nationalité"));
             }
        }

        private void cmbPaysOrigine_Validated(object sender, EventArgs e)
        {
             if (cmbPaysOrigine.SelectedIndex >= 0)
             {
                pbPaysOrigine.ImageLocation = @"Resources\Ok-icon.png";
                EmptyCtrls.Add(new EmptyCtrlMsg(cmbPaysOrigine , pbPaysOrigine ,"Pays d'origine"));
             }        
        }

        private void FicheInfoDoctorant_SizeChanged(object sender, EventArgs e)
        {
            ContextMenu CM=new ContextMenu();
            
            if (this.WindowState == FormWindowState.Minimized)
            {
                niGEDOCT.Icon = this.Icon;
                niGEDOCT.BalloonTipText = "Cliquez ici pour ouvrir ";
                niGEDOCT.BalloonTipTitle = "GEDOCT v1.0 : Gestion des doctorants du FSM";
                niGEDOCT.ShowBalloonTip(1000);
            }
                
        }

        private void niGEDOCT_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void niGEDOCT_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.Show();
                    this.ShowInTaskbar = true;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.Hide();
                    this.ShowInTaskbar = false;
                    this.WindowState = FormWindowState.Minimized;
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                ContextMenu CtxtMenu;
                CtxtMenu = new ContextMenu();
                
                MenuItem show = new MenuItem("Show",new System.EventHandler(Show_Click));
                show.Shortcut = Shortcut.CtrlS;
                MenuItem hide = new MenuItem("Hide",new System.EventHandler(Hide_Click));
                hide.Shortcut = Shortcut.CtrlH;
                MenuItem exit = new MenuItem("Exit",new System.EventHandler(Exit_Click));
                exit.Shortcut = Shortcut.CtrlE;

                CtxtMenu.MenuItems.Add(0,show);
                CtxtMenu.MenuItems.Add(1,hide);
                CtxtMenu.MenuItems.Add(2,exit);

                niGEDOCT.ContextMenu = CtxtMenu;
            }
        }

        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            if (this.useMode != "Consulter")
            {
                FormClosing frm = new FormClosing(@"Resources\warning.png", "Attention !\nMode édition activé\nVoulez-vous vraiment quitter ?", this.useMode);
                frm.ShowDialog();
                if (frm.exit == true)
                {
                    //Application.Exit();
                    MessageBox.Show(""+frm.exit);
                }

            }
            else
            {
                if (File.Exists("chechBoxState.txt"))
                {
                    Application.Exit();
                }
                else
                {
                    FormClosing frm = new FormClosing(@"Resources\FAQ.png", "Voulez-vous vraiment quitter", this.useMode);
                    frm.ShowDialog();

                    if (frm.exit == true)
                    {
                        Application.Exit();
                    }
                }
            }
        }
        protected void Hide_Click(Object sender, System.EventArgs e)
        {
            Hide();
        }
        protected void Show_Click(Object sender, System.EventArgs e)
        {
            Show();
        }

        private void FicheInfoDoctorant_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.useMode != "Consulter")
            {
                FormClosing frm = new FormClosing(@"Resources\warning.png", "Attention !\nMode édition activé\nVoulez-vous vraiment quitter ?", this.useMode, e);
                frm.ShowDialog();
            }
            else
            {
                if (File.Exists("chechBoxState.txt"))
                {
                    Application.Exit();
                }
                else
                {
                    FormClosing frm = new FormClosing(@"Resources\FAQ.png", "Voulez-vous vraiment quitter", this.useMode,e);
                    frm.ShowDialog();
                }
            }
        }

        private void btnImportDoct_Click(object sender, EventArgs e)
        {
            try
            {
                ImportFromExcel.GetFromExcel();

                bindDataToDgvDoctorants();
                AppearanceHandler.HideControls(txtRecherche);
                AppearanceHandler.HideControls(cmbValeur);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtSujet_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            i = int.Parse(lblNbCaracteresSaisis.Text);

            if (e.KeyChar == (Char)Keys.Back)
            {
                if (i > 0)
                {
                    if (txtSujet.SelectionLength >= 1)
                    {
                        i -= txtSujet.SelectionLength;
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
                if (i < 1024)
                {
                    i++;
                    lblNbCaracteresSaisis.Text = i.ToString();
                }
        }

   
    }
}
