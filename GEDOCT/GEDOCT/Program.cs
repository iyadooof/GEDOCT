using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using GEDOCT.Forms;
namespace GEDOCT
{
    static class Program
    {
        public static SqlCeConnection cnn;
        public static string strCnn;
        public static string PathImage;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            strCnn = @"Data Source=GeDoct.sdf";
            cnn = new SqlCeConnection(strCnn);
            PathImage = @"images\";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FicheInfoDoctorant());
        }
    }
}
