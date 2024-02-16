using MadMilkman.Ini;
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
    public partial class StarPowerModifierManager : Form {
        public StarPowerModifierManager() {
            InitializeComponent();
            ImportColors();
        }

        public void ImportColors() {
            // -- STAR GEM COLOR ------------------------------

            byte starRed = byte.Parse(INIFunctions.GetINIValue("StarColors", "Star_Red", "0"));
            byte starGreen = byte.Parse(INIFunctions.GetINIValue("StarColors", "Star_Green", "255"));
            byte starBlue = byte.Parse(INIFunctions.GetINIValue("StarColors", "Star_Blue", "255"));
            byte starAlpha = byte.Parse(INIFunctions.GetINIValue("StarColors", "Star_Alpha", "255"));

            StarColor.BackColor = Color.FromArgb(starAlpha, starRed, starGreen, starBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- KICK/OPEN NOTE STAR GEM COLOR ---------------

            byte kickStarRed = byte.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Red", "0"));
            byte kickStarGreen = byte.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Green", "255"));
            byte kickStarBlue = byte.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Blue", "255"));
            byte kickStarAlpha = byte.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Alpha", "255"));

            KickStarColor.BackColor = Color.FromArgb(kickStarAlpha, kickStarRed, kickStarGreen, kickStarBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- NOTE BASE STAR GEM COLOR ---------------

            byte baseStarRed = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Red", "255"));
            byte baseStarGreen = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Green", "255"));
            byte baseStarBlue = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Blue", "255"));
            byte baseStarAlpha = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Alpha", "255"));

            BaseStarColor.BackColor = Color.FromArgb(baseStarAlpha, baseStarRed, baseStarGreen, baseStarBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- NOTE BASE STAR GEM COLOR ---------------

            byte kickBaseStarRed = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Red", "255"));
            byte kickBaseStarGreen = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Green", "255"));
            byte kickBaseStarBlue = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Blue", "255"));
            byte kickBaseStarAlpha = byte.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Alpha", "255"));

            BaseKickStarColor.BackColor = Color.FromArgb(kickBaseStarAlpha, kickBaseStarRed, kickBaseStarGreen, kickBaseStarBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- HIGHWAY SP TINT COLOR ---------------

            byte hwyTintRed = byte.Parse(INIFunctions.GetINIValue("HighwaySPTint", "Red", "64"));
            byte hwyTintGreen = byte.Parse(INIFunctions.GetINIValue("HighwaySPTint", "Green", "255"));
            byte hwyTintBlue = byte.Parse(INIFunctions.GetINIValue("HighwaySPTint", "Blue", "255"));
            byte hwyTintAlpha = byte.Parse(INIFunctions.GetINIValue("HighwaySPTint", "Alpha", "255"));

            HighwayColor.BackColor = Color.FromArgb(hwyTintAlpha, hwyTintRed, hwyTintGreen, hwyTintBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            FXArray.Text = INIFunctions.GetINIValue("FlameColors", "Array", "standard_fx");

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- ORANGE FLAME COLOR ---------------

            byte orangeFlameRed = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Red", "255"));
            byte orangeFlameGreen = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Green", "127"));
            byte orangeFlameBlue = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Blue", "0"));
            byte orangeFlameAlpha = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Alpha", "255"));

            OrangeColor.BackColor = Color.FromArgb(orangeFlameAlpha, orangeFlameRed, orangeFlameGreen, orangeFlameBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- BLUE FLAME COLOR ---------------

            byte blueFlameRed = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Red", "0"));
            byte blueFlameGreen = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Green", "255"));
            byte blueFlameBlue = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Blue", "255"));
            byte blueFlameAlpha = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Alpha", "255"));

            BlueColor.BackColor = Color.FromArgb(blueFlameAlpha, blueFlameRed, blueFlameGreen, blueFlameBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- SP LIGHTNING COLOR ---------------

            byte lightningRed = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Red", "153"));
            byte lightningGreen = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Green", "255"));
            byte lightningBlue = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Blue", "255"));
            byte lightningAlpha = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Alpha", "255"));

            LightningColor.BackColor = Color.FromArgb(lightningAlpha, lightningRed, lightningGreen, lightningBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- SP GLOW COLOR ---------------

            byte glowRed = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Red", "204"));
            byte glowGreen = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Green", "255"));
            byte glowBlue = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Blue", "255"));
            byte glowAlpha = byte.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Alpha", "255"));

            GlowColor.BackColor = Color.FromArgb(glowAlpha, glowRed, glowGreen, glowBlue);
        }

        public void WriteINISettings() {
            INIFunctions.SaveINIValue("StarColors", "Star_Red", StarColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("StarColors", "Star_Green", StarColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("StarColors", "Star_Blue", StarColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("StarColors", "Star_Alpha", StarColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("StarColors", "KickStar_Red", KickStarColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("StarColors", "KickStar_Green", KickStarColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("StarColors", "KickStar_Blue", KickStarColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("StarColors", "KickStar_Alpha", KickStarColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("StarColors", "BaseStar_Red", BaseStarColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseStar_Green", BaseStarColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseStar_Blue", BaseStarColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseStar_Alpha", BaseStarColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Red", BaseKickStarColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Green", BaseKickStarColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Blue", BaseKickStarColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Alpha", BaseKickStarColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("HighwaySPTint", "Red", HighwayColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("HighwaySPTint", "Green", HighwayColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("HighwaySPTint", "Blue", HighwayColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("HighwaySPTint", "Alpha", HighwayColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Array", FXArray.Text);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Orange_Red", OrangeColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Orange_Green", OrangeColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Orange_Blue", OrangeColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Orange_Alpha", OrangeColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Blue_Red", BlueColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Blue_Green", BlueColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Blue_Blue", BlueColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Blue_Alpha", BlueColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Lightning_Red", LightningColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Lightning_Green", LightningColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Lightning_Blue", LightningColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Lightning_Alpha", LightningColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Glow_Red", GlowColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Glow_Green", GlowColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Glow_Blue", GlowColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("FlameColors", "Glow_Alpha", GlowColor.BackColor.A.ToString());
        }
        private void OKButton_Click(object sender, EventArgs e) {
            WriteINISettings();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ChangeStarColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = StarColor.BackColor;
            cdlg.ShowDialog();

            StarColor.BackColor = cdlg.Color;
        }


        private void ChangeKickStarColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = KickStarColor.BackColor;
            cdlg.ShowDialog();

            KickStarColor.BackColor = cdlg.Color;
        }

        private void ChangeBaseStarColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = BaseStarColor.BackColor;
            cdlg.ShowDialog();

            BaseStarColor.BackColor = cdlg.Color;
        }

        private void ChangeBaseKickStarColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = BaseKickStarColor.BackColor;
            cdlg.ShowDialog();

            BaseKickStarColor.BackColor = cdlg.Color;
        }

        private void ChangeHighwayTintColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = HighwayColor.BackColor;
            cdlg.ShowDialog();

            HighwayColor.BackColor = cdlg.Color;
        }

        private void ChangeOrangeFlameColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = OrangeColor.BackColor;
            cdlg.ShowDialog();

            OrangeColor.BackColor = cdlg.Color;
        }

        private void ChangeBlueFlameColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = BlueColor.BackColor;
            cdlg.ShowDialog();

            BlueColor.BackColor = cdlg.Color;
        }

        private void ChangeLightningColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = LightningColor.BackColor;
            cdlg.ShowDialog();

            LightningColor.BackColor = cdlg.Color;
        }

        private void ChangeGlowColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = GlowColor.BackColor;
            cdlg.ShowDialog();

            GlowColor.BackColor = cdlg.Color;
        }
    }
}
