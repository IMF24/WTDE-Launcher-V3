// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       D E V E L O P E R       S E T T I N G S
//
//    This class enables the developer settings dialog box. THIS DIALOG BOX
//    SHOULD ABSOLUTELY NEVER APPEAR IN PUBLIC BUILDS.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    public partial class WTDEDevSettingsDialog : Form {
        public WTDEDevSettingsDialog() {
            InitializeComponent();
            LoadDevSettings();

            this.Text = $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION} - Developer Only Settings";
        }

        public void LoadDevSettings() {
            FixSongSorting.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixSongSorting", "1"));
            FixFXInstanceExists.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFXInstanceExists", "1"));
            FixNoteRangeCheck.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixNoteRangeCheck", "1"));
            FixFSBEncryption.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFSBEncryption", "1"));
            FixFSBHooking.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFSBHooking", "1"));
            FixWhammyCutoff.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixWhammyCutoff", "1"));
            FixPakSizes.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixPakSizes", "1"));
            FixModelBuilderRead.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixModelBuilderRead", "1"));
            FixSkeletonCheck.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixSkeletonCheck", "1"));
            FixPartLimit.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixPartLimit", "1"));
            FixQSFallback.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixQSFallback", "1"));
            FixSectionCheck.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixSectionCheck", "1"));
            FixSTextCopying.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixSTextCopying", "1"));
            FixPakCheck.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixPakCheck", "1"));
            FixCreateFile.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixCreateFile", "1"));
            FixLoadPakEx.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixLoadPakEx", "1"));
            FixAsyncLoaderRead.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixAsyncLoaderRead", "1"));
            FixPakProcessing.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixPakProcessing", "1"));
            FixFlares.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFlares", "1"));
            FixDrawing.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixDrawing", "1"));
            FixRenderOptions.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixRenderOptions", "1"));
            FixMaxGeom.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixMaxGeom", "1"));
            FixNodeListManager.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixNodeListManager", "1"));
            FixToolLights.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixToolLights", "1"));
            FixLightCache.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixLightCache", "1"));

            // ------------------------------------------------

            FixSpotlightUpdate.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixSpotlightUpdate", "1"));
            FixTexImageLogging.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixTexImageLogging", "1"));
            FixFastTextures.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFastTextures", "1"));
            FixVocalNoteTheming.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixVocalNoteTheming", "1"));
            FixSafeTextureReplace.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixSafeTextureReplace", "1"));
            FixFillBurstHack.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixFillBurstHack", "1"));
            FixDOF.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixDOF", "1"));
            FixBloom.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixBloom", "1"));
            FixCamPulse.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixCamPulse", "1"));
            FixMaterialFeatures.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixMaterialFeatures", "1"));
            FixBandHandler.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixBandHandler", "1"));
            FixHandIterators.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixHandIterators", "1"));
            FixStanceBlend.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixStanceBlend", "1"));
            FixDrumKitDifferenceAnims.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixDrumkitDifferenceAnims", "1"));
            FixPlayAnimCheck.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixPlayAnimCheck", "1"));
            FixPlayClip.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixPlayClip", "1"));
            FixCrowdVis.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixCrowdVis", "1"));
            FixVibestringCount.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixVibestringCount", "1"));
            FixDrumLoopSet.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixDrumLoopSet", "1"));
            FixDrumTransitionFallback.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixDrumTransitionFallback", "1"));
            FixSectorIsActive.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixSectorIsActive", "1"));
            FixAudioBuffLen.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixAudioBuffLen", "1"));
            FixAspectRatioLimit.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixAspectRatioLimit", "1"));
            FixQuitCleanup.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixQuitCleanup", "1"));
            FixGuitarInputLogic.Checked = INIFunctions.GetBoolean(INIFunctions.GetINIValue("Debug", "FixGuitarInputLogic", "1"));

            // -- MEMORY POOL SIZES --------------------------------
            CScriptCacheEntry.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CScriptCacheEntry", "24000"));
            CComponent.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CComponent", "1600000"));
            CComponentGroup.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CComponentGroup", "32000"));
            CStruct.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CStruct", "800000"));
            CEventMatch.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CEventMatch", "15000"));
            CVector.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CVector", "18000"));
            CPair.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CPair", "14400"));
            CArray.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CArray", "500000"));
            CScript.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CScript", "6400"));
            CEventKey.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CEventKey", "40000"));
            HashItem.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "HashItem", "40000"));
            CAnimLookup.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "CAnimLookup", "3000"));
            SContextInfo.Value = decimal.Parse(INIFunctions.GetINIValue("Memory", "SContextInfo", "32"));


        }
    }
}
