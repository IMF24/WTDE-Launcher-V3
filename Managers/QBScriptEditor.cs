using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.Odbc;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace WTDE_Launcher_V3.Managers {
    public partial class QBScriptEditor : Form {
        public QBScriptEditor() {
            InitializeComponent();

            //~ MakeNewScript();
            // Make sure that the QB script editor area has a HUGE limit!
            QBScriptNameTextBox.MaxLength = int.MaxValue;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  List of string arrays of script contents.
        /// </summary>
        public List<string> ScriptContents = new List<string>();

        /// <summary>
        ///  List of script names.
        /// </summary>
        public List<string> ScriptNames = new List<string>();

        /// <summary>
        ///  List of script extensions. Determines if it should compile as ROQ or QBC.
        /// </summary>
        public List<string> ScriptExtensions = new List<string>();

        /// <summary>
        ///  Index of the active QB file in the editor.
        /// </summary>
        public int QBFileIndex = 0;

        /// <summary>
        ///  The path to the Guitar Hero SDK.
        /// </summary>
        public string SDKPath = INIFunctions.GetINIValue("Launcher", "SDKPath", ".");

        /// <summary>
        ///  Is the current script in the editor being changed?
        /// </summary>
        public bool ScriptBeingChanged = false;

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Sets up the color syntax highlighting for the QB scripts based on ROQ and QBC syntax!
        /// </summary>
        /// <param name="syntax">
        ///  The syntax highlighting to create.
        /// </param>
        /// <param name="sender">
        ///  Object sender for this method. It is ASSUMED that this is a RichTextBox control.
        /// </param>
        public void SetSyntaxColoring(QBFileSyntax syntax, object sender) {

            string inText = (sender as RichTextBox).Text;
            RichTextBox fctb = (sender as RichTextBox);

            // Now we want to do some highlighting!
            // We'll use regular expressions to determine our highlighting.
            // This will be a little bit difficult to understand, but it
            // hopefully won't be too bad!

            switch (syntax) {
                // ROQ syntax. We will assume this is default.
                case QBFileSyntax.ROQ:
                default:

                    // -------------------------
                    // HEADER STUFF HIGHLIGHTING
                    // -------------------------
                    string roqHeaders = "\\[GHWT_HEADER\\]";
                    MatchCollection roqHeaderMatches = Regex.Matches(inText, roqHeaders);

                    // -------------------------
                    // KEYWORDS HIGHLIGHTING
                    // -------------------------
                    string roqKeywords = @"\b(if|elseif|else|endif|switch|case|default|end_switch|endcase|while|loop_to|continue|return|thaw_4f|thaw_5f|endfunction|Script|Unknown)\b";
                    MatchCollection roqKeywordMatches = Regex.Matches(inText, roqKeywords);

                    // -------------------------
                    // LOGIC AND OPERATORS HIGHLIGHTING
                    // -------------------------
                    string roqOperators = "\b(AND|OR|NOT|\\=|\\+|\\-|\\*|\\/|\\<|\\>|\\<\\=|\\>\\=|\\!\\=|\\!\\=\\=)\b";
                    MatchCollection roqOperatorMatches = Regex.Matches(inText, roqOperators);

                    // -------------------------
                    // COMMENT HIGHLIGHTING
                    //  (Inline and multi-line)
                    // -------------------------
                    string roqComments = @"(\/\/.+?$|\/\*.+?\*\/)";
                    MatchCollection roqCommentMatches = Regex.Matches(inText, roqComments, RegexOptions.Multiline);

                    // -------------------------
                    // STRING HIGHLIGHTING
                    // -------------------------
                    string roqStrings = "%s\\(\"(?:[^\\\\\"]|\\\\\\\\|\\\\\")*\"\\)";
                    MatchCollection roqStringMatches = Regex.Matches(inText, roqStrings);

                    // -------------------------
                    // INTEGER HIGHLIGHTING
                    // -------------------------
                    string roqIntegers = "(%i\\([0-9]+\\)|[0-9]+)";
                    MatchCollection roqIntegerMatches = Regex.Matches(inText, roqIntegers);

                    // -------------------------
                    // FLOAT HIGHLIGHTING
                    // -------------------------
                    string roqFloats = "(%f\\([0-9]*\\.[0-9]+\\)|[0-9]*\\.[0-9]+)";
                    MatchCollection roqFloatMatches = Regex.Matches(inText, roqFloats);

                    // -------------------------
                    // 2 POINT VECTOR HIGHLIGHTING
                    // -------------------------
                    string roqVec2s = "%vec2\\([0-9]*\\.[0-9]+, [0-9]*\\.[0-9]+\\)";
                    MatchCollection roqVec2Matches = Regex.Matches(inText, roqVec2s);

                    // -------------------------
                    // 3 POINT VECTOR HIGHLIGHTING
                    // -------------------------
                    string roqVec3s = "%vec3\\([0-9]*\\.[0-9]+, [0-9]*\\.[0-9]+, [0-9]*\\.[0-9]+\\)";
                    MatchCollection roqVec3Matches = Regex.Matches(inText, roqVec3s);

                    // -------------------------
                    // TYPE HIGHLIGHTING
                    // -------------------------
                    string roqTypes = @"\b(SectionInteger|SectionFloat|SectionString|SectionArray|SectionStruct|SectionQBKey|ArrayArray|ArrayInteger|ArrayFloat|ArrayQBKey|ArrayStruct|StructInt|StructQBKey|StructFloat|StructString|StructArray}StructStruct|StructHeader|Floats|SectionFloatsX2|StructFloatsX2|SectionFloatsX3|StructFloatsX3|SectionStringW|StructStringW)\b";
                    MatchCollection roqTypeMatches = Regex.Matches(inText, roqTypes);

                    // -------------------------
                    // VARIABLE HIGHLIGHTING
                    // -------------------------
                    string roqVariables = "\\$[A-Za-z]+\\$";
                    MatchCollection roqVariableMatches = Regex.Matches(inText, roqVariables);

                    // -------------------------
                    // LOCAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    string roqLocalVars = "%GLOBAL%";
                    MatchCollection roqLocalVarMatches = Regex.Matches(inText, roqLocalVars);

                    // - - - - - - - - - - - - - - - - - - - - - - - - - -

                    // Next up: Save the original caret position before we start coloring!
                    int originalIndex = fctb.SelectionStart;
                    int originalLength = fctb.SelectionLength;
                    Color originalColor = Color.Black;

                    // We MUST focus on a label before highlighting anything!
                    // This helps avoid blinking.
                    InfoHeaderLabel.Focus();

                    // Next, we'll remove any previous highlighting.
                    // This ensures that modified words don't remain highlighted.
                    fctb.SelectionStart = 0;
                    fctb.SelectionLength = fctb.Text.Length;
                    fctb.SelectionColor = originalColor;

                    // - - - - - - - - - - - - - - - - - - - - - - - - - -

                    // Now we want to scan for any matches!

                    // -------------------------
                    // STRING HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqStringMatches, Color.Brown);

                    // -------------------------
                    // INTEGER HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqIntegerMatches, Color.Red);

                    // -------------------------
                    // FLOAT HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqFloatMatches, Color.Red);

                    // -------------------------
                    // 2 POINT VECTOR HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqVec2Matches, Color.Red);

                    // -------------------------
                    // 3 POINT VECTOR HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqVec3Matches, Color.Red);

                    // -------------------------
                    // TYPE HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqTypeMatches, Color.DarkCyan);

                    // -------------------------
                    // VARIABLE HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqVariableMatches, Color.FromArgb(255, 96, 74, 123));

                    // -------------------------
                    // LOCAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqLocalVarMatches, Color.Brown);

                    // -------------------------
                    // HEADER STUFF HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqHeaderMatches, Color.Blue);

                    // -------------------------
                    // KEYWORDS HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqKeywordMatches, Color.Blue);

                    // -------------------------
                    // LOGIC AND OPERATORS HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqOperatorMatches, Color.Blue);

                    // -------------------------
                    // COMMENT HIGHLIGHTING
                    //  (Inline and multi-line)
                    // -------------------------
                    HandleHighlighting(fctb, roqCommentMatches, Color.Green);

                    // - - - - - - - - - - - - - - - - - - - - - - - - - -

                    // Restore the original colors.
                    fctb.SelectionStart = originalIndex;
                    fctb.SelectionLength = originalLength;
                    fctb.SelectionColor = originalColor;

                    // Give the focus back!
                    fctb.Focus();

                    break;

                // - - - - - - - - - - - - - - - - - - - - - - - - - -

                // QBC syntax.
                case QBFileSyntax.QBC:
                    break;
            }
        }

        /// <summary>
        ///  Handles highlighting some text!
        /// </summary>
        /// <param name="matches">
        ///  The collection of regular expression matches.
        /// </param>
        /// <param name="color">
        ///  Color to highlight this text in!
        /// </param>
        public void HandleHighlighting(RichTextBox fctb, MatchCollection matches, Color color) {
            foreach (Match m in matches) {
                SetHighlightColor(fctb, m.Index, m.Length, color);
            }
        }

        /// <summary>
        ///  Helper function to set the highlight color for our keywords!
        /// </summary>
        /// <param name="fctb">
        ///  The RichTextBox instance.
        /// </param>
        /// <param name="startIndex">
        ///  The start index!
        /// </param>
        /// <param name="length">
        ///  Length of the text!
        /// </param>
        /// <param name="color">
        ///  The color to change to.
        /// </param>
        public void SetHighlightColor(RichTextBox fctb, int startIndex, int length, Color color) {
            fctb.SelectionStart = startIndex;
            fctb.SelectionLength = length;
            fctb.SelectionColor = color;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Makes a new script file and adds it to the list(s).
        /// </summary>
        public void MakeNewScript(string content, string name = "NewQBScript") {
            // OK, so we want to make a new script. Cool!
            // In order to properly do this, we'll have to be pretty careful.
            // First and foremost, BEFORE WE DO ANYTHING ELSE,
            // let's mark ScriptBeingChanged to true.
            ScriptBeingChanged = true;

            // This will now forbid the text editor areas from changing stuff that
            // we're trying to save or load into memory.

            // So, first off, let's check: Do we have any scripts made already?
            if (ScriptNames.Count <= 0 || ScriptContents.Count <= 0) {
                // We do not, so let's make a new one outright!
                ScriptNames.Add(name);
                ScriptContents.Add(content);

                QBFilesList.Items.Add(name);
                QBScriptNameTextBox.Text = name;
                QBScriptEditorArea.Text = content;

                QBFileIndex = 0;

            } else {
                // We DO have scripts already made.
                // In this case, we want to make sure to save our data first.

                string qbFileName = QBScriptNameTextBox.Text;
                string qbFileLines = QBScriptEditorArea.Text;

                // Next up, we need to make new, blank items.
                ScriptContents.Add(content);
                ScriptNames.Add(name);

                QBFilesList.Items.Add(name);
                QBScriptNameTextBox.Text = name;
                QBScriptEditorArea.Text = content;

                // So, we have our new items in place. Nice!
                // Next up, save our old contents to the current QB file index.
                int idx = QBFileIndex;
                ScriptNames[idx] = qbFileName;
                ScriptContents[idx] = qbFileLines;

                // Now set our QBFileIndex field to be the last script.
                QBFileIndex = QBFilesList.Items.Count - 1;
                QBFilesList.SelectedIndex = QBFileIndex;
            }

            // And finally, allow the editor to save data again!
            ScriptBeingChanged = false;
        }

        private void newScriptToolStripMenuItem_Click(object sender, EventArgs e) {
            MakeNewScript("");
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Loads a script from the QB file list in the editor.
        /// </summary>
        public void LoadScriptInList() {
            // Let's get the index of the file we want to LOAD.
            int selectedIdx = QBFilesList.SelectedIndex;

            // If it's out of range, break out!
            if (selectedIdx < 0 || selectedIdx >= QBFilesList.Items.Count) return;

            // OK, we should HOPEFULLY be safe!
            // Just like making a new script file, we want to forbid the
            // editor from accidentally screwing our files up in memory.
            ScriptBeingChanged = true;

            // Next up, grab the current contents in the editor.
            string qbFileName = QBScriptNameTextBox.Text;
            string qbFileLines = QBScriptEditorArea.Text;

            // These need to be stored to the CURRENT INDEX, which
            // is held under QBFileIndex.
            // So, we need to store those first.
            ScriptNames[QBFileIndex] = qbFileName;
            ScriptContents[QBFileIndex] = qbFileLines;
            QBFilesList.Items[QBFileIndex] = qbFileName;

            // So now that we've stored our data, we now want to load up
            // the contents from the selected index.
            QBScriptEditorArea.Text = ScriptContents[selectedIdx];
            QBScriptNameTextBox.Text = ScriptNames[selectedIdx];

            // And finally, set our global file index to the selected one,
            // and enable the files to be saved again!
            QBFileIndex = selectedIdx;
            ScriptBeingChanged = false;

        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The main 2 Fretworks QB file syntaxes.
        /// </summary>
        public enum QBFileSyntax {
            /// <summary>
            ///  Import QB file as ROQ.
            /// </summary>
            ROQ = 0,

            /// <summary>
            ///  Import QB file as QBC.
            /// </summary>
            QBC = 1
        }

        /// <summary>
        ///  Imports a plain text TXT or Q file into the editor!
        /// </summary>
        public void ImportPlainTextFile() {

            // Ask the user for a TXT or Q file.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select QB Source File to Open";
            ofd.Filter = "QB Source Files|*.txt;*.q|ROQ Source Text|*.txt|QBC Source Text|*.q";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            // Is there no file to open? If so, leave early!
            // Also leave early if the file doesn't exist.
            if (ofd.FileName == "" || !File.Exists(ofd.FileName)) return;

            // Add the script contents into the text editor!
            // We'll set our extension based on the file extension.
            string name = Path.GetFileNameWithoutExtension(ofd.FileName);
            string text = File.ReadAllText(ofd.FileName);
            string ext = Path.GetExtension(ofd.FileName);

            // Make the script and import it!
            MakeNewScript(text, name);

            bool isQBC = (ext == ".q");

            ScriptFileExtension.SelectedIndex = (isQBC) ? 1 : 0;

            SetSyntaxColoring((isQBC) ? QBFileSyntax.QBC : QBFileSyntax.ROQ, QBScriptEditorArea);
        }

        /// <summary>
        ///  Imports a QB file into raw text form! Requires GHSDK to use.
        /// </summary>
        /// <param name="syntax">
        ///  The syntax that the QB file will be decompiled as.
        /// </param>
        public void ImportQBFile(QBFileSyntax syntax) {

            // Ask the user for a QB file.
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select QB File to Decompile";
            ofd.Filter = "QB Files|*.qb.xen";
            ofd.Multiselect = false;
            ofd.ShowDialog();

            string cmd = "";
            string outTxtFile = "";
            string outQFile = "";
            Process process;

            // Is there no file to open? If so, leave early!
            // Also leave early if the file doesn't exist.
            if (ofd.FileName == "" || !File.Exists(ofd.FileName)) return;

            switch (syntax) {
                // Import as ROQ.
                case QBFileSyntax.ROQ:                    

                    // Now, make the command we want to use to pass to the SDK!
                    cmd = $"/C node {Path.Combine(SDKPath, "sdk.js")} decompile {ofd.FileName}";
                    process = Process.Start("cmd.exe", cmd);
                    process.WaitForExit();

                    // Now we want to read the text file we just made, and get its contents!
                    outTxtFile = ofd.FileName.Replace(".qb.xen", ".txt");
                    if (File.Exists(outTxtFile)) {
                        string importedLines = File.ReadAllText(outTxtFile);
                        string fileName = Path.GetFileNameWithoutExtension(outTxtFile);

                        MakeNewScript(importedLines, fileName);
                        ScriptFileExtension.SelectedIndex = 0;
                    }

                    SetSyntaxColoring(QBFileSyntax.ROQ, QBScriptEditorArea);

                    break;

                // Import as QBC.
                case QBFileSyntax.QBC:

                    // Now, make the command we want to use to pass to QBC!
                    cmd = $"/C node {Path.Combine(SDKPath, "nodeqbc/QBC.js")} decompile {ofd.FileName}";
                    process = Process.Start("cmd.exe", cmd);
                    process.WaitForExit();

                    // Now we want to read the Q file we just made, and get its contents!
                    outQFile = ofd.FileName.Replace(".qb.xen", ".q");
                    if (File.Exists(outQFile)) {
                        string importedLines = File.ReadAllText(outQFile);
                        string fileName = Path.GetFileName(outQFile).Replace(".q", "");

                        MakeNewScript(importedLines, fileName);
                        ScriptFileExtension.SelectedIndex = 1;
                    }

                    SetSyntaxColoring(QBFileSyntax.QBC, QBScriptEditorArea);

                    break;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void QBScriptNameTextBox_TextChanged(object sender, EventArgs e) {
            if (ScriptBeingChanged) return;

            QBFilesList.Items[QBFileIndex] = QBScriptNameTextBox.Text;
            ScriptNames[QBFileIndex] = QBScriptNameTextBox.Text;
        }

        private void QBFilesList_SelectedIndexChanged(object sender, EventArgs e) {
            if (ScriptBeingChanged) return;

            LoadScriptInList();
        }

        private void importQBAsROQToolStripMenuItem_Click(object sender, EventArgs e) {
            ImportQBFile(QBFileSyntax.ROQ);
        }

        private void importQBAsQBCToolStripMenuItem_Click(object sender, EventArgs e) {
            ImportQBFile(QBFileSyntax.QBC);
        }

        private void openScriptToolStripMenuItem_Click(object sender, EventArgs e) {
            ImportPlainTextFile();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        // QB SCRIPT EDITOR AREA EVENTS
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void QBScriptEditorArea_TextChanged(object sender, EventArgs e) {
            if (ScriptBeingChanged || ScriptContents.Count <= 0 || ScriptNames.Count <= 0) return;

            SetSyntaxColoring(QBFileSyntax.ROQ, sender);
            ScriptContents[QBFileIndex] = QBScriptEditorArea.Text;
        }
    }
}
