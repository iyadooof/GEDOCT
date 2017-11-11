using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace GEDOCT.MyUtilities
{

    public struct ErrorCtrlMsg
    {
        public Control Ctrl;
        public PictureBox pictureErrorControl;
        public string ErrorMsg;

        public ErrorCtrlMsg(Control Ctrl ,PictureBox pictureErrorControl, string ErrorMsg)
        {
            this.Ctrl = Ctrl;
            this.ErrorMsg = ErrorMsg;
            this.pictureErrorControl = pictureErrorControl;
        }
    }
}
