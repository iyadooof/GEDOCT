using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using GEDOCT.MyUtilities.DataAccess;

namespace GEDOCT.MyUtilities
{
    class ComboUtilities
    {

        public static void bindDataToCmbValeur(SqlCeConnection MyConnection, ComboBox Cmb, string ParamTableName, string ParamValueMember, string ParamDisplayMember)
        {
            DataTable dtSource;
            dtSource = DataBaseAccessUtilities.SelectRequest("SELECT * FROM " + ParamTableName, MyConnection);
            if (dtSource != null)
            {
                Cmb.DataSource = dtSource;
                Cmb.ValueMember = ParamValueMember;
                Cmb.DisplayMember = ParamDisplayMember;
                Cmb.SelectedIndex = -1;
            }
        }
    }
}
