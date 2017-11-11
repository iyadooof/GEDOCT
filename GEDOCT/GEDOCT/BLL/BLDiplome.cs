using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GEDOCT.Entities;
using GEDOCT.DAL;

namespace GEDOCT.BLL
{
    class BLDiplome
    {
        public static ListDiplome GetAll()
        {
            return DALDiplome.selectAll();
        }

        public static int AddNew(Diplome D)
        {
            return DALDiplome.Insert(D);
        }


        public static int Update(string id, Diplome D)
        {
            return DALDiplome.update(id, D);

        }

        public static int Delete(string Id)
        {
            return DALDiplome.Delete(Id);
        }

        public static ListDiplome GetByCIN(string Cin)
        {
            return DALDiplome.SelectByCIN(Cin);
        }

      
    }
}
