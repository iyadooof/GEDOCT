using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace GEDOCT.Forms
{
    public partial class FormClosing : Form
    {
        string Message;
        string useMode;
        FormClosingEventArgs e=null;
        public bool exit=false;

        public FormClosing(string Location, string Message, string useMode, FormClosingEventArgs e)
        {
            InitializeComponent();
            this.Message = Message;
            this.pbMsg.ImageLocation = Location;
            this.useMode = useMode;
            this.e = e;
        }

        public FormClosing(string Location, string Message, string useMode)
        {
            InitializeComponent();
            this.Message = Message;
            this.pbMsg.ImageLocation = Location;
            this.useMode = useMode;
        }

        private void FormClosing_Load(object sender, EventArgs e)
        {
            if (this.useMode != "Consulter")
            {
                chbSHow.Visible = false;
                chbSHow.Enabled = false;
            }
            else
            {
                chbSHow.Visible = true;
                chbSHow.Enabled = true;
            }
            this.lblMessage.Text = Message;
        }

        private void btnOui_Click(object sender, EventArgs e)
        {
            if (this.e == null)
            {
                this.exit = true;
            }

            if (this.useMode == "Consulter")
            {
                if (chbSHow.CheckState == CheckState.Checked)
                {
                    StreamWriter sw = new StreamWriter("chechBoxState.txt");
                    sw.Write("checked", Encoding.UTF8);
                    sw.Close();
                }
            }
            this.Dispose();        
        }

        private void btnNon_Click(object sender, EventArgs e)
        {
            if (this.e != null)
            {
                this.e.Cancel = true;
            }
            
            this.Dispose();

        }

       
    }
}
