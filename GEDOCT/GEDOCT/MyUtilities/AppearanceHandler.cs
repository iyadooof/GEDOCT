using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace GEDOCT.MyUtilities
{
    public static class AppearanceHandler
    {
      
        public static void SetErrorAppearance(List<ErrorCtrlMsg> ErrorCtrls, ToolTip ParamToolTip)
        {
            foreach (ErrorCtrlMsg CtrlMsg in ErrorCtrls)
            {
                CtrlMsg.pictureErrorControl.ImageLocation = @"Resources\No-icon.png";
                ParamToolTip.SetToolTip(CtrlMsg.Ctrl, CtrlMsg.ErrorMsg);
            }
            ParamToolTip.Active = true;
        }

        public static void ResetInitialAppearance(List<ErrorCtrlMsg> ErrorCtrls, ToolTip ParamToolTip)
        {
            if (ErrorCtrls != null)
            {
                foreach (ErrorCtrlMsg CtrlMsg in ErrorCtrls)
                {
                    CtrlMsg.pictureErrorControl.ImageLocation = null;
                }
                ParamToolTip.Active = false;
            }

        }

        public static void ResetInitialAppearance(List<EmptyCtrlMsg> ErrorCtrls, ToolTip ParamToolTip)
        {
            if (ErrorCtrls != null)
            {
                foreach (EmptyCtrlMsg CtrlMsg in ErrorCtrls)
                {
                    CtrlMsg.pictureErrorControl.ImageLocation = null;
                }
                ParamToolTip.Active = false;
            }

        }

        /*************************** Control en mode lecture seulement/non actif ******************************/

        public static void SetReadOnlyAppearance(List<TextBox> ParamControls, bool Mode)
        {
            foreach (TextBox tb in ParamControls)
            {
                SetReadOnlyAppearance(tb,Mode);
            }
        }

        public static void SetEnabledAppearance(List<ComboBox> ParamControls, bool Mode)
        {
            foreach (ComboBox cmb in ParamControls)
            {
                SetEnabledAppearance(cmb,Mode);
            }
        }
        
        public static void SetReadOnlyAppearance(TextBox ParamControl, bool Mode)
        {
            ParamControl.ReadOnly = Mode;
        }

        public static void SetEnabledAppearance(Control ParamControl, bool Mode)
        {
            ParamControl.Enabled = Mode;
        }

        /********************************  Afficher/Cacher les controles *****************************************/

        public static void HideControls(Control ParamControl)
        {
            ParamControl.Visible = false;
        }
        public static void ShowControls(Control ParamControl)
        {
            ParamControl.Visible = true;
        }

        public static void HideControls(Control[] ParamControls)
        {
            foreach (Control Ctrl in ParamControls)
            {
                Ctrl.Visible = false;
            }

        }

        public static void ShowControls(Control[] ParamControls)
        {
            foreach (Control Ctrl in ParamControls)
            {
                Ctrl.Visible = true;
            }
        }
    }
}
