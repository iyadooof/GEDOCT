using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDOCT.Entities
{
    class Diplome
    {
        string Annee;
        string _Diplome;
        string Specialite;
        string Mention;
        string Id;
        string Cin;
        string Institution;


        public Diplome() { }

        public Diplome(DataRow dr)
        {
            this.Annee = dr["Annee"].ToString();
            this._Diplome = dr["Diplome"].ToString();
            this.Specialite = dr["Specialite"].ToString();
            this.Mention = dr["Mention"].ToString();
            this.Id = dr["Id"].ToString();
            this.Cin = dr["Cin"].ToString();
            this.Institution = dr["Institution"].ToString();
        }

        public string ANNEE
        {
            get { return this.Annee; }
            set { this.Annee = value; }
        }

        public string DIPLOME
        {
            get { return this._Diplome; }
            set { this._Diplome = value; }
        }

        public string SPECIALITE
        {
            get { return this.Specialite; }
            set { this.Specialite = value; }
        }

        public string MENTION
        {
            get { return this.Mention; }
            set { this.Mention = value; }
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

        public string INSTITUTION
        {
            get { return this.Institution; }
            set { this.Institution = value; }
        }

    }


    class ListDiplome
    {
        public DataTable dt;

        public ListDiplome() { }

        public ListDiplome(DataTable dt)
        {
            this.dt = dt;
        }

        public List<Diplome> getAll()
        {
            if (this.dt != null)
            {
                List<Diplome> lstDiplome = new List<Diplome>(this.dt.Rows.Count);
                foreach (DataRow dr in this.dt.Rows)
                {
                    lstDiplome.Add(new Diplome(dr));
                }

                return lstDiplome;
            }
            else
            {
                return null;
            }

        }
    }
}
