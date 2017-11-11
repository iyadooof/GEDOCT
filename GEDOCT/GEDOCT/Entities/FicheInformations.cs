using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDOCT.Entities
{
    class FicheInformations
    {
        string NomPrenom;
        string Cin;
        string Civilite;
        string Adresse;
        string CodePostal;
        string Telephone;
        string PaysOrigine;
        string Nationalite;
        string VilleNaissance;
        string Gouvernorat;
        string CoEncadrant;
        string DateNaissance;
        string Email;
        string Employeur;
        string Encadrant;
        string LaboUniteRecherche;
        string LaboUniteRechercheCotutelle;
        string Profession;
        string Specialite;
        string Sujet;
        string Ville;


        public FicheInformations()
        { }

        public FicheInformations(DataRow dr)
        {
            this.NomPrenom = dr["NomPrenom"].ToString();
            this.Civilite = dr["Civilite"].ToString();
            this.Cin = dr["Cin"].ToString();
            this.DateNaissance = dr["DateNaissance"].ToString();
            this.Adresse = dr["Adresse"].ToString();
            this.Nationalite = dr["Nationalite"].ToString();
            this.VilleNaissance = dr["VilleNaissance"].ToString();
            this.Gouvernorat = dr["Gouvernorat"].ToString();
            this.Ville = dr["Ville"].ToString();
            this.CodePostal = dr["CodePostal"].ToString();
            this.PaysOrigine = dr["PaysOrigine"].ToString();
            this.Profession = dr["Profession"].ToString();
            this.Telephone = dr["Telephone"].ToString();
            this.CoEncadrant = dr["CoEncadrant"].ToString();
            this.Email = dr["Email"].ToString();
            this.Employeur = dr["Employeur"].ToString();
            this.Encadrant = dr["Encadrant"].ToString();
            this.LaboUniteRecherche = dr["LaboUniteeRecherche"].ToString();
            this.LaboUniteRechercheCotutelle = dr["LaboUniteeRechercheCotutelle"].ToString();
            this.Specialite = dr["Specialite"].ToString();
            this.Sujet = dr["Sujet"].ToString();
        }

        public string NOMPRENOM
        {
            get { return this.NomPrenom; }
            set { this.NomPrenom = value; }
        }

        public string CIN
        {
            get { return this.Cin; }
            set { this.Cin = value; }
        }

        public string CIVILITE
        {
            get { return this.Civilite; }
            set { this.Civilite = value; }
        }

        public string DATENAISSANCE
        {
            get { return this.DateNaissance; }
            set { this.DateNaissance = value; }
        }

        public string ADRESSE
        {
            get { return this.Adresse; }
            set { this.Adresse = value; }
        }

        public string NATIONALITE
        {
            get { return this.Nationalite; }
            set { this.Nationalite = value; }
        }

        public string VILLENAISSANCE
        {
            get { return this.VilleNaissance; }
            set { this.VilleNaissance = value; }
        }

        public string GOUVERNORAT
        {
            get { return this.Gouvernorat; }
            set { this.Gouvernorat = value; }
        }

        public string VILLE
        {
            get { return this.Ville; }
            set { this.Ville = value; }
        }

        public string CODEPOSTAL
        {
            get { return this.CodePostal; }
            set { this.CodePostal = value; }
        }

        public string PAYSORIGINE
        {
            get { return this.PaysOrigine; }
            set { this.PaysOrigine = value; }
        }

        public string PROFESSION
        {
            get { return this.Profession; }
            set { this.Profession = value; }
        }

        public string TELEPHONE
        {
            get { return this.Telephone; }
            set { this.Telephone = value; }
        }

        public string COENCADRANT
        {
            get { return this.CoEncadrant; }
            set { this.CoEncadrant = value; }
        }


        public string EMAIL
        {
            get { return this.Email; }
            set { this.Email = value; }
        }

        public string EMPLOYEUR
        {
            get { return this.Employeur; }
            set { this.Employeur = value; }
        }

        public string ENCADRANT
        {
            get { return this.Encadrant; }
            set { this.Encadrant = value; }
        }

        public string LABOUNITEERECHERCHE
        {
            get { return this.LaboUniteRecherche; }
            set { this.LaboUniteRecherche = value; }
        }

        public string LABOUNITEERECHERCHECOTUTELLE
        {
            get { return this.LaboUniteRechercheCotutelle; }
            set { this.LaboUniteRechercheCotutelle = value; }
        }

        public string SPECIALITE
        {
            get { return this.Specialite; }
            set { this.Specialite = value; }
        }

        public string SUJET
        {
            get { return this.Sujet; }
            set { this.Sujet = value; }
        }
    }


    class ListFicheInformations
    {
        public DataTable dt;


        public ListFicheInformations()
        {
 
        }

        public ListFicheInformations(DataTable dt)
        {
            this.dt = dt;
        }

        public List<FicheInformations> getAll()
        {
            if (this.dt != null)
            {
                List<FicheInformations> lstFiche = new List<FicheInformations>(this.dt.Rows.Count);
                foreach (DataRow dr in this.dt.Rows)
                {
                    lstFiche.Add(new FicheInformations(dr));
                }
                return lstFiche;

            }
            else
            {
                return null;
            }
        }
    }
}
