// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       W T D E       V E R S I O N       H I S T O R Y
//
//    Abstract class that contains a list of string arrays with the information
//    about all previous versions of WTDE as far back as 1.0.3.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDE_Launcher_V3.IO {
    /// <summary>
    ///  Abstract class that contains a list of string arrays with the information
    ///  about all previous versions of WTDE as far back as 1.0.3.
    /// </summary>
    abstract public class WTDEVersionHistory {
        /// <summary>
        ///  List of arrays of strings that have all previous hash list versions of WTDE. Goes as far back as 1.0.3.
        /// </summary>
        public static List<string[]> WTDEVersionInfo = new List<string[]> { 
            // -- 1.3: NOTES UPDATE
            new string[] { "1.3.0.7", "November 15, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/38e9ccc08ff5d754302e8408b16f8a52de496def/GHWTDE/hashlist.dat" },
            new string[] { "1.3.0.6", "November 5, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/a36a19179268c09871f3dc088eb3a2543323e691/GHWTDE/hashlist.dat" },
            new string[] { "1.3.0.5", "October 31, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/1a642be062db87ea113e3f2cd05593088d5670ea/GHWTDE/hashlist.dat" },
            new string[] { "1.3.0.4", "October 15, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/c180dde46aa5abfc56887e56c89bbb48f66f024c/GHWTDE/hashlist.dat" },
            new string[] { "1.3.0.3", "October 9, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/46c9dca94db17a52b38b9a5bfb9eb5b4b0bc5b27/GHWTDE/hashlist.dat" },
            new string[] { "1.3.0.2", "October 8, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/63145df8ad7ce0667a3c2a638d76c9ae627d51f9/GHWTDE/hashlist.dat" },
            new string[] { "1.3.0.1", "October 3, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/b87648cab27aadca3ad26d862ea39782cc2d1f42/GHWTDE/hashlist.dat" },
            new string[] { "1.3.0.0 - notes Update", "October 3, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/730d53d3c578c97151f0d438a33fe36e8b76b269/GHWTDE/hashlist.dat" },
        
            // -- 1.2: BAND HERO 5: PART 1
            new string[] { "1.2.0.6", "August 3, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/4738d995a2cacc95a22a98bb0004aeffb71287fb/GHWTDE/hashlist.dat" },
            new string[] { "1.2.0.5", "August 1, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/19e69d0f22964ee775e1c9f41c1a451d40b48e1b/GHWTDE/hashlist.dat" },
            new string[] { "1.2.0.4", "July 30, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/7aae7822b780c035839acfbdc8c8174941b59f7f/GHWTDE/hashlist.dat" },
            new string[] { "1.2.0.3", "July 27, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/0c2e43e12d3370dcabe256580d236f832f417ef9/GHWTDE/hashlist.dat" },
            new string[] { "1.2.0.2", "July 24, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/ffef912f212333910eb695331c9965e7e0b917ff/GHWTDE/hashlist.dat" },
            new string[] { "1.2.0.1", "July 23, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/c7c50340bba88c9041fae83c275039b5eeb08cd0/GHWTDE/hashlist.dat" },
            new string[] { "1.2.0.0 - Band Hero 5: Part 1", "July 23, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/2dd919237e95d284484194b664427b9afbc621f2/GHWTDE/hashlist.dat" },

            // -- 1.1: VANTALLICA UPDATE
            // -- 1.1.1.X
            new string[] { "1.1.1.5", "June 20, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/c14fbd2a152ae4ff9f06d46efbfef5342d2d9964/GHWTDE/hashlist.dat" },
            new string[] { "1.1.1.4", "June 19, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/aa2911ba58f03b524a321fe0f91e47a1dbd0465f/GHWTDE/hashlist.dat" },
            new string[] { "1.1.1.3", "June 14, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/d8671db2d676a11523eb20f1115cc73226e240e2/GHWTDE/hashlist.dat" },
            new string[] { "1.1.1.2", "June 13, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/c6dbdcacd674dd8d506b67464ae4451821411bed/GHWTDE/hashlist.dat" },
            new string[] { "1.1.1.1", "June 4, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/6b8cb342a870d41ca540ddef914d229ade06c1ee/GHWTDE/hashlist.dat" },
            new string[] { "1.1.1.0", "June 4, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/7b786d03ba88bb9dc85cf142599e4147bc0ffae4/GHWTDE/hashlist.dat" },

            // -- 1.1.0.X
            new string[] { "1.1.0.8", "May 16, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/608b3361aa29fc33c47cb7c3234671c16565901e/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.7", "May 3, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/ff3ddd10c8a62b105f9d42a84e565db391b2910c/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.6", "April 30, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/936585e4f11468db006f9e21c31a33b00ca5729e/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.5", "April 26, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/c8b0296bc18bd1d9ee2e28b6d6e9797154555ebe/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.4", "April 24, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/b04a531cefbc3f7329d955dc6e6ff8b44fdcfb9a/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.3", "April 23, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/7ff3f9c22d89085867b5c0d1c608d4926d5af509/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.2", "April 22, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/2ab4d522df027fd2996e29c789b116afd7913efa/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.1", "April 22, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/ac5ff6a8f90526be595bfeae7f490357fc2bf335/GHWTDE/hashlist.dat" },
            new string[] { "1.1.0.0 - Vantallica Update", "April 20, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/db2b198c5b68e23870430c21528c0fda52639d3e/GHWTDE/hashlist.dat" },

            // -- 1.0.3.X
            new string[] { "1.0.3.12", "January 31, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/2f98e9475b9cd6af3e6097528c1dced5715c2b40/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.11", "January 24, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/b9df5b2387719e24654d031530af78b5236e4351/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.10", "January 17, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/9131f0c3009ea60fad8dfed18771c36bb2e96192/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.9", "January 15, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/e7fc1f4aeeb214e5748bd81b5bc225c73a0a27c8/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.8", "January 1, 2023", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/936ba08ecdd17394bfaae8eb511166f1ef769ac4/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.7", "December 30, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/b37197ff7827f87e228bcb1789741474da5d7c62/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.6", "December 27, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/0c789e1a581f2c25f26fb8bc2f07fd8395e270e4/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.5", "December 22, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/dcff10d8733aaa2f8f45258da96e8bc37feff6a9/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.4", "December 21, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/056e3f0177d93b4503fefa2179f43598e99a0da2/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.3", "December 19, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/7086642a0cc799e9bd83f503261f01c213ba96d2/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.2", "December 1, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/d38543c98528aca1f7f4c9645723a221d5dd76fb/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.1", "November 22, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/5fdd8edc04904a1324be2a36e65a13681ac37319/GHWTDE/hashlist.dat" },
            new string[] { "1.0.3.0", "November 20, 2022", "https://gitgud.io/fretworks/ghwt-de-volatile/-/blob/be9e57a3bafe31be2cdb06ad353a813891371b1f/GHWTDE/hashlist.dat" }
        };
    }
}
