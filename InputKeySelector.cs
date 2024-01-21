// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       K E Y       B I N D       S E L E C T O R
//
//    V3 launcher's on screen keyboard dialog box for selecting a keyboard
//    binding. Adds the binding to the given label.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3 {
    /// <summary>
    ///  V3 launcher's on screen keyboard dialog box for selecting a keyboard
    ///  binding. Adds the binding to the given label.
    /// </summary>
    public partial class InputKeySelector : Form {
        /// <summary>
        ///  The string that will be given back to the Main form when this form is closed.
        /// </summary>
        public string ReturnKey = "";

        /// <summary>
        ///  Output label to assign the text to.
        /// </summary>
        public Label OutputLabel;

        /// <summary>
        ///  V3 launcher's on screen keyboard dialog box for selecting a keyboard
        ///  binding. Adds the binding to the given label.
        /// </summary>
        /// <param name="label"></param>
        public InputKeySelector(Label label = null) {
            InitializeComponent();

            if (label != null) {
                this.OutputLabel = label;
                CurrentInputs.Text = label.Text;
            }
        }     

        private void InputKeySelector_FormClosing(object sender, FormClosingEventArgs e) {
            OutputLabel.Text += $" {ReturnKey}";
            OutputLabel.Text = OutputLabel.Text.Trim();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        /// <summary>
        ///  When a button is clicked, it gives this input back.
        /// </summary>
        /// <param name="key"></param>
        public void GiveKeyBack(string key) {
            ReturnKey = key;
            
            // FOR GUITAR ONLY: Do NOT allow frets and strums to share ANY similar inputs.
            if (CurrentInputs.Text.Contains(key)) {
                MessageBox.Show("You cannot map the same key twice!", "Duplicate Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }

        private void KeyEsc_Click(object sender, EventArgs e) {
            GiveKeyBack("Esc");
        }

        private void KeyF1_Click(object sender, EventArgs e) {
            GiveKeyBack("F1");
        }

        private void KeyF2_Click(object sender, EventArgs e) {
            GiveKeyBack("F2");
        }

        private void KeyF3_Click(object sender, EventArgs e) {
            GiveKeyBack("F3");
        }

        private void KeyF4_Click(object sender, EventArgs e) {
            GiveKeyBack("F4");
        }

        private void KeyF5_Click(object sender, EventArgs e) {
            GiveKeyBack("F5");
        }

        private void KeyF6_Click(object sender, EventArgs e) {
            GiveKeyBack("F6");
        }

        private void KeyF7_Click(object sender, EventArgs e) {
            GiveKeyBack("F7");
        }

        private void KeyF8_Click(object sender, EventArgs e) {
            GiveKeyBack("F8");
        }

        private void KeyF9_Click(object sender, EventArgs e) {
            GiveKeyBack("F9");
        }

        private void KeyF10_Click(object sender, EventArgs e) {
            GiveKeyBack("F10");
        }

        private void KeyF11_Click(object sender, EventArgs e) {
            GiveKeyBack("F11");
        }

        private void KeyF12_Click(object sender, EventArgs e) {
            GiveKeyBack("F12");
        }

        private void KeyGrave_Click(object sender, EventArgs e) {
            GiveKeyBack("~");
        }

        private void KeyNum1_Click(object sender, EventArgs e) {
            GiveKeyBack("1");
        }

        private void KeyNum2_Click(object sender, EventArgs e) {
            GiveKeyBack("2");
        }

        private void KeyNum3_Click(object sender, EventArgs e) {
            GiveKeyBack("3");
        }

        private void KeyNum4_Click(object sender, EventArgs e) {
            GiveKeyBack("4");
        }

        private void KeyNum5_Click(object sender, EventArgs e) {
            GiveKeyBack("5");
        }

        private void KeyNum6_Click(object sender, EventArgs e) {
            GiveKeyBack("6");
        }

        private void KeyNum7_Click(object sender, EventArgs e) {
            GiveKeyBack("7");
        }

        private void KeyNum8_Click(object sender, EventArgs e) {
            GiveKeyBack("8");
        }

        private void KeyNum9_Click(object sender, EventArgs e) {
            GiveKeyBack("9");
        }

        private void KeyNum0_Click(object sender, EventArgs e) {
            GiveKeyBack("0");
        }

        private void KeyRowMinus_Click(object sender, EventArgs e) {
            GiveKeyBack("-");
        }

        private void KeyEquals_Click(object sender, EventArgs e) {
            GiveKeyBack("=");
        }

        private void KeyBackspace_Click(object sender, EventArgs e) {
            GiveKeyBack("BckSpc");
        }

        private void KeyTab_Click(object sender, EventArgs e) {
            GiveKeyBack("Tab");
        }

        private void KeyQ_Click(object sender, EventArgs e) {
            GiveKeyBack("Q");
        }

        private void KeyW_Click(object sender, EventArgs e) {
            GiveKeyBack("W");
        }

        private void KeyE_Click(object sender, EventArgs e) {
            GiveKeyBack("E");
        }

        private void KeyR_Click(object sender, EventArgs e) {
            GiveKeyBack("R");
        }

        private void KeyT_Click(object sender, EventArgs e) {
            GiveKeyBack("T");
        }

        private void KeyY_Click(object sender, EventArgs e) {
            GiveKeyBack("Y");
        }

        private void KeyU_Click(object sender, EventArgs e) {
            GiveKeyBack("U");
        }

        private void KeyI_Click(object sender, EventArgs e) {
            GiveKeyBack("I");
        }

        private void KeyO_Click(object sender, EventArgs e) {
            GiveKeyBack("O");
        }

        private void KeyP_Click(object sender, EventArgs e) {
            GiveKeyBack("P");
        }

        private void KeyLeftBracket_Click(object sender, EventArgs e) {
            GiveKeyBack("[");
        }

        private void KeyRightBracket_Click(object sender, EventArgs e) {
            GiveKeyBack("]");
        }

        private void KeyBackslash_Click(object sender, EventArgs e) {
            GiveKeyBack("\\");
        }

        private void KeyCapsLock_Click(object sender, EventArgs e) {
            GiveKeyBack("Caps");
        }

        private void KeyA_Click(object sender, EventArgs e) {
            GiveKeyBack("A");
        }

        private void KeyS_Click(object sender, EventArgs e) {
            GiveKeyBack("S");
        }

        private void KeyD_Click(object sender, EventArgs e) {
            GiveKeyBack("D");
        }

        private void KeyF_Click(object sender, EventArgs e) {
            GiveKeyBack("F");
        }

        private void KeyG_Click(object sender, EventArgs e) {
            GiveKeyBack("G");
        }

        private void KeyH_Click(object sender, EventArgs e) {
            GiveKeyBack("H");
        }

        private void KeyJ_Click(object sender, EventArgs e) {
            GiveKeyBack("J");
        }

        private void KeyK_Click(object sender, EventArgs e) {
            GiveKeyBack("K");
        }

        private void KeyL_Click(object sender, EventArgs e) {
            GiveKeyBack("L");
        }

        private void KeyColon_Click(object sender, EventArgs e) {
            GiveKeyBack(";");
        }

        private void KeyQuote_Click(object sender, EventArgs e) {
            GiveKeyBack("'");
        }

        private void KeyEnter_Click(object sender, EventArgs e) {
            GiveKeyBack("Enter");
        }

        private void KeyLShift_Click(object sender, EventArgs e) {
            GiveKeyBack("LShift");
        }

        private void KeyLAlt_Click(object sender, EventArgs e) {
            GiveKeyBack("LAlt");
        }

        private void KeySpace_Click(object sender, EventArgs e) {
            GiveKeyBack("Space");
        }

        private void KeyRAlt_Click(object sender, EventArgs e) {
            GiveKeyBack("RAlt");
        }

        private void KeyRCtrl_Click(object sender, EventArgs e) {
            GiveKeyBack("RCtrl");
        }

        private void KeyPrintScreen_Click(object sender, EventArgs e) {
            GiveKeyBack("PrScr");
        }

        private void KeyScrollLock_Click(object sender, EventArgs e) {
            GiveKeyBack("ScrLck");
        }

        private void KeyPauseBreak_Click(object sender, EventArgs e) {
            GiveKeyBack("Pause");
        }

        private void KeyInsert_Click(object sender, EventArgs e) {
            GiveKeyBack("Ins");
        }

        private void KeyHome_Click(object sender, EventArgs e) {
            GiveKeyBack("Home");
        }

        private void KeyPageUp_Click(object sender, EventArgs e) {
            GiveKeyBack("PgUp");
        }

        private void KeyDelete_Click(object sender, EventArgs e) {
            GiveKeyBack("Del");
        }

        private void KeyEnd_Click(object sender, EventArgs e) {
            GiveKeyBack("End");
        }

        private void KeyPageDown_Click(object sender, EventArgs e) {
            GiveKeyBack("PgDn");
        }

        private void KeyUpArrow_Click(object sender, EventArgs e) {
            GiveKeyBack("Up");
        }

        private void KeyDownArrow_Click(object sender, EventArgs e) {
            GiveKeyBack("Down");
        }

        private void KeyLeftArrow_Click(object sender, EventArgs e) {
            GiveKeyBack("Left");
        }

        private void KeyRightArrow_Click(object sender, EventArgs e) {
            GiveKeyBack("Right");
        }

        private void KeyNumLock_Click(object sender, EventArgs e) {
            GiveKeyBack("NumLck");
        }

        private void KeyNumSlash_Click(object sender, EventArgs e) {
            GiveKeyBack("Num/");
        }

        private void KeyNumStar_Click(object sender, EventArgs e) {
            GiveKeyBack("Num*");
        }

        private void KeyNumPadMinus_Click(object sender, EventArgs e) {
            GiveKeyBack("Num-");
        }

        private void KeyNumPad7_Click(object sender, EventArgs e) {
            GiveKeyBack("Num7");
        }

        private void KeyNumPad8_Click(object sender, EventArgs e) {
            GiveKeyBack("Num8");
        }

        private void KeyNumPad9_Click(object sender, EventArgs e) {
            GiveKeyBack("Num9");
        }

        private void KeyNumPad4_Click(object sender, EventArgs e) {
            GiveKeyBack("Num4");
        }

        private void KeyNumPad5_Click(object sender, EventArgs e) {
            GiveKeyBack("Num5");
        }

        private void KeyNumPad6_Click(object sender, EventArgs e) {
            GiveKeyBack("Num6");
        }

        private void KeyNumPadPlus_Click(object sender, EventArgs e) {
            GiveKeyBack("Num+");
        }

        private void KeyNumPad1_Click(object sender, EventArgs e) {
            GiveKeyBack("Num1");
        }

        private void KeyNumPad2_Click(object sender, EventArgs e) {
            GiveKeyBack("Num2");
        }

        private void KeyNumPad3_Click(object sender, EventArgs e) {
            GiveKeyBack("Num3");
        }

        private void KeyNumPad0_Click(object sender, EventArgs e) {
            GiveKeyBack("Num0");
        }

        private void KeyNumPadDot_Click(object sender, EventArgs e) {
            GiveKeyBack("NumDel");
        }

        private void KeyNumPadReturn_Click(object sender, EventArgs e) {
            GiveKeyBack("NumEnt");
        }

        private void KeyLMB_Click(object sender, EventArgs e) {
            GiveKeyBack("LMB");
        }

        private void KeyMMB_Click(object sender, EventArgs e) {
            GiveKeyBack("MMB");
        }

        private void KeyRMB_Click(object sender, EventArgs e) {
            GiveKeyBack("RMB");
        }

        private void KeyZ_Click(object sender, EventArgs e) {
            GiveKeyBack("Z");
        }

        private void KeyX_Click(object sender, EventArgs e) {
            GiveKeyBack("X");
        }

        private void KeyC_Click(object sender, EventArgs e) {
            GiveKeyBack("C");
        }

        private void KeyV_Click(object sender, EventArgs e) {
            GiveKeyBack("V");
        }

        private void KeyB_Click(object sender, EventArgs e) {
            GiveKeyBack("B");
        }

        private void KeyN_Click(object sender, EventArgs e) {
            GiveKeyBack("N");
        }

        private void KeyM_Click(object sender, EventArgs e) {
            GiveKeyBack("M");
        }

        private void KeyComma_Click(object sender, EventArgs e) {
            GiveKeyBack(",");
        }

        private void KeyPeriod_Click(object sender, EventArgs e) {
            GiveKeyBack(".");
        }

        private void KeyQuestion_Click(object sender, EventArgs e) {
            GiveKeyBack("?");
        }

        private void KeyRShift_Click(object sender, EventArgs e) {
            GiveKeyBack("RShift");
        }
    }
}
