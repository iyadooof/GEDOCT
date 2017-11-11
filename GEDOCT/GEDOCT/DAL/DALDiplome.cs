using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using GEDOCT.Entities;
using GEDOCT.MyUtilities.DataAccess;
namespace GEDOCT.DAL
{
    class DALDiplome
    {
        public static int Insert(Diplome D)
        {
            string request = "INSERT INTO Diplome(Annee,Diplome,Specialite,Mention,Institution,Cin) VALUES(@Annee,@Diplome,@Specialite,@Mention,@Institution,@Cin)";
            SqlCeCommand cmd = new SqlCeCommand(request,Program.cnn);
            cmd.Parameters.Add("@Annee", SqlDbType.NVarChar).Value = D.ANNEE;
            cmd.Parameters.Add("@Diplome", SqlDbType.NVarChar).Value = D.DIPLOME;
            cmd.Parameters.Add("@Specialite", SqlDbType.NVarChar).Value = D.SPECIALITE;
            cmd.Parameters.Add("@Mention", SqlDbType.NVarChar).Value = D.MENTION;
            cmd.Parameters.Add("@Institution", SqlDbType.NVarChar).Value = D.INSTITUTION;
            cmd.Parameters.Add("@Cin", SqlDbType.NVarChar).Value = D.CIN;
            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }

        public static ListDiplome selectAll()
        {
            string request = "SELECT * FROM Diplome";
            SqlCeCommand cmd = new SqlCeCommand(request,Program.cnn);
            DataTable dt = DataBaseAccessUtilities.SelectRequest(cmd);
            if ((dt != null)&&(dt.Rows.Count!=0))
            {
                return new ListDiplome(dt);
            }
            else
                return null;

        }

        public static int update(string id,Diplome D)
        {
            string request = "update Diplome set Annee=@Annee, Diplome=@Diplome,Specialite=@Specialite, Mention=@Mention, Institution=@Institution where id=@Id";
            SqlCeCommand cmd = new SqlCeCommand(request,Program.cnn);
            cmd.Parameters.Add("@Annee", SqlDbType.NVarChar).Value = D.ANNEE;
            cmd.Parameters.Add("@Diplome", SqlDbType.NVarChar).Value = D.DIPLOME;
            cmd.Parameters.Add("@Specialite", SqlDbType.NVarChar).Value = D.SPECIALITE;
            cmd.Parameters.Add("@Mention", SqlDbType.NVarChar).Value = D.MENTION;
            cmd.Parameters.Add("@Institution", SqlDbType.NVarChar).Value = D.INSTITUTION;
            cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;

            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }

        public static ListDiplome SelectByCIN(string Cin)
        {
            string StrSQL = "SELECT * FROM Diplome WHERE Cin= @Cin";
            SqlCeCommand Command = new SqlCeCommand(StrSQL, Program.cnn);
            Command.Parameters.Add("@Cin", SqlDbType.NVarChar).Value = Cin;
            DataTable Table = DataBaseAccessUtilities.SelectRequest(Command);
            if (Table != null && Table.Rows.Count != 0)
                return new ListDiplome(Table);
            else
                return null;
        }

        public static int Delete(string Id)
        {
            string request = "DELETE FROM Diplome WHERE id=@Id";
            SqlCeCommand cmd = new SqlCeCommand(request , Program.cnn);
            cmd.Parameters.Add("@Id",SqlDbType.NVarChar).Value = Id;
            return DataBaseAccessUtilities.NonQueryRequest(cmd);
        }
    }
}
