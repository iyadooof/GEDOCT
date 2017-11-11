using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEDOCT.Entities;
using GEDOCT.BLL;
using Excel = Microsoft.Office.Interop.Excel;

namespace GEDOCT
{
    class ImportFromExcel
    {
        public static void ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;

            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0;HDR=Yes';"; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    Diplome D;
                    FicheInformations FI;
                    Inscription I;

                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlBook;
                    Excel.Worksheet xlSheet;

                    xlBook = xlApp.Workbooks.Open(fileName);
                    xlApp.Visible = true;
                    xlSheet = xlBook.ActiveSheet;

                    for (int i = 2; i <= xlSheet.UsedRange.Rows.Count; i++)
                    {
                        D = new Diplome();
                        FI = new FicheInformations();
                        I = new Inscription();

                        FI.CIN = readCell(i, "B", xlSheet);
                        FI.NOMPRENOM = readCell(i, "C", xlSheet);
                        FI.CIVILITE = readCell(i, "E", xlSheet);
                        FI.DATENAISSANCE = readCell(i, "D", xlSheet);
                        FI.VILLENAISSANCE = readCell(i, "BB", xlSheet);
                        FI.PAYSORIGINE = readCell(i, "G", xlSheet);
                        FI.NATIONALITE = readCell(i, "F", xlSheet);
                        FI.ADRESSE = readCell(i, "H", xlSheet);
                        FI.VILLE = readCell(i, "J", xlSheet);
                        FI.CODEPOSTAL = readCell(i, "K", xlSheet);
                        FI.GOUVERNORAT = readCell(i, "I", xlSheet);
                        FI.TELEPHONE = readCell(i, "L", xlSheet);
                        FI.EMAIL = readCell(i, "M", xlSheet);
                        FI.PROFESSION = readCell(i, "N", xlSheet);
                        FI.EMPLOYEUR = readCell(i, "O", xlSheet);
                        FI.SPECIALITE = readCell(i, "P", xlSheet);
                        FI.LABOUNITEERECHERCHE = readCell(i, "Q", xlSheet);
                        FI.LABOUNITEERECHERCHECOTUTELLE = readCell(i, "S", xlSheet);
                        FI.ENCADRANT = readCell(i, "T", xlSheet);
                        FI.COENCADRANT = readCell(i, "U", xlSheet);
                        FI.SUJET = readCell(i, "V", xlSheet);

                        BLFicheInformation.AddNew(FI);

                        if (xlSheet.UsedRange.Cells[i, "AG"].Value != null)
                        {
                            D.ANNEE = readCell(i, "AG", xlSheet);
                            D.DIPLOME = readCell(i, "AI", xlSheet);
                            D.SPECIALITE = readCell(i, "AH", xlSheet);
                            D.MENTION = "";
                            D.INSTITUTION = readCell(i, "AJ", xlSheet);
                            D.CIN = readCell(i, "B", xlSheet);

                            BLDiplome.AddNew(D);
                        }

                        if (xlSheet.UsedRange.Cells[i, "AK"].Value != null)
                        {
                            D.ANNEE = readCell(i, "AK", xlSheet);
                            D.DIPLOME = readCell(i, "AM", xlSheet);
                            D.SPECIALITE = readCell(i, "AL", xlSheet);
                            D.MENTION = "";
                            D.INSTITUTION = readCell(i, "AN", xlSheet);
                            D.CIN = readCell(i, "B", xlSheet);

                            BLDiplome.AddNew(D);
                        }

                        if (xlSheet.UsedRange.Cells[i, "AO"].Value != null)
                        {
                            D.ANNEE = readCell(i, "AO", xlSheet);
                            D.DIPLOME = readCell(i, "AQ", xlSheet);
                            D.SPECIALITE = readCell(i, "AP", xlSheet);
                            D.MENTION = "";
                            D.INSTITUTION = readCell(i, "AR", xlSheet);
                            D.CIN = readCell(i, "B", xlSheet);

                            BLDiplome.AddNew(D);
                        }

                        if (xlSheet.UsedRange.Cells[i, "AS"].Value != null)
                        {
                            D.ANNEE = readCell(i, "AS", xlSheet);
                            D.DIPLOME = readCell(i, "AU", xlSheet);
                            D.SPECIALITE = readCell(i, "AT", xlSheet);
                            D.MENTION = "";
                            D.INSTITUTION = readCell(i, "AV", xlSheet);
                            D.CIN = readCell(i, "B", xlSheet);

                            BLDiplome.AddNew(D);
                        }

                        if (xlSheet.UsedRange.Cells[i, "AW"].Value != null)
                        {
                            D.ANNEE = readCell(i, "AW", xlSheet);
                            D.DIPLOME = readCell(i, "AY", xlSheet);
                            D.SPECIALITE = readCell(i, "AX", xlSheet);
                            D.MENTION = "";
                            D.INSTITUTION = readCell(i, "AZ", xlSheet);
                            D.CIN = readCell(i, "B", xlSheet);

                            BLDiplome.AddNew(D);
                        }

                        if (xlSheet.UsedRange.Cells[i, "W"].Value != null)
                        {
                            I.ANNEEUNIVERSITAIRE = readCell(i, "W", xlSheet);
                            I.NIVEAU = readCell(i, "X", xlSheet);
                            I.COMMENTAIRE = "";
                            I.CIN = readCell(i, "B", xlSheet);

                            BLInscription.AddNew(I);
                        }

                        if (xlSheet.UsedRange.Cells[i, "Y"].Value != null)
                        {
                            I.ANNEEUNIVERSITAIRE = readCell(i, "Y", xlSheet);
                            I.NIVEAU = readCell(i, "Z", xlSheet);
                            I.COMMENTAIRE = "";
                            I.CIN = readCell(i, "B", xlSheet);

                            BLInscription.AddNew(I);
                        }

                        if (xlSheet.UsedRange.Cells[i, "AA"].Value != null)
                        {
                            I.ANNEEUNIVERSITAIRE = readCell(i, "AA", xlSheet);
                            I.NIVEAU = readCell(i, "AB", xlSheet);
                            I.COMMENTAIRE = "";
                            I.CIN = readCell(i, "B", xlSheet);

                            BLInscription.AddNew(I);
                        }

                        if (xlSheet.UsedRange.Cells[i, "AC"].Value != null)
                        {
                            I.ANNEEUNIVERSITAIRE = readCell(i, "AC", xlSheet);
                            I.NIVEAU = readCell(i, "AD", xlSheet);
                            I.COMMENTAIRE = "";
                            I.CIN = readCell(i, "B", xlSheet);

                            BLInscription.AddNew(I);
                        }

                        if (xlSheet.UsedRange.Cells[i, "AE"].Value != null)
                        {
                            I.ANNEEUNIVERSITAIRE = readCell(i, "AE", xlSheet);
                            I.NIVEAU = readCell(i, "AF", xlSheet);
                            I.COMMENTAIRE = "";
                            I.CIN = readCell(i, "B", xlSheet);

                            BLInscription.AddNew(I);
                        }
                    }

                    xlBook.Close();
                    xlApp.Quit();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        public static void GetFromExcel()
        {
            string filePath = string.Empty;
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file  
            
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK) //if there is a file choosen by the user  
            {
                filePath = file.FileName; //get the path of the file  
                fileExt = Path.GetExtension(filePath); //get the file extension  
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        ReadExcel(filePath, fileExt); //read excel file  
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error  
                }
            }
        }

        public static string readCell(int row, string colomn, Excel.Worksheet sheet)
        {
            if (sheet.UsedRange.Cells[row, colomn].Value != null)
                return sheet.UsedRange.Cells[row, colomn].Value.ToString();
            else
                return "";
        }
    }
}
