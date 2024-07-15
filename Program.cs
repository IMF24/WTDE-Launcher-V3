// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       E N T R Y       P O I N T       F I L E
//
//    The starting file for the V3 launcher's execution. We start here!
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.IO;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  The starting file for the V3 launcher's execution. We start here!
    /// </summary>
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Spawn debug console?
            if (INIFunctions.GetINIValue("Launcher", "Console") == "1") {
                InitializeConsole();
            }

            // Intro stuff in the console!
            Console.WriteLine("~=-=~=-=~      W T D E     L A U N C H E R     V 3      ~=-=~=-=~");
            Console.WriteLine($"  WTDE Launcher Execution Debug Log - WTDE Launcher Version {V3LauncherConstants.VERSION}");
            Console.WriteLine($"  Date of Execution: {DateTime.Now}");
            Console.WriteLine("~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~=-=~");

            Application.Run(new Main());
        }

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
        // DLL IMPORTS FOR CONSOLE STUFF
        // --------------------------------

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        static extern public int AllocConsole();

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        static extern public uint AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto, SetLastError = true)]
        static extern public IntPtr CreateFileW(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

    }
}
