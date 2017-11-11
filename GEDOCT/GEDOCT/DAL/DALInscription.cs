using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEDOCT.Entities;
using GEDOCT.MyUtilities.DataAccess;

namespace GEDOCT.DAL
{
    class DALInscription
    {

        public static int Insert(Inscription I)
        {
            string request = "INSERT INTO  Inscription(AnneeUniversitaire,Niveau,Commentaire,Cin) VALUES(@AnneeUniversitaire,@Niveau,@Commentaire,@Cin)";
            SqlCeCommand cmd = new SqlCeCommand(request, Program.cnn);
            cmd.Parameters.Add("@AnneeUniversitaire", SqlDbType.NVarChar).Value = I.ANNEEUNIVERSITAIRE;
            cmd.Parameters.Add("@Niveau", SqlDbType.NVarChar).Value = I.NIVEAU;
            cmd.Parameters.Add("@Commentaire", SqlDbType.NVarChar).Value = I.COMMENTAIRE;
            cmd.Parameters.Add("@Cin", SqlDbType.NVarChar).Value = I.CIN;
            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }

        public static int Delete(string Id)
        {
            string StrSQL = "DELETE FROM Inscription WHERE id = @Id";
            SqlCeCommand cmd = new SqlCeCommand(StrSQL, Program.cnn);
            cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = Id;
            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }

        public static int Update(string Id, Inscription I)
        {
            string StrSQL = "UPDATE Inscription SET AnneeUniversitaire=@AnneeUniversitaire,Niveau=@Niveau, Commentaire=@Commentaire WHERE id = @Id";

            SqlCeCommand Command = new SqlCeCommand(StrSQL, Program.cnn);
            Command.Parameters.Add("@AnneeUniversitaire", SqlDbType.NVarChar).Value = I.ANNEEUNIVERSITAIRE;
            Command.Parameters.Add("@Niveau", SqlDbType.NVarChar).Value = I.NIVEAU;
            Command.Parameters.Add("@Commentaire", SqlDbType.NVarChar).Value = I.COMMENTAIRE;
            Command.Parameters.Add("@Cin", SqlDbType.NVarChar).Value = I.CIN;
            Command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            return DataBaseAccessUtilities.NonQueryRequest(Command);
        }

        public static int Update(Inscription CurIns, Inscription NewIns)
        {
            return Update(CurIns.ID, NewIns);
        }

        public static Inscription SelectById(string Id)
        {
            string StrSQL = "SELECT * FROM Inscription WEHRE Id = @Id";
            SqlCeCommand Command = new SqlCeCommand(StrSQL, Program.cnn);
            Command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = Id;
            DataTable dt = DataBaseAccessUtilities.SelectRequest(Command);
            if (dt != null && dt.Rows.Count != 0)
                return new Inscription(dt.Rows[0]);
            else
                return null;

        }

        public static ListInscription SelectByCriterium(string FieldName, SqlDbType FieldType, string FieldValue)
        {
            string StrSQL = "SELECT * FROM Inscription WEHRE " + FieldName + "= @" + FieldName;
            SqlCeCommand Command = new SqlCeCommand(StrSQL, Program.cnn);
            Command.Parameters.Add("@" + FieldName, FieldType).Value = FieldValue;
            DataTable Table = DataBaseAccessUtilities.SelectRequest(Command);
            if (Table != null && Table.Rows.Count != 0)
                return new ListInscription(Table);
            else
                return null;
        }

        public static ListInscription SelectAll()
        {
            string StrSQL = "SELECT * FROM Inscription ";
            SqlCeCommand Command = new SqlCeCommand(StrSQL, Program.cnn);
            DataTable Table = DataBaseAccessUtilities.SelectRequest(Command);
            if (Table != null && Table.Rows.Count != 0)
                return new ListInscription(Table);
            else
                return null;
        }

        public static ListInscription SelectByCIN(string Cin)
        {
            string StrSQL = "SELECT * FROM Inscription WHERE Cin= @Cin";
            SqlCeCommand Command = new SqlCeCommand(StrSQL, Program.cnn);
            Command.Parameters.Add("@Cin", SqlDbType.NVarChar).Value = Cin;
            DataTable Table = DataBaseAccessUtilities.SelectRequest(Command);
            if (Table != null && Table.Rows.Count != 0)
                return new ListInscription(Table);
            else
                return null;
        }



        public static DataTable SelectInscriptionByCin(string cin)
        {
            string StrSQL = "SELECT AnneeUniversitaire,Niveau FROM Inscription WHERE Cin=@Cin";
            SqlCeCommand Command = new SqlCeCommand(StrSQL, Program.cnn);
            Command.Parameters.Add("@Cin", SqlDbType.NVarChar).Value = cin;
            DataTable Table = DataBaseAccessUtilities.SelectRequest(Command);
            if (Table != null)
                return Table;
            else
                return null;
        }

        public static DataSet SelectInscriptionByCin1(string cin)
        {
            string StrSQL = "SELECT AnneeUniversitaire,Niveau FROM Inscription WHERE Cin='" + cin + "'";
            SqlCeDataAdapter da = new SqlCeDataAdapter(StrSQL, Program.cnn);
            DataSet Table = new DataSet();
            da.Fill(Table, "Inscription");
            if (Table != null)
                return Table;
            else
                return null;
        }



        public static int getInscriptionsNumber(string Cin)
        {
            string request = "SELECT count(*) from Inscription where CIN=@CIN";
            SqlCeCommand cmd = new SqlCeCommand(request, Program.cnn);
            cmd.Parameters.Add("@CIN", SqlDbType.NVarChar).Value = Cin;
            return (int)DataBaseAccessUtilities.ScalarRequest(cmd);

        }
    }
}
