// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       H E L P E R       M E T H O D S
//          A N D       V A R I A B L E S
//
//    Various functions and variables meant to make writing code easier!
// ----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  Various functions and variables meant to make writing code easier!
    /// </summary>
    public static class Helpers {
        /// <summary>
        ///  Normalize all path slashes!
        /// </summary>
        /// <param name="path">
        ///  Path to normalize slashes for.
        /// </param>
        /// <returns>
        ///  A path string with all slashes turned into forward slashes (/). Regardless of if a path has back slashes (\) or not,
        ///  all slashes in the given path will be turned into forward slashes.
        /// </returns>
        public static string NormalizeSlashes(string path) {
            return (path == null) ? Directory.GetCurrentDirectory() : path.Replace("\\", "/");
        }

        /// <summary>
        ///  Change a file path's extension to a different one!
        /// </summary>
        /// <param name="path">
        ///  The original file path to be changed.
        /// </param>
        /// <param name="extension">
        ///  The new extension for the file.
        /// </param>
        /// <returns>
        ///  A new path string that is the exact same path, but with the file extension changed.
        /// </returns>
        public static string ChangeFileExtension(string path, string extension) {

            if (path == null || extension == null) return path;

            string fileName = Path.GetFileNameWithoutExtension(path);
            if (fileName == null) return path;

            string fullOldPath = Path.GetDirectoryName(path);

            string newFileName = fileName + extension;
            string outPath = Path.Combine(fullOldPath, newFileName);

            return outPath ?? path;
        }

        /// <summary>
        ///  Copy an entire directory and its contents!
        /// </summary>
        /// <param name="sourceDir">
        ///  The source directory.
        /// </param>
        /// <param name="destinationDir">
        ///  The destination directory.
        /// </param>
        /// <param name="recursive">
        ///  Recursively copy?
        /// </param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive) {
            // CREDIT: Microsoft, .NET Documentation

            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles()) {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive) {
                foreach (DirectoryInfo subDir in dirs) {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        /// <summary>
        ///  Return the MD5 hash of a hile.
        /// </summary>
        /// <param name="file">
        ///  The file to get the hash of.
        /// </param>
        /// <returns>
        ///  The MD5 message-digest algorithm hash for the given file path.
        /// </returns>
        public static string GetMD5Hash(string file) {
            if (File.Exists(file)) {
                using (var md5 = MD5.Create()) {
                    using (var fl = File.OpenRead(file)) {
                        var hash = md5.ComputeHash(fl);
                        return BitConverter.ToString(hash).Replace("-", "").ToUpperInvariant();
                    }
                }
            } else {
                return "00000000000000000000000000000000";
            }
        }

        /// <summary>
        ///  Return the name of the last folder only in a path.
        /// </summary>
        /// <param name="path">
        ///  The path string.
        /// </param>
        /// <returns>
        ///  The original path string, but stripped away down to its last folder's name.
        /// </returns>
        public static string LastFolderNameOnly(string path) {
            return NormalizeSlashes(path).Split('/').Last().Replace("/", "").Trim();
        }

        /// <summary>
        ///  Dump the contents of a collection.
        /// </summary>
        /// <param name="list">
        ///  The enumerable object.
        /// </param>
        /// <returns>
        ///  String with all the contents in the provided <see cref="IEnumerable{T}"/>.
        /// </returns>
        public static string DumpListContents<T>(IEnumerable<T> list, bool print = true) {
            string finalString = $"Items in given {list.GetType().Name}: [";
            List<T> iterableList = list.ToList();
            for (var i = 0; i < iterableList.Count; i++) {
                T item = iterableList[i];
                if (i == iterableList.Count - 1) {
                    finalString += $"{item}";
                } else {
                    finalString += $"{item}, ";
                }
            }
            finalString += "]";
            if (print) Console.WriteLine(finalString);
            return finalString;
        }

        /// <summary>
        ///  Gets the indices of a certain filter in a collection of strings.
        /// </summary>
        /// <param name="values">
        ///  The collection of strings.
        /// </param>
        /// <param name="item">
        ///  The filter you want to find all occurrences of.
        /// </param>
        /// <returns>
        ///  An array of integer values that contains all of the indices where the filtered string was found.
        /// </returns>
        public static int[] GetStringListMatchIndices(IEnumerable<string> values, string filter) {
            // The final index locations!
            List<int> finalIndices = new List<int>();

            // Turn the input items into a List.
            List<string> actualStrings = values.ToList();

            // Scan the list by the filter!
            for (var i = 0; i < actualStrings.Count; i++) {
                // We'll do it case INsensitively. 
                if (actualStrings[i].ToLower() == filter.ToLower() ||
                    actualStrings[i].ToLower().Contains(filter.ToLower())) { 
                    finalIndices.Add(i);

                // No filter defined? If so, just add the index!
                } else if (filter.Trim() == "") {
                    finalIndices.Add(i);
                }
            }

            // Return the final indices as an array of integers!
            return finalIndices.ToArray();
        }

        /// <summary>
        ///  Types of band members. Can be used by anything!
        /// </summary>
        public enum BandMembers { 
            /// <summary>
            ///  No particular band member.
            /// </summary>
            None = -1,
            /// <summary>
            ///  Lead guitarist.
            /// </summary>
            Guitarist = 0,
            /// <summary>
            ///  Bass guitarist.
            /// </summary>
            Bassist = 1,
            /// <summary>
            ///  The drummer.
            /// </summary>
            Drummer = 2,
            /// <summary>
            ///  The vocalist.
            /// </summary>
            Vocalist = 3,
            /// <summary>
            ///  Male vocalist.
            /// </summary>
            MaleVocalist = 3,
            /// <summary>
            ///  Female vocalist.
            /// </summary>
            FemaleVocalist = 3,
            /// <summary>
            ///  The entire band.
            /// </summary>
            Band = 4
        }
    }
}
