// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S C R I P T       M O D       E D I T O R S
//          S T A R       P O W E R       C O L O R       M O D I F I E R
//
//    Script mod editor dedicated to the StarPowerModifier script mod for
//    changing the appearance of various elements under Star Power.
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
using MadMilkman.Ini;

namespace WTDE_Launcher_V3 {
    public partial class StarPowerModifierManager : Form {
        public StarPowerModifierManager() {
            InitializeComponent();
            ImportColors();
        }

        public void ImportColors() {
            // -- STAR GEM COLOR ------------------------------

            int starRed = int.Parse(INIFunctions.GetINIValue("StarColors", "Star_Red", "0"));
            int starGreen = int.Parse(INIFunctions.GetINIValue("StarColors", "Star_Green", "255"));
            int starBlue = int.Parse(INIFunctions.GetINIValue("StarColors", "Star_Blue", "255"));
            int starAlpha = int.Parse(INIFunctions.GetINIValue("StarColors", "Star_Alpha", "255"));

            starRed = (starRed > 255) ? (int) Math.Round(starRed * (255M / starAlpha)) : starRed;
            starGreen = (starGreen > 255) ? (int) Math.Round(starGreen * (255M / starAlpha)) : starGreen;
            starBlue = (starBlue > 255) ? (int) Math.Round(starBlue * (255M / starAlpha)) : starBlue;

            StarColor.BackColor = Color.FromArgb(255, starRed, starGreen, starBlue);
            StarColorAlpha.Value = starAlpha;

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- KICK/OPEN NOTE STAR GEM COLOR ---------------

            int kickStarRed = int.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Red", "0"));
            int kickStarGreen = int.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Green", "255"));
            int kickStarBlue = int.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Blue", "255"));
            int kickStarAlpha = int.Parse(INIFunctions.GetINIValue("StarColors", "KickStar_Alpha", "255"));

            kickStarRed = (kickStarRed > 255) ? (int) Math.Round(kickStarRed * (255M / kickStarAlpha)) : kickStarRed;
            kickStarGreen = (kickStarGreen > 255) ? (int) Math.Round(kickStarGreen * (255M / kickStarAlpha)) : kickStarGreen;
            kickStarBlue = (kickStarBlue > 255) ? (int) Math.Round(kickStarBlue * (255M / kickStarAlpha)) : kickStarBlue;

            KickStarColor.BackColor = Color.FromArgb(255, kickStarRed, kickStarGreen, kickStarBlue);
            KickStarColorAlpha.Value = kickStarAlpha;

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- NOTE BASE STAR GEM COLOR ---------------

            int baseStarRed = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Red", "255"));
            int baseStarGreen = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Green", "255"));
            int baseStarBlue = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Blue", "255"));
            int baseStarAlpha = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseStar_Alpha", "255"));

            baseStarRed = (baseStarRed > 255) ? (int) Math.Round(baseStarRed * (255M / baseStarAlpha)) : baseStarRed;
            baseStarGreen = (baseStarGreen > 255) ? (int) Math.Round(baseStarGreen * (255M / baseStarAlpha)) : baseStarGreen;
            baseStarBlue = (baseStarBlue > 255) ? (int) Math.Round(baseStarBlue * (255M / baseStarAlpha)) : baseStarBlue;

            BaseStarColor.BackColor = Color.FromArgb(255, baseStarRed, baseStarGreen, baseStarBlue);
            BaseStarColorAlpha.Value = baseStarAlpha;

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- NOTE BASE STAR GEM COLOR ---------------

            int kickBaseStarRed = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Red", "255"));
            int kickBaseStarGreen = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Green", "255"));
            int kickBaseStarBlue = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Blue", "255"));
            int kickBaseStarAlpha = int.Parse(INIFunctions.GetINIValue("StarColors", "BaseKickStar_Alpha", "255"));

            kickBaseStarRed = (kickBaseStarRed > 255) ? (int) Math.Round(kickBaseStarRed * (255M / kickBaseStarAlpha)) : kickBaseStarRed;
            kickBaseStarGreen = (kickBaseStarGreen > 255) ? (int) Math.Round(kickBaseStarGreen * (255M / kickBaseStarAlpha)) : kickBaseStarGreen;
            kickBaseStarBlue = (kickBaseStarBlue > 255) ? (int) Math.Round(kickBaseStarBlue * (255M / kickBaseStarAlpha)) : kickBaseStarBlue;

            BaseKickStarColor.BackColor = Color.FromArgb(255, kickBaseStarRed, kickBaseStarGreen, kickBaseStarBlue);
            BaseKickStarColorAlpha.Value = kickBaseStarAlpha;

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

            int orangeFlameRed = int.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Red", "255"));
            int orangeFlameGreen = int.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Green", "127"));
            int orangeFlameBlue = int.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Blue", "0"));
            int orangeFlameAlpha = int.Parse(INIFunctions.GetINIValue("FlameColors", "Orange_Alpha", "255"));

            orangeFlameRed = (orangeFlameRed > 255) ? (int) Math.Round(orangeFlameRed * (255M / orangeFlameAlpha)) : orangeFlameRed;
            orangeFlameGreen = (orangeFlameGreen > 255) ? (int) Math.Round(orangeFlameGreen * (255M / orangeFlameAlpha)) : orangeFlameGreen;
            orangeFlameBlue = (orangeFlameBlue > 255) ? (int) Math.Round(orangeFlameBlue * (255M / orangeFlameAlpha)) : orangeFlameBlue;

            OrangeColor.BackColor = Color.FromArgb(255, orangeFlameRed, orangeFlameGreen, orangeFlameBlue);
            OrangeColorAlpha.Value = orangeFlameAlpha;

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- BLUE FLAME COLOR ---------------

            int blueFlameRed = int.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Red", "0"));
            int blueFlameGreen = int.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Green", "255"));
            int blueFlameBlue = int.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Blue", "255"));
            int blueFlameAlpha = int.Parse(INIFunctions.GetINIValue("FlameColors", "Blue_Alpha", "255"));

            blueFlameRed = (blueFlameRed > 255) ? (int) Math.Round(blueFlameRed * (255M / blueFlameAlpha)) : blueFlameRed;
            blueFlameGreen = (blueFlameGreen > 255) ? (int) Math.Round(blueFlameGreen * (255M / blueFlameAlpha)) : blueFlameGreen;
            blueFlameBlue = (blueFlameBlue > 255) ? (int) Math.Round(blueFlameBlue * (255M / blueFlameAlpha)) : blueFlameBlue;

            BlueColor.BackColor = Color.FromArgb(255, blueFlameRed, blueFlameGreen, blueFlameBlue);
            BlueColorAlpha.Value = blueFlameAlpha;

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- SP LIGHTNING COLOR ---------------

            int lightningRed = int.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Red", "153"));
            int lightningGreen = int.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Green", "255"));
            int lightningBlue = int.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Blue", "255"));
            int lightningAlpha = int.Parse(INIFunctions.GetINIValue("FlameColors", "Lightning_Alpha", "255"));

            lightningRed = (lightningRed > 255) ? (int) Math.Round(lightningRed * (255M / lightningAlpha)) : lightningRed;
            lightningGreen = (lightningGreen > 255) ? (int) Math.Round(lightningGreen * (255M / lightningAlpha)) : lightningGreen;
            lightningBlue = (lightningBlue > 255) ? (int) Math.Round(lightningBlue * (255M / lightningAlpha)) : lightningBlue;

            LightningColor.BackColor = Color.FromArgb(255, lightningRed, lightningGreen, lightningBlue);
            LightningColorAlpha.Value = lightningAlpha;

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- SP GLOW COLOR ---------------

            int glowRed = int.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Red", "204"));
            int glowGreen = int.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Green", "255"));
            int glowBlue = int.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Blue", "255"));
            int glowAlpha = int.Parse(INIFunctions.GetINIValue("FlameColors", "Glow_Alpha", "255"));

            glowRed = (glowRed > 255) ? (int) Math.Round(glowRed * (255M / glowAlpha)) : glowRed;
            glowGreen = (glowGreen > 255) ? (int) Math.Round(glowGreen * (255M / glowAlpha)) : glowGreen;
            glowBlue = (glowBlue > 255) ? (int) Math.Round(glowBlue * (255M / glowAlpha)) : glowBlue;

            GlowColor.BackColor = Color.FromArgb(255, glowRed, glowGreen, glowBlue);
            GlowColorAlpha.Value = glowAlpha;

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- VOCALS HIGHWAY (NO SP) COLOR ---------------

            int voxNormalRed = int.Parse(INIFunctions.GetINIValue("VocalHighway", "Normal_Red", "0"));
            int voxNormalGreen = int.Parse(INIFunctions.GetINIValue("VocalHighway", "Normal_Green", "0"));
            int voxNormalBlue = int.Parse(INIFunctions.GetINIValue("VocalHighway", "Normal_Blue", "0"));
            int voxNormalAlpha = int.Parse(INIFunctions.GetINIValue("VocalHighway", "Normal_Alpha", "255"));

            NormalColor.BackColor = Color.FromArgb(voxNormalAlpha, voxNormalRed, voxNormalGreen, voxNormalBlue);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            // -- VOCALS HIGHWAY (WITH SP) COLOR ---------------

            int voxStarRed = int.Parse(INIFunctions.GetINIValue("VocalHighway", "StarPower_Red", "0"));
            int voxStarGreen = int.Parse(INIFunctions.GetINIValue("VocalHighway", "StarPower_Green", "64"));
            int voxStarBlue = int.Parse(INIFunctions.GetINIValue("VocalHighway", "StarPower_Blue", "64"));
            int voxStarAlpha = int.Parse(INIFunctions.GetINIValue("VocalHighway", "StarPower_Alpha", "255"));

            StarpowerColor.BackColor = Color.FromArgb(voxStarAlpha, voxStarRed, voxStarGreen, voxStarBlue);
        }

        public void WriteINISettings() {
            INIFunctions.SaveINIValue("StarColors", "Star_Red", Math.Round((StarColor.BackColor.R * (StarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "Star_Green", Math.Round((StarColor.BackColor.G * (StarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "Star_Blue", Math.Round((StarColor.BackColor.B * (StarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "Star_Alpha", StarColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("StarColors", "KickStar_Red", Math.Round((KickStarColor.BackColor.R * (KickStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "KickStar_Green", Math.Round((KickStarColor.BackColor.G * (KickStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "KickStar_Blue", Math.Round((KickStarColor.BackColor.B * (KickStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "KickStar_Alpha", KickStarColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("StarColors", "BaseStar_Red", Math.Round((BaseStarColor.BackColor.R * (BaseStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseStar_Green", Math.Round((BaseStarColor.BackColor.G * (BaseStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseStar_Blue", Math.Round((BaseStarColor.BackColor.B * (BaseStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseStar_Alpha", BaseStarColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Red", Math.Round((BaseKickStarColor.BackColor.R * (BaseKickStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Green", Math.Round((BaseKickStarColor.BackColor.G * (BaseKickStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Blue", Math.Round((BaseKickStarColor.BackColor.B * (BaseKickStarColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("StarColors", "BaseKickStar_Alpha", BaseKickStarColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("HighwaySPTint", "Red", HighwayColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("HighwaySPTint", "Green", HighwayColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("HighwaySPTint", "Blue", HighwayColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("HighwaySPTint", "Alpha", HighwayColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Array", FXArray.Text);

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Orange_Red", Math.Round((OrangeColor.BackColor.R * (OrangeColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Orange_Green", Math.Round((OrangeColor.BackColor.G * (OrangeColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Orange_Blue", Math.Round((OrangeColor.BackColor.B * (OrangeColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Orange_Alpha", OrangeColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Blue_Red", Math.Round((BlueColor.BackColor.R * (BlueColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Blue_Green", Math.Round((BlueColor.BackColor.G * (BlueColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Blue_Blue", Math.Round((BlueColor.BackColor.B * (BlueColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Blue_Alpha", BlueColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Lightning_Red", Math.Round((LightningColor.BackColor.R * (LightningColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Lightning_Green", Math.Round((LightningColor.BackColor.G * (LightningColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Lightning_Blue", Math.Round((LightningColor.BackColor.B * (LightningColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Lightning_Alpha", LightningColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("FlameColors", "Glow_Red", Math.Round((GlowColor.BackColor.R * (GlowColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Glow_Green", Math.Round((GlowColor.BackColor.G * (GlowColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Glow_Blue", Math.Round((GlowColor.BackColor.B * (GlowColorAlpha.Value / 255M))).ToString());
            INIFunctions.SaveINIValue("FlameColors", "Glow_Alpha", GlowColorAlpha.Value.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("VocalHighway", "Normal_Red", NormalColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("VocalHighway", "Normal_Green", NormalColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("VocalHighway", "Normal_Blue", NormalColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("VocalHighway", "Normal_Alpha", NormalColor.BackColor.A.ToString());

            // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

            INIFunctions.SaveINIValue("VocalHighway", "StarPower_Red", StarpowerColor.BackColor.R.ToString());
            INIFunctions.SaveINIValue("VocalHighway", "StarPower_Green", StarpowerColor.BackColor.G.ToString());
            INIFunctions.SaveINIValue("VocalHighway", "StarPower_Blue", StarpowerColor.BackColor.B.ToString());
            INIFunctions.SaveINIValue("VocalHighway", "StarPower_Alpha", StarpowerColor.BackColor.A.ToString());
        }

        /// <summary>
        ///  Resets all the settings to their defaults.
        /// </summary>
        public void ResetToDefault() {
            StarColor.BackColor = Color.FromArgb(255, 0, 255, 255);
            KickStarColor.BackColor = Color.FromArgb(255, 0, 255, 255);
            BaseStarColor.BackColor = Color.FromArgb(255, 255, 255, 255);
            BaseKickStarColor.BackColor = Color.FromArgb(255, 255, 255, 255);

            HighwayColor.BackColor = Color.FromArgb(255, 64, 255, 255);
            FXArray.SelectedIndex = 0;

            OrangeColor.BackColor = Color.FromArgb(255, 255, 127, 0);
            BlueColor.BackColor = Color.FromArgb(255, 0, 255, 255);

            LightningColor.BackColor = Color.FromArgb(255, 153, 255, 255);
            GlowColor.BackColor = Color.FromArgb(255, 204, 255, 255);

            // - - - - - - - - - - - - - - -

            StarColorAlpha.Value = 330;
            KickStarColorAlpha.Value = 255;
            BaseStarColorAlpha.Value = 255;
            BaseKickStarColorAlpha.Value = 255;

            OrangeColorAlpha.Value = 255;
            BlueColorAlpha.Value = 255;

            LightningColorAlpha.Value = 255;
            GlowColorAlpha.Value = 340;

            // - - - - - - - - - - - - - - -

            NormalColor.BackColor = Color.FromArgb(255, 0, 0, 0);
            StarpowerColor.BackColor = Color.FromArgb(255, 0, 64, 64);
        }

        private void OKButton_Click(object sender, EventArgs e) {
            WriteINISettings();
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ResetAllSettingsButton_Click(object sender, EventArgs e) {
            string warnResetMsg = "Are you sure you want to reset your colors to the defaults?";

            if (MessageBox.Show(warnResetMsg, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                ResetToDefault();
            }
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

        private void StarColorDefaultAlpha_Click(object sender, EventArgs e) {
            StarColorAlpha.Value = 255;
        }

        private void KickStarColorDefaultAlpha_Click(object sender, EventArgs e) {
            KickStarColorAlpha.Value = 255;
        }

        private void BaseStarColorDefaultAlpha_Click(object sender, EventArgs e) {
            BaseStarColorAlpha.Value = 255;
        }

        private void BaseKickStarColorDefaultAlpha_Click(object sender, EventArgs e) {
            BaseKickStarColorAlpha.Value = 255;
        }

        private void OrangeColorDefaultAlpha_Click(object sender, EventArgs e) {
            OrangeColorAlpha.Value = 255;
        }

        private void BlueColorDefaultAlpha_Click(object sender, EventArgs e) {
            BlueColorAlpha.Value = 255;
        }

        private void LightningColorDefaultAlpha_Click(object sender, EventArgs e) {
            LightningColorAlpha.Value = 255;
        }

        private void GlowColorDefaultAlpha_Click(object sender, EventArgs e) {
            GlowColorAlpha.Value = 255;
        }

        private void ResetArrayID_Click(object sender, EventArgs e) {
            FXArray.SelectedIndex = 0;
        }

        private void ChangeNormalColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = NormalColor.BackColor;
            cdlg.ShowDialog();

            NormalColor.BackColor = cdlg.Color;
        }

        private void ChangeStarpowerColor_Click(object sender, EventArgs e) {
            ColorDialog cdlg = new ColorDialog();
            cdlg.AllowFullOpen = true;
            cdlg.Color = StarpowerColor.BackColor;
            cdlg.ShowDialog();

            StarpowerColor.BackColor = cdlg.Color;
        }
    }
}
