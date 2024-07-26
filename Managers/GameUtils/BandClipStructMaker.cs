// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       B A N D       C L I P       S T R U C T       M A K E R
//
//    The Mod Manager's band clip struct maker, allowing the user to make a
//    band clip struct that can be utilized in various WTDE song compilers.
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

namespace WTDE_Launcher_V3.Managers.GameUtils {
    /// <summary>
    ///  The Mod Manager's band clip struct maker, allowing the user to make a
    ///  band clip struct that can be utilized in various WTDE song compilers.
    /// </summary>
    public partial class BandClipStructMaker : Form {
        public BandClipStructMaker() {
            InitializeComponent();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  List of band clip structs.
        /// </summary>
        public List<BandClipStruct> Clips;

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void BandClipStructMaker_Load(object sender, EventArgs e) {

        }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - -

    /// <summary>
    ///  Band clip struct model. This is what we use to create a new band clip struct!
    /// </summary>
    public class BandClipStruct {
        /// <summary>
        ///  Construct a new band clip struct.
        /// </summary>
        /// <param name="name">
        ///  Name of the clip struct.
        /// </param>
        public BandClipStruct(string name = "New_Band_Clip_Struct") {
            Name = name;
        }

        /// <summary>
        ///  Name of the clip struct.
        /// </summary>
        public string Name;

        /// <summary>
        ///  List of the clip member structs.
        /// </summary>
        public List<BandClipMember> MemberStructs = new List<BandClipMember>();

        /// <summary>
        ///  List of the moment camera structs.
        /// </summary>
        public List<BandClipCamera> MomentCameras = new List<BandClipCamera>();

        /// <summary>
        ///  Make the clip struct as a string.
        /// </summary>
        /// <returns>
        ///  A QBC formatted band clip struct for use in various song compilers.
        /// </returns>
        public override string ToString() {
            // This is the final string we'll return.
            string finalString = "";

            // First up, create the top part with the struct name.
            finalString += $"{Name} = {{\n\tdataformat = 2\n";

            // How many band member and moment camera structs do we have?
            int bandMembers = MemberStructs.Count;
            int momentCameras = MomentCameras.Count;

            // Member names.
            string[] memberNames = new string[] { 
                "guitarist",
                "bassist",
                "drummer",
                "vocalist"
            };

            // Start node names.
            string[] startNodes = new string[] { 
                "guitarist_start",
                "bassist_start",
                "drummer_start",
                "vocalist_start"
            };

            // IK target types.
            string[] ikTargetTypes = new string[] { "guitar", "slave" };

            // -- BAND MEMBERS
            finalString += "\tcharacters = [\n";
            for (var i = 0; i < bandMembers; i++) {
                BandClipMember member = MemberStructs[i];
                finalString += "\t\t{\n" +
                              $"\t\t\tname = {memberNames[(int) member.Member]}\n" +
                              $"\t\t\tstartnode = \"{startNodes[(int) member.StartNode]}\"\n" +
                              $"\t\t\tanim = {member.Animation}\n" +
                              $"\t\t\tstartframe = {member.StartFrame}\n" +
                              $"\t\t\tendframe = {member.EndFrame}\n" +
                              $"\t\t\ttimefactor = {member.TimeFactor}\n" +
                              $"\t\t\tik_targetl = {ikTargetTypes[(int) member.IKTargetL]}\n" +
                              $"\t\t\tik_targetr = {ikTargetTypes[(int) member.IKTargetR]}\n" +
                              $"\t\t\tstrum = {member.Strum.ToString().ToLower()}\n" +
                              $"\t\t\tfret = {member.Fret.ToString().ToLower()}\n" +
                              $"\t\t\tchord = {member.Chord.ToString().ToLower()}\n" +
                               "\t\t}\n";
            }
            finalString += "\t]\n";

            // -- MOMENT CAMERAS
            finalString += "\tcameras = [\n";
            for (var i = 0; i < momentCameras; i++) {
                BandClipCamera camera = MomentCameras[i];
                finalString += "\t\t{\n" +
                              $"\t\t\tslot = {camera.Slot}\n" +
                              $"\t\t\tname = \"{camera.Name}\"\n" +
                              $"\t\t\tanim = {camera.Animation}\n" +
                               "\t\t}\n";
            }
            finalString += "\t]\n}";

            // The string has been made, awesome! Now give it back!
            return finalString;
        }
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - -

    /// <summary>
    ///  Band clip member. Used in a clip struct for each member!
    /// </summary>
    public class BandClipMember {
        /// <summary>
        ///  Construct a new band clip struct for a band member.
        /// </summary>
        public BandClipMember(
            BandMember member,
            string anim = "default_anim",
            StartNode node = StartNode.Guitarist,
            int startFrame = 0,
            int endFrame = 5000,
            decimal timeFactor = 1.0M,
            InverseKinematicType ikTargetL = InverseKinematicType.Guitar,
            InverseKinematicType ikTargetR = InverseKinematicType.Guitar,
            bool strum = true,
            bool fret = true,
            bool chord = true) {

            Member = member;
            Animation = anim;
            StartNode = node;
            StartFrame = startFrame;
            EndFrame = endFrame;
            TimeFactor = timeFactor;
            IKTargetL = ikTargetL;
            IKTargetR = ikTargetR;
            Strum = strum;
            Fret = fret;
            Chord = chord;
        }

        /// <summary>
        ///  The band member ID.
        /// </summary>
        public BandMember Member;

        /// <summary>
        ///  Name of the animation.
        /// </summary>
        public string Animation;

        /// <summary>
        ///  Start node location.
        /// </summary>
        public StartNode StartNode;

        /// <summary>
        ///  The starting frame of the animation.
        /// </summary>
        public int StartFrame;

        /// <summary>
        ///  The ending frame of the animation.
        /// </summary>
        public int EndFrame;

        /// <summary>
        ///  Speed of the animation. Lower will be slower, higher will be faster.
        /// </summary>
        public decimal TimeFactor;

        /// <summary>
        ///  IK target type for the left hand.
        /// </summary>
        public InverseKinematicType IKTargetL;

        /// <summary>
        ///  IK target type for the right hand.
        /// </summary>
        public InverseKinematicType IKTargetR;

        /// <summary>
        ///  Use strum animations?
        /// </summary>
        public bool Strum;

        /// <summary>
        ///  Use fret animations?
        /// </summary>
        public bool Fret;

        /// <summary>
        ///  Use chord animations?
        /// </summary>
        public bool Chord;
    }
    
    /// <summary>
    ///  Types of band members.
    /// </summary>
    public enum BandMember {
        /// <summary>
        ///  The lead guitarist.
        /// </summary>
        Guitarist = 0,

        /// <summary>
        ///  The bass guitarist.
        /// </summary>
        Bassist = 1,

        /// <summary>
        ///  The drummer.
        /// </summary>
        Drummer = 2,

        /// <summary>
        ///  The vocalist.
        /// </summary>
        Vocalist = 3
    }

    /// <summary>
    ///  The start node of the character.
    /// </summary>
    public enum StartNode {
        /// <summary>
        ///  The guitarist's start position.
        /// </summary>
        Guitarist = 0,

        /// <summary>
        ///  The bassist's start position.
        /// </summary>
        Bassist = 1,

        /// <summary>
        ///  The drummer's start position.
        /// </summary>
        Drummer = 2,

        /// <summary>
        ///  The vocalist's start position.
        /// </summary>
        Vocalist = 3
    }

    /// <summary>
    ///  Type of inverse kinematics that the IK bones on the band member will use.
    /// </summary>
    public enum InverseKinematicType {
        /// <summary>
        ///  For hand animating the guitar hand bones.
        /// </summary>
        Guitar = 0,

        /// <summary>
        ///  For the animation if it's mocapped.
        /// </summary>
        Slave = 1
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - -

    /// <summary>
    ///  Band clip camera. Used in a clip struct for each moment camera that can be called through the "CAMERAS" MIDI track.
    /// </summary>
    public class BandClipCamera {
        /// <summary>
        ///  Construct a new band clip camera struct.
        /// </summary>
        /// <param name="slot">
        ///  The index of the camera.
        /// </param>
        /// <param name="name">
        ///  Band member focus position.
        /// </param>
        /// <param name="anim">
        ///  Animation file name.
        /// </param>
        public BandClipCamera(int slot = 0, string name = CameraStartNode.Guitarist, string anim = "default_cam_anim") {
            Slot = slot;
            Name = name;
            Animation = anim;
        }

        /// <summary>
        ///  The moment camera slot ID.
        /// </summary>
        public int Slot;

        /// <summary>
        ///  The start node location.
        /// </summary>
        public string Name;

        /// <summary>
        ///  The camera animation SKA name.
        /// </summary>
        public string Animation;
    }

    /// <summary>
    ///  Various positions that the camera will be focused on.
    /// </summary>
    abstract public class CameraStartNode {
        /// <summary>
        ///  The camera's focus is the guitarist.
        /// </summary>
        public const string Guitarist = "TRG_Geo_Camera_Performance_GUIT01";

        /// <summary>
        ///  The camera's focus is the bassist.
        /// </summary>
        public const string Bassist = "TRG_Geo_Camera_Performance_BASS01";

        /// <summary>
        ///  The camera's focus is the drummer.
        /// </summary>
        public const string Drummer = "TRG_Geo_Camera_Performance_DRUM01";

        /// <summary>
        ///  The camera's focus is the vocalist.
        /// </summary>
        public const string Vocalist = "TRG_Geo_Camera_Performance_SING01";
    }
}
