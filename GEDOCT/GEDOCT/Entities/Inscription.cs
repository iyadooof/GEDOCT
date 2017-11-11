using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDOCT.Entities
{
    class Inscription
    {
        string AnneeUniversitaire;
        string Commentaire;
        string Id;
        string Cin;
        string Niveau;

        public Inscription() { }

        public Inscription(DataRow dr)
        {
            this.AnneeUniversitaire = dr["AnneeUniversitaire"].ToString();
            this.Commentaire = dr["Commentaire"].ToString();
            this.Id = dr["Id"].ToString();
            this.Cin = dr["Cin"].ToString();
            this.Niveau = dr["Niveau"].ToString();
        }

        public string ANNEEUNIVERSITAIRE
        {
            get { return this.AnneeUniversitaire; }
            set { this.AnneeUniversitaire = value; }
        }

        public string COMMENTAIRE
        {
            get { return this.Commentaire; }
            set { this.Commentaire = value; }
        }

        public string ID
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        public string CIN
        {
            get { return this.Cin; }
            set { this.Cin = value; }
        }

        public string NIVEAU
        {
            get { return this.Niveau; }
            set { this.Niveau = value; }
        }

    }

    class ListInscription
    {

        public DataTable dt;
        public ListInscription() { }
        public ListInscription(DataTable dt)
        {
            this.dt = dt;
        }

        public List<Inscription> getAll()
        {
            if (this.dt != null)
            {
                List<Inscription> lstInscription = new List<Inscription>(dt.Rows.Count);
                foreach (DataRow dr in this.dt.Rows)
                {
                    lstInscription.Add(new Inscription(dr));
                }
                return lstInscription;
            }
            else
            {
                return null;
            }
        }

    }
}
