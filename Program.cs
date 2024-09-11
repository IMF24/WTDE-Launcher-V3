// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       E N T R Y       P O I N T       F I L E
//
//    The starting file for the V3 launcher's execution. We start here!
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.IO;
using WTDE_Launcher_V3.NX;

using System;
using System.IO;
using System.Drawing; 
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using System.Drawing.Imaging;
using System.Threading;
using System.Globalization;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  The starting file for the V3 launcher's execution. We start here!
    /// </summary>
    public class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            // Set arguments!
            // Used by the argument parser.
            Args = args;

            // Run the program normally!
            if (Args.Length <= 0) {

                // Whatever this does, just more fun
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // We MUST set culture type to EN-US.
                // This will parse strings and decimals in the correct way.
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

                // Spawn debug console?
                if (INIFunctions.GetINIValue("Launcher", "Console") == "1") {
                    InitializeConsole();
                }
                //~ ShowDebugConsole((INIFunctions.GetINIValue("Launcher", "Console") == "1"));

                // Spawn Discord RPC?
                if (INIFunctions.GetINIValue("Launcher", "RichPresence") == "1") {
                    RPCHandler.InitializeRPC();
                    var newPresence = RPCHandler.MakeRPCStatusFromBasicData(
                        "Getting things ready",
                        $"Version {V3LauncherConstants.VERSION}",
                        "https://raw.githubusercontent.com/IMF24/WTDE-Launcher-V3/master/res/img/icon/icon.png",
                        $"GHWT: Definitive Edition Launcher - V{V3LauncherConstants.VERSION}",
                        //~ "https://raw.githubusercontent.com/IMF24/WTDE-Launcher-V3/master/res/img/icon/instruments.png",
                        "",
                        "Main Editor"
                    );
                    RPCHandler.UpdateRPCStatus(newPresence);
                }

                // Intro stuff in the console!
                Console.WriteLine("~=-=~=-=~      W T D E     L A U N C H E R     V 3      ~=-=~=-=~");
                Console.WriteLine($"  WTDE Launcher Execution Debug Console - WTDE Launcher Version {V3LauncherConstants.VERSION}");
                Console.WriteLine($"  Date of Execution: {DateTime.Now}");
                Console.WriteLine("~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~");
                Console.WriteLine("\nPress CTRL + C in this terminal window at any point to end execution of the launcher.");

                // Print stuff if dev settings are enabled
                if (V3LauncherCore.EnableDeveloperSettings) {
                    Console.WriteLine("\n!!! -- DEVELOPER SETTINGS ENABLED -- !!!\n" +
                                      "You have the developer settings enabled!\n\n" +
                                      "While active, certain aspects of the launcher have been enabled. These various features are usually experimental, and everything about them may or may not work.\n\n" +
                                      "Note: NEVER, EVER share your dev settings file with anyone in the eyes of the public.\n");

                    Console.WriteLine("~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~\n");
                }
            
                Application.Run(new Main());

            // There were command line arguments, parse them out!
            } else {
                ParseArguments();
            }
        }

        /// <summary>
        ///  Arguments passed in from the command line.
        /// </summary>
        public static string[] Args;

        // - - - - - - - - - - - - - - - - - - - - - - -

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        /// <summary>
        ///  Shows the debug console.
        /// </summary>
        /// <param name="show">
        ///  Show or hide the console? True for show, false for hide.
        /// </param>
        static void ShowDebugConsole(bool show) {
            var handle = GetConsoleWindow();
            if (show) ShowWindow(handle, SW_SHOW); else ShowWindow(handle, SW_HIDE);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        // --------------------------------
        // Debug console junk, lovely
        // --------------------------------

        /// <summary>
        ///  Initialize the console!
        /// </summary>
        /// <param name="alwaysCreateNewConsole"></param>
        public static void InitializeConsole(bool alwaysCreateNewConsole = true) {
            bool consoleAttached = true;
            if (alwaysCreateNewConsole || (AttachConsole(4294967295u) == 0u && (long)Marshal.GetLastWin32Error() != 5L)) {
                consoleAttached = (AllocConsole() != 0);
            }
            if (consoleAttached) {
                InitializeOutStream();
                InitializeInStream();
            }
        }

        /// <summary>
        ///  Initialize the output stream!
        /// </summary>
        public static void InitializeOutStream() {
            FileStream fs = CreateFileStream("CONOUT$", 1073741824u, 2u, FileAccess.Write);
            if (fs != null) {
                StreamWriter streamWriter = new StreamWriter(fs);
                streamWriter.AutoFlush = true;
                Console.SetOut(streamWriter);
                Console.SetError(streamWriter);
            }
        }

        /// <summary>
        ///  Initialize the input stream!
        /// </summary>
        public static void InitializeInStream() {
            FileStream fs = CreateFileStream("CONIN$", 2147483648u, 1u, FileAccess.Read);
            if (fs != null) {
                Console.SetIn(new StreamReader(fs));
            }
        }

        /// <summary>
        ///  Make a file stream. What?
        /// </summary>
        /// <param name="name"></param>
        /// <param name="win32DesiredAccess"></param>
        /// <param name="win32ShareMode"></param>
        /// <param name="dotNetFileAccess"></param>
        /// <returns></returns>
        public static FileStream CreateFileStream(string name, uint win32DesiredAccess, uint win32ShareMode, FileAccess dotNetFileAccess) {
            SafeFileHandle file = new SafeFileHandle(CreateFileW(name, win32DesiredAccess, win32ShareMode, IntPtr.Zero, 3u, 128u, IntPtr.Zero), true);
            if (!file.IsInvalid) {
                return new FileStream(file, dotNetFileAccess);
            }
            return null;
        }

        // --------------------------------
        // EXTERN DLL IMPORTS FOR CONSOLE STUFF
        // --------------------------------

        /// <summary>
        ///  Allocate console!
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        static extern public int AllocConsole();

        /// <summary>
        ///  Attach the console!
        /// </summary>
        /// <param name="dwProcessId"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        static extern public uint AttachConsole(uint dwProcessId);

        /// <summary>
        ///  Create file W?
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="dwCreationDisposition"></param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        static extern public IntPtr CreateFileW(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Process command line arguments!
        /// </summary>
        static void ParseArguments() {
            // Are there actually arguments to parse?
            if (Args == null || Args.Length <= 0) return;

            // Let's find out what command we want to run!
            string command = Args[0];
            switch (command) {
                // -- HELP TEXT / DEFAULT
                case "help": default:
                    Console.Write(HelpText);
                    break;

                // -- EXTRACT NEVERSOFT IMAGE
                case "extract_image":
                    try {
                        // Not 3 or 4 Args?
                        if (Args.Length < 2 || Args.Length > 3) {
                            Console.WriteLine("Please specify an input file and an output folder.\n\nUsage: extract_image <in_file> [out_path]");
                        }

                        // Input and output file.
                        string inDir = Args[1];
                        string outDir = (Args.Length == 3) ? Args[2] : ".";
                        string fileName = Path.GetFileNameWithoutExtension(inDir);
                        string outDirFinal = Path.Combine(outDir, fileName);

                        Console.WriteLine($"Input file: {inDir}\nOutput file: {outDirFinal}");

                        // The extracted image!
                        Image outImage = NXImage.ExtractImage(inDir);

                        // Save the image to the disk.
                        outImage.Save(Helpers.ChangeFileExtension(outDirFinal, ".png"), ImageFormat.Png);

                        Console.WriteLine("Image extraction complete!");

                    } catch (Exception exc) {
                        Console.WriteLine($"An error occurred during extraction: {exc.Message}");
                    }

                    break;
            }

            //~ Thread.Sleep(3000);
        }

        /// <summary>
        ///  Help text printed out to the console when the launcher is run through the
        ///  command line and they input the help command or an invalid command.
        /// </summary>
        const string HelpText = "!=!=!=!=! -~-~-~- WTDE LAUNCHER V3 COMMAND LINE TOOL -~-~-~- !=!=!=!=!\n" +
                                      "Usage: .\\GHWT_Definitive_Launcher.exe <command> [<Args>]\n\n" +
                                      "The command line tool for the WTDE launcher V3.\n\n" +
                                      "List of Commands:\n\n" +
                                      "  - extract_image :: Extract a PC formatted Neversoft image.\n" +
                                      "     Usage: extract_image <in_file> [out_path]";
    }
}
