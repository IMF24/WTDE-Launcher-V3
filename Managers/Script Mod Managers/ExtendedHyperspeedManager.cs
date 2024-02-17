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
    public partial class ExtendedHyperspeedManager : Form {
        public ExtendedHyperspeedManager() {
            InitializeComponent();
            ImportSpeeds();
        }

        public void ImportSpeeds() {
            PerSpeedModifier.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "PerSpeedModifier", "20"));

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            SpeedEasyRhythm.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Easy_Rhythm", "0"));
            SpeedEasy.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Easy", "0"));
            SpeedMedium.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Medium", "0"));
            SpeedHard.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Hard", "0"));
            SpeedExpert.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Expert", "0"));

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            SpeedEasyRhythmNeg.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Easy_Rhythm_Neg", "0"));
            SpeedEasyNeg.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Easy_Neg", "0"));
            SpeedMediumNeg.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Medium_Neg", "0"));
            SpeedHardNeg.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Hard_Neg", "0"));
            SpeedExpertNeg.Value = decimal.Parse(INIFunctions.GetINIValue("Hyperspeed", "Speed_Expert_Neg", "0"));

        }

        public void WriteINIValues() {
            INIFunctions.SaveINIValue("Hyperspeed", "PerSpeedModifier", PerSpeedModifier.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Easy_Rhythm", SpeedEasyRhythm.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Easy", SpeedEasy.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Medium", SpeedMedium.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Hard", SpeedHard.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Expert", SpeedExpert.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Easy_Rhythm_Neg", SpeedEasyRhythmNeg.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Easy_Neg", SpeedEasyNeg.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Medium_Neg", SpeedMediumNeg.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Hard_Neg", SpeedHardNeg.Value.ToString());
            INIFunctions.SaveINIValue("Hyperspeed", "Speed_Expert_Neg", SpeedExpertNeg.Value.ToString());
        }

        private void OKButton_Click(object sender, EventArgs e) {
            WriteINIValues();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
