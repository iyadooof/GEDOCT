using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEDOCT.MyUtilities
{
    public struct EmptyCtrlMsg
    {
        public Control Ctrl;
        public PictureBox pictureErrorControl;
        public string ErrorMsg;

        public EmptyCtrlMsg(Control Ctrl, PictureBox pictureErrorControl, string ErrorMsg)
        {
            this.Ctrl = Ctrl;
            this.ErrorMsg = ErrorMsg;
            this.pictureErrorControl = pictureErrorControl;
        }
    }
}
