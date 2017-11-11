using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GEDOCT.Entities;
using GEDOCT.DAL;
using GEDOCT.MyUtilities;
namespace GEDOCT.BLL
{
    class BLFicheInformation
    {
        public static void AddNew(FicheInformations fi)
        {
            if (DALFicheInformations.checkKeyUnicity(fi.CIN)==false)
            {
                 DALFicheInformations.Insert(fi);
            }
            else
                 throw new MyException("Erreur dans l'ajout d'une fiche ", "Le CIN saisi est déja utilisé", "BLL");
            
        }

        public static int update(FicheInformations CurFi, FicheInformations NewFi)
        {
            if (CurFi.CIN != NewFi.CIN)
            {
                if (DALFicheInformations.checkKeyUnicity(NewFi.CIN) == false)
                {
                    return DALFicheInformations.Update(CurFi, NewFi);
                }
                else
                    throw new MyException("Erreur dans la modification de la Fiche", "Le nouveau CIN saisi est déja utilisé", "BLL");
            }
            else
            {
                return DALFicheInformations.Update(CurFi,NewFi);
            }
        }

        public static int delete(string Cin)
        {
            return DALFicheInformations.delete(Cin);
        }

        public static ListFicheInformations getAll()
        {
            return DALFicheInformations.SelectAll();
        }

        public static ListFicheInformations getByCretrium(string FieldName, SqlDbType FieldType, string FieldValue)
        {
            return DALFicheInformations.SelectByCriterium(FieldName,FieldType, FieldValue);
        }

    }
}
