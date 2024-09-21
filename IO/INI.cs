// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       I N I       F I L E       C L A S S
//
//    Helpful class for reading and writing INI files!
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3.IO {
    /// <summary>
    ///  Helpful class for reading and writing INI files!
    /// </summary>
    public class INI {
        /// <summary>
        ///  Construct a new INI file reader/writer object from the given path.
        /// </summary>
        /// <param name="path">
        ///  The source INI file path to read from or write to.
        /// </param>
        public INI(string path, bool verbose = false, bool writeFallback = false) {
            // Store the path for later use.
            FilePath = Helpers.NormalizeSlashes(path);
            IsVerbose = verbose;
            WriteFallback = writeFallback;

            if (IsVerbose) V3LauncherCore.AddDebugEntry("Enabled verbose debug logging with INI file class");

            // Make sure there's something written there!
            if (!File.Exists(path)) {
                if (IsVerbose) V3LauncherCore.AddDebugEntry($"INI file at path {path} did not exist, writing blank text file");
                using (StreamWriter sw = new StreamWriter(path, false)) {
                    sw.Write("");
                }
            }

            // Load the data!
            INIInternalFile = new IniFile();
            INIInternalFile.Load(path);

            if (IsVerbose) V3LauncherCore.AddDebugEntry($"INI file initialized, file is located at {path}");
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Internal INI file used for all reading and writing actions.
        /// </summary>
        private IniFile INIInternalFile;

        /// <summary>
        ///  Path to the INI file that was loaded.
        /// </summary>
        public string FilePath;

        /// <summary>
        ///  Will this INI file class use verbose debug logging?
        /// </summary>
        public bool IsVerbose;

        /// <summary>
        ///  Write the fallback value to the INI if the retrieval fails?
        /// </summary>
        public bool WriteFallback;

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Read any value from an INI file. Parsed as a generic type T; the type will be resolved through the public functions.
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default value if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  The required value, interpreted into various other types by the public methods.
        /// </returns>
        private string ReadValue<T>(string sect, string key, T def) {
            if (IsVerbose) V3LauncherCore.AddDebugEntry($"Amount of sections in INI file: {INIInternalFile.Sections.Count}", "INI Class");

            // Make sure we have sections to count over!
            if (INIInternalFile.Sections.Count > 0) {

                // Loop over our sections!
                foreach (var section in INIInternalFile.Sections) {

                    // We found it!
                    if (section.Name == sect) {

                        if (IsVerbose) V3LauncherCore.AddDebugEntry($"Section {sect} located", "INI Class");

                        // Make sure we have keys to count!
                        if (section.Keys.Count > 0) {

                            // Loop over section keys!
                            foreach (var sectKey in section.Keys) {

                                // We found our key!
                                if (sectKey.Name == key) {

                                    if (IsVerbose) V3LauncherCore.AddDebugEntry($"Key {key} in section {sect} located, value found was {sectKey.Value}", "INI Class");

                                    // Return the value!
                                    return sectKey.Value;
                                }
                            }
                        }
                    }
                }
            }

            // Write the value as a fallback?
            if (WriteFallback) {
                if (IsVerbose) V3LauncherCore.AddDebugEntry($"Must write default to config, writing value {def}", "INI Class");
                WriteValue(sect, key, def.ToString());
            }

            // Not found or file has no INI sections, return default value.
            if (IsVerbose) V3LauncherCore.AddDebugEntry($"Value not found or file has no sections, returning default value of {def}", "INI Class");
            
            // Now give the fallback value back.
            return def.ToString();
        }

        /// <summary>
        ///  Write any value to an INI file. Parsed as a generic type T; the type will be resolved through the public functions.
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The value to write to the given key.
        /// </param>
        private void WriteValue<T>(string sect, string key, T value) {
            // Make sure the section exists!
            if (!INIInternalFile.Sections.Contains(sect)) {
                if (IsVerbose) V3LauncherCore.AddDebugEntry($"Section {sect} not found, adding it", "INI Class");
                INIInternalFile.Sections.Add(sect);
            }

            // Make sure the key exists!
            if (!INIInternalFile.Sections[sect].Keys.Contains(key)) {
                if (IsVerbose) V3LauncherCore.AddDebugEntry($"Key {key} in section {sect} not found, adding it", "INI Class");
                INIInternalFile.Sections[sect].Keys.Add(key);
            }

            // Set the value, write the changes!
            if (IsVerbose) V3LauncherCore.AddDebugEntry($"Writing value {value} to section {sect}, key {key}", "INI Class");
            INIInternalFile.Sections[sect].Keys[key].Value = value.ToString();
            INIInternalFile.Save(FilePath);
        }
        
        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Checks if the INI file has a given section in its list of sections.
        /// </summary>
        /// <param name="sect">
        ///  The section to look for.
        /// </param>
        /// <returns>
        ///  True if the section was found, false if it was not.
        /// </returns>
        public bool HasSection(string sect) {
            return INIInternalFile.Sections.Contains(sect);
        }

        /// <summary>
        ///  Checks if the INI file has a given key in the given section.
        /// </summary>
        /// <param name="sect">
        ///  The section to look for.
        /// </param>
        /// <param name="key">
        ///  The key to look for in the specified section.
        /// </param>
        /// <returns>
        ///  True if the key was found in the section, false if it was not.
        /// </returns>
        public bool HasKey(string sect, string key) {
            return INIInternalFile.Sections.Contains(sect) && INIInternalFile.Sections[sect].Keys.Contains(key);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get a string from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default string if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A string from the given section and key if it exists. The fallback string is returned if the key or section was not found.
        /// </returns>
        public string GetString(string sect, string key, string def = "") {
            return ReadValue(sect, key, def);
        }

        /// <summary>
        ///  Write a string to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The string to write to the given key.
        /// </param>
        public void SetString(string sect, string key, string value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get a boolean from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default boolean if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A true or false value from the given section and key if it exists. The fallback boolean is returned if the key or section was not found.
        /// </returns>
        public bool GetBool(string sect, string key, bool def = false) {
            bool returnValue;
            try {
                double value = double.Parse(ReadValue(sect, key, def));
                returnValue = (value > 0.0D);
            } catch (Exception exc) {
                Console.WriteLine($"Error parsing bool: {exc} // Returning default as {def}");
                returnValue = def;
            }
            return returnValue;
        }

        /// <summary>
        ///  Write a boolean to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The boolean to write to the given key.
        /// </param>
        public void SetBool(string sect, string key, bool value) {
            int writableValue = (value) ? 1 : 0;
            WriteValue(sect, key, writableValue);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get an integer from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default integer if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A 32 bit signed integer from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public int GetInt(string sect, string key, int def = 0) {
            return int.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 32 bit integer to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetInt(string sect, string key, int value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get a long from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default long if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A 64 bit signed integer from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public long GetLong(string sect, string key, long def = 0L) {
            return long.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 64 bit integer to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetLong(string sect, string key, long value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get a short from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default short if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A 16 bit signed integer from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public short GetShort(string sect, string key, short def = 0) {
            return short.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 16 bit integer to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetShort(string sect, string key, short value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get an unsigned integer from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default integer if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A 32 bit unsigned integer from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public uint GetUInt(string sect, string key, uint def = 0U) {
            return uint.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 32 bit unsigned integer to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetUInt(string sect, string key, uint value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get an unsigned long from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default long if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A 64 bit unsigned integer from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public ulong GetULong(string sect, string key, ulong def = 0) {
            return ulong.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 64 bit unsigned integer to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetULong(string sect, string key, ulong value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get an unsigned short from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default short if the given section or key does not exist.
        /// </param>
        /// <returns> 
        ///  A 16 bit unsigned integer from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public ushort GetUShort(string sect, string key, ushort def = 0) {
            return ushort.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 16 bit unsigned integer to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetUShort(string sect, string key, ushort value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get a single precision float value from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default float if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A 32 bit signed floating point number from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public float GetFloat(string sect, string key, float def = 0F) {
            return float.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 32 bit float to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetFloat(string sect, string key, float value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get a double precision float value from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default double if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A 64 bit signed floating point number from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public double GetDouble(string sect, string key, double def = 0) {
            return double.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a 64 bit float to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetDouble(string sect, string key, double value) {
            WriteValue(sect, key, value);
        }

        // - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Get a decimal from the given INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to read from.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to read from.
        /// </param>
        /// <param name="def">
        ///  The default decimal if the given section or key does not exist.
        /// </param>
        /// <returns>
        ///  A decimal number from the given section and key if it exists. The fallback value is returned if the key or section was not found.
        /// </returns>
        public decimal GetDecimal(string sect, string key, decimal def = 0M) {
            return decimal.Parse(ReadValue(sect, key, def));
        }

        /// <summary>
        ///  Write a decimal to the current INI file!
        /// </summary>
        /// <param name="sect">
        ///  The section to write to.
        /// </param>
        /// <param name="key">
        ///  The key in the given section to write to.
        /// </param>
        /// <param name="value">
        ///  The number to write to the given key.
        /// </param>
        public void SetDecimal(string sect, string key, decimal value) {
            WriteValue(sect, key, value);
        }
    }
}
