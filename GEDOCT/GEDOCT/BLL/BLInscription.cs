using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEDOCT.Entities;
using GEDOCT.DAL;
namespace GEDOCT.BLL
{
    class BLInscription
    {

        public static ListInscription GetAll()
        {
            return DALInscription.SelectAll();
        }

        public static int AddNew(Inscription pDip)
        {
            return DALInscription.Insert(pDip);
        }

        public static int Update(string id, Inscription NewDip)
        {
            return DALInscription.Update(id, NewDip);

        }

        public static Inscription GetById(string pId)
        {
            return DALInscription.SelectById(pId);
        }

        public static int Delete(string pId)
        {
            return DALInscription.Delete(pId);
        }

        public static ListInscription GetByCIN(string valeur)
        {
            return DALInscription.SelectByCIN(valeur);
        }

        public static DataTable GetIncriptionByCIN(string valeur)
        {
            return DALInscription.SelectInscriptionByCin(valeur);
        }

        public static int GetInscriptionsNumber(String Cin)
        {
            return DALInscription.getInscriptionsNumber(Cin);
        }
    }
}
