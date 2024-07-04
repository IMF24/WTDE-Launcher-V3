
using WTDE_Launcher_V3.Core;

using SharpCompress;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WTDE_Launcher_V3.NX {
    public class PAK {

        // - - - - - - - - - - - - - - - - - - - - - - -
        // ADAPTED FROM GUITAR HERO SDK CODE
        // - - - - - - - - - - - - - - - - - - - - - - -

        private const uint DbgFile = 0x559566CC;
        private const string PlatformExt = "xen";

        private readonly string[] PlatformExtensions = new string[] { "wpc", "ps3", "xen" };
        private readonly string[] Languages = new string[] { "br", "de", "en", "fr", "it", "de", "es", "fr", "it" };

        private const uint FlagCompressed = 0x0100;
        private const uint FlagHasFileName = 0x0020;

        private const uint FTypeLast = 0x2CB3EF3B;
        private const uint FTypeLastTH = 0xB524565F;

        private readonly string[] ExtensionList = new string[] {
            "qb", "sqb", "dbg", "img", "mqb", "tex", "skin", "cam", "col", "fam", "fnc", "fnt", "fnv", "gap",
            "hkc", "imv", "last", "mcol", "mdl", "mdv", "nav", "nqb", "oba", "pfx", "pimg", "png", "rag", "rnb",
            "rnb_lvl", "rnb_mdl", "scn", "scv", "shd", "ska", "ske", "skiv", "stex", "table", "tvx", "wav",
            "empty", "clt", "jam", "note", "nqb", "perf", "pimv", "qs", "qs.br", "qs.de", "qs.en", "qs.es",
            "qs.fr", "qs.it", "raw", "rgn", "trkobj", "xml"
        };

        // - - - - - - - - - - - - - - - - - - - - - - -

        public List<string> ExtensionQBKeys = new List<string>();

        // - - - - - - - - - - - - - - - - - - - - - - -

        public PAK() {
            // Make extension QBKeys!
            foreach (string ext in ExtensionList) {
                //~ var qbk = NXFunctions.MakeQBKeyToNumber($".{ext}").ToString().PadLeft(16, '0');
                //~ this.ExtensionQBKeys[qbk] = ext;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        
    }
}
