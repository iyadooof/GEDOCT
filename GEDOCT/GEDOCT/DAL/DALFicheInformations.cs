using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GEDOCT.MyUtilities;
using GEDOCT.MyUtilities.DataAccess;
using GEDOCT.Entities;
namespace GEDOCT.DAL
{
    class DALFicheInformations
    {
       

        public static bool checkKeyUnicity(string Cin)
        {
            string request = "SELECT count(*) from FicheInformation where CIN=@CIN";
            SqlCeCommand cmd = new SqlCeCommand(request , Program.cnn);
            cmd.Parameters.Add("@CIN", SqlDbType.NVarChar).Value = Cin;
            int x = (int)DataBaseAccessUtilities.ScalarRequest(cmd);

            if (x == 0)
                return false;
            else
                return true;
        }

        public static int Insert(FicheInformations fi)
        {
            string StrSQL = "INSERT INTO  FicheInformation VALUES (@CIN,@NomPrenom,@Civilite,@DateNaissance,@VilleNaissance,@PaysOrigine" +
             ",@Nationalite,@Adresse,@Ville,@CodePostal,@Gouvernorat,@Telephone,@Email,@Profession,@Employeur,@Specialite," +
             "@LaboUniteeRecherche,@LaboUniteeRechercheCotutelle,@Encadrant,@CoEncadrant,@Sujet)";
            SqlCeCommand cmd = new SqlCeCommand(StrSQL, Program.cnn);
            cmd.Parameters.Add("@CIN", SqlDbType.NVarChar).Value = fi.CIN;
            cmd.Parameters.Add("@NomPrenom", SqlDbType.NVarChar).Value = fi.NOMPRENOM;
            cmd.Parameters.Add("@Civilite", SqlDbType.NVarChar).Value = fi.CIVILITE;
            cmd.Parameters.Add("@DateNaissance", SqlDbType.NVarChar).Value = fi.DATENAISSANCE;
            cmd.Parameters.Add("@VilleNaissance", SqlDbType.NVarChar).Value = fi.VILLENAISSANCE;
            cmd.Parameters.Add("@PaysOrigine", SqlDbType.NVarChar).Value = fi.PAYSORIGINE;
            cmd.Parameters.Add("@Nationalite", SqlDbType.NVarChar).Value = fi.NATIONALITE;
            cmd.Parameters.Add("@Adresse", SqlDbType.NVarChar).Value = fi.ADRESSE;
            cmd.Parameters.Add("@Ville", SqlDbType.NVarChar).Value = fi.VILLE;
            cmd.Parameters.Add("@CodePostal", SqlDbType.NVarChar).Value = fi.CODEPOSTAL;
            cmd.Parameters.Add("@Gouvernorat", SqlDbType.NVarChar).Value = fi.GOUVERNORAT;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = fi.TELEPHONE;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fi.EMAIL;
            cmd.Parameters.Add("@Profession", SqlDbType.NVarChar).Value = fi.PROFESSION;
            cmd.Parameters.Add("@Employeur", SqlDbType.NVarChar).Value = fi.EMPLOYEUR;
            cmd.Parameters.Add("@Specialite", SqlDbType.NVarChar).Value = fi.SPECIALITE;
            cmd.Parameters.Add("@LaboUniteeRecherche", SqlDbType.NVarChar).Value = fi.LABOUNITEERECHERCHE;
            cmd.Parameters.Add("@LaboUniteeRechercheCotutelle", SqlDbType.NVarChar).Value = fi.LABOUNITEERECHERCHECOTUTELLE;
            cmd.Parameters.Add("@Encadrant", SqlDbType.NVarChar).Value = fi.ENCADRANT;
            cmd.Parameters.Add("@CoEncadrant", SqlDbType.NVarChar).Value = fi.COENCADRANT;
            cmd.Parameters.Add("@Sujet", SqlDbType.NVarChar).Value = fi.SUJET;
            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }

        public static int delete(string Cin)
        {
            string request = "delete from FicheInformation where CIN=@CIN";
            SqlCeCommand cmd = new SqlCeCommand(request,Program.cnn);
            cmd.Parameters.Add("@CIN",SqlDbType.NVarChar).Value=Cin;
            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }

        public static int Update(string CurCin, FicheInformations fi)
        {
            string request = "UPDATE FicheInformation SET CIN=@CIN, Adresse=@Adresse,Civilite=@Civilite,  CodePostal=@CodePostal, CoEncadrant=@CoEncadrant, dateNaissance=@dateNaissance, Ville=@Ville," +
                                "Email=@Email, Employeur=@Employeur, Encadrant=@Encadrant,Gouvernorat=@Gouvernorat,Sujet=@Sujet," +
                                "LaboUniteeRecherche=@LaboUniteeRecherche, LaboUniteeRechercheCotutelle=@LaboUniteeRechercheCotutelle, Specialite=@Specialite," +
                                "Nationalite=@Nationalite, NomPrenom=@NomPrenom,  PaysOrigine=@PaysOrigine, Profession=@Profession, Telephone=@Telephone, VilleNaissance=@VilleNaissance" +
                                " WHERE CIN = @CurCin";
            SqlCeCommand cmd = new SqlCeCommand(request,Program.cnn);
            cmd.Parameters.Add("@CIN", SqlDbType.NVarChar).Value = fi.CIN;
            cmd.Parameters.Add("@NomPrenom", SqlDbType.NVarChar).Value = fi.NOMPRENOM;
            cmd.Parameters.Add("@Civilite", SqlDbType.NVarChar).Value = fi.CIVILITE;
            cmd.Parameters.Add("@DateNaissance", SqlDbType.NVarChar).Value = fi.DATENAISSANCE;
            cmd.Parameters.Add("@VilleNaissance", SqlDbType.NVarChar).Value = fi.VILLENAISSANCE;
            cmd.Parameters.Add("@PaysOrigine", SqlDbType.NVarChar).Value = fi.PAYSORIGINE;
            cmd.Parameters.Add("@Nationalite", SqlDbType.NVarChar).Value = fi.NATIONALITE;
            cmd.Parameters.Add("@Adresse", SqlDbType.NVarChar).Value = fi.ADRESSE;
            cmd.Parameters.Add("@Ville", SqlDbType.NVarChar).Value = fi.VILLE;
            cmd.Parameters.Add("@CodePostal", SqlDbType.NVarChar).Value = fi.CODEPOSTAL;
            cmd.Parameters.Add("@Gouvernorat", SqlDbType.NVarChar).Value = fi.GOUVERNORAT;
            cmd.Parameters.Add("@Telephone", SqlDbType.NVarChar).Value = fi.TELEPHONE;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = fi.EMAIL;
            cmd.Parameters.Add("@Profession", SqlDbType.NVarChar).Value = fi.PROFESSION;
            cmd.Parameters.Add("@Employeur", SqlDbType.NVarChar).Value = fi.EMPLOYEUR;
            cmd.Parameters.Add("@Specialite", SqlDbType.NVarChar).Value = fi.SPECIALITE;
            cmd.Parameters.Add("@LaboUniteeRecherche", SqlDbType.NVarChar).Value = fi.LABOUNITEERECHERCHE;
            cmd.Parameters.Add("@LaboUniteeRechercheCotutelle", SqlDbType.NVarChar).Value = fi.LABOUNITEERECHERCHECOTUTELLE;
            cmd.Parameters.Add("@Encadrant", SqlDbType.NVarChar).Value = fi.ENCADRANT;
            cmd.Parameters.Add("@CoEncadrant", SqlDbType.NVarChar).Value = fi.COENCADRANT;
            cmd.Parameters.Add("@Sujet", SqlDbType.NVarChar).Value = fi.SUJET;
            cmd.Parameters.Add("@CurCin", SqlDbType.NVarChar).Value = CurCin;
            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }

        public static int Update(FicheInformations CurFi, FicheInformations NewFi)
        {
            return Update(CurFi.CIN, NewFi);
        }


        public static ListFicheInformations SelectAll()
        {
            string request = "SELECT * FROM FicheInformation order by NomPrenom ASC";
            SqlCeCommand cmd = new SqlCeCommand(request, Program.cnn);
            DataTable dt = DataBaseAccessUtilities.SelectRequest(cmd);
            if (dt != null && dt.Rows.Count != 0)
                return new ListFicheInformations(dt);
            else
                return null;
        }

        public static ListFicheInformations SelectByCriterium(string FieldName, SqlDbType FieldType, string FieldValue)
        {
            string request = "SELECT * FROM FicheInformation where "+FieldName+" = @"+FieldName;
            SqlCeCommand Command = new SqlCeCommand(request, Program.cnn);
            Command.Parameters.Add("@" + FieldName, FieldType).Value = FieldValue;
            DataTable Table = DataBaseAccessUtilities.SelectRequest(Command);
            if (Table != null && Table.Rows.Count != 0)
                return new ListFicheInformations(Table);
            else
                return null;
        }
    }
}
