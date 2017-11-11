using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEDOCT.MyUtilities.DataAccess
{
    static class DataBaseAccessUtilities
    {
        public static int NonQueryRequest(SqlCeCommand cmd)
        {
            try
            {
                try
                {
                    cmd.Connection.Open();
                }
                catch (SqlCeException e)
                {
                    throw new MyException(e, "DataBase Error", "Erreur de connexion à la base", "DAL");
                }

                return cmd.ExecuteNonQuery();
            }
            catch (SqlCeException e)
            {
                  throw new MyException(e, "DataBase Error", e.Message, "DAL");
            }
            finally
            {
                cmd.Connection.Close();
            }

        }

        public static DataTable SelectRequest(SqlCeCommand MyCommand)
        {
            try
            {
                DataTable Table;
                SqlCeDataAdapter SelectAdapter = new SqlCeDataAdapter(MyCommand);
                Table = new DataTable();
                SelectAdapter.Fill(Table);
                return Table;
            }
            catch (SqlCeException e)
            {
                //throw new MyException(e, "DataBase Error", "Erreur d'éxecution de la requête de sélection : \n", "DAL");
                throw new MyException(e, "DataBase Errors", e.Message, "DAL");

            }
            finally
            {
                MyCommand.Connection.Close();
            }
        }

        public static DataTable SelectRequest(string StrSelectRequest, SqlCeConnection MyConnection)
        {
            try
            {
                DataTable Table;
                SqlCeCommand SelectCommand = new SqlCeCommand(StrSelectRequest, MyConnection);
                SqlCeDataAdapter SelectAdapter = new SqlCeDataAdapter(SelectCommand);
                Table = new DataTable();
                SelectAdapter.Fill(Table);
                return Table;
            }
            catch (SqlCeException e)
            {

                throw new MyException(e, "DataBase Error", "Erreur d'éxecution de la requête de sélection : \n", "DAL");

            }
            finally
            {
                MyConnection.Close();
            }
        }


        public static object ScalarRequest(SqlCeCommand MyCommand)
        {
            try
            {
                try
                {
                    MyCommand.Connection.Open();
                }
                catch (SqlCeException e)
                {
                    throw new MyException(e, "DataBase Error", "Erreur de connexion à la base", "DAL");
                }

                return MyCommand.ExecuteScalar();
            }
            catch (SqlCeException e)
            {
                throw new MyException(e, "DataBase Error", "Erreur d'éxecution de la requête : \n", "DAL");
            }
            finally
            {
                MyCommand.Connection.Close();
            }
        }

        static public DataSet select()
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            try
            {
                string StrSQL = "SELECT f.Cin, f.NomPrenom, f.DateNaissance, f.VilleNaissance, i.Niveau, d.Diplome, f.Specialite, i.id, i.AnneeUniversitaire "
                              + "FROM FicheInformation f, Diplome d, Inscription i "
                              + "WHERE f.Cin = d.Cin AND f.Cin = i.Cin AND ( i.AnneeUniversitaire = '" + (date.Year-1).ToString() + "/" + date.Year.ToString() + "' OR i.AnneeUniversitaire = '" + date.Year.ToString() + "/" + (date.Year+1).ToString() + "' )";
                SqlCeDataAdapter Da = new SqlCeDataAdapter(StrSQL, Program.cnn);
                DataSet Ds = new DataSet();
                Da.Fill(Ds);
                return Ds;
            }
            catch
            {
                return null;
            }
        }
    }
}
