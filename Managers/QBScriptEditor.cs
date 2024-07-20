// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       Q B       S C R I P T       E D I T O R
//
//    The Mod Manager's QB script editor, allowing the user to write QB scripts
//    and create script mods, right in the launcher.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's QB script editor, allowing the user to write QB scripts 
    ///  and create script mods, right in the launcher.
    /// </summary>
    public partial class QBScriptEditor : Form {
        public QBScriptEditor() {
            InitializeComponent();

            StatusTextMain.Text = "";

            // Make sure that the QB script editor area has a HUGE limit!
            QBScriptNameTextBox.MaxLength = int.MaxValue;

            // Initialize control accessibility!
            UpdateControlStatus();

            // Set our theme!
            // EXTREMELY WIP, CHECK BACK LATER
            //~ UpdateTheme(Themes.Dark);

            // Font tester; if Cascadia Code is installed, we'll preferably use that.
            // Otherwise, try Consolas.
            // If that doesn't work, use Courier New.
            Font fontTester1 = new Font("Cascadia Code", 10);
            Font fontTester2 = new Font("Consolas", 10);
            Font fontDefault = new Font("Courier New", 10);

            if (fontTester1.Name == "Cascadia Code") {
                QBScriptEditorArea.Font = fontTester1;
            } else if (fontTester2.Name == "Consolas") {
                QBScriptEditorArea.Font = fontTester2;
            } else {
                QBScriptEditorArea.Font = fontDefault;
            }
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

        /// <summary>
        ///  Was a script just deleted from memory?
        /// </summary>
        public bool JustDeletedScript = false;

        /// <summary>
        ///  Is a script currently being syntax highlighted?
        /// </summary>
        public bool ScriptBeingHighlighted = false;

        /// <summary>
        ///  Themes that the script editor can use.
        /// </summary>
        public enum Themes {
            /// <summary>
            ///  Light theme, mostly white.
            /// </summary>
            Light = 0,

            /// <summary>
            ///  Dark theme, mostly blue gray and near-black.
            /// </summary>
            Dark = 1
        }

        /// <summary>
        ///  Controls the visual theme of the editor.
        /// </summary>
        public Themes Theme = Themes.Light;

        /// <summary>
        ///  The currently selected QB file syntax.
        /// </summary>
        public QBFileSyntax CurrentSyntax = QBFileSyntax.ROQ;

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Updates the theme to the editor with the designated one.
        /// </summary>
        /// <param name="theme">
        ///  Theme to change to.
        /// </param>
        public void UpdateTheme(Themes theme) {
            Theme = theme;
            switch (theme) {
                // - - - - - - - - - - - - -
                // LIGHT THEME
                // - - - - - - - - - - - - -
                case Themes.Light:

                    // Main form background and default foreground colors.
                    this.BackColor = SystemColors.Window;
                    this.ForeColor = SystemColors.WindowText;

                    // Text editor area.
                    QBScriptEditorArea.BackColor = Color.White;
                    QBScriptEditorArea.ForeColor = Color.Black;

                    // QB file listing.
                    QBFilesList.BackColor = SystemColors.Window;
                    QBFilesList.ForeColor = SystemColors.WindowText;

                    break;

                // - - - - - - - - - - - - -
                // DARK THEME
                // - - - - - - - - - - - - -
                case Themes.Dark:

                    // These are some colors that we'll use a few times.
                    Color darkColor = Color.FromArgb(255, 19, 22, 27);

                    // - - - - - - - - - - - - -

                    // Main form background and default foreground colors.
                    this.BackColor = Color.FromArgb(255, 16, 18, 22);
                    this.ForeColor = Color.White;

                    // Text editor area.
                    QBScriptEditorArea.BackColor = Color.FromArgb(255, 19, 22, 27);
                    QBScriptEditorArea.ForeColor = Color.White;

                    // QB file listing.
                    QBFilesList.BackColor = darkColor;
                    QBFilesList.ForeColor = Color.White;

                    // - - - - - - - - - - - - -

                    // Top menu bar, top tool bar, and status bar.
                    TopMenuStrip.ForeColor = Color.Black;
                    QuickActionsMenu.ForeColor = Color.Black;

                    TopToolBar.BackColor = darkColor;
                    TopToolBar.ForeColor = Color.White;

                    StatusBarMain.BackColor = darkColor;
                    StatusBarMain.ForeColor = Color.White;

                    break;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Updates the control statuses.
        /// </summary>
        public void UpdateControlStatus() {
            // No scripts loaded? If not, disable any and all editing!
            bool disableEditing = !(ScriptNames.Count <= 0 || ScriptExtensions.Count <= 0 || ScriptContents.Count <= 0);

            // -- VARIOUS CONTROL DISABLES
            QBFilesList.Enabled = disableEditing;
            QBScriptEditorArea.Enabled = disableEditing;
            QBScriptNameTextBox.Enabled = disableEditing;
            QuickActionsMenu.Enabled = disableEditing;
            EnableSyntaxHighlighting.Enabled = disableEditing;
            ScriptFileExtension.Enabled = disableEditing;
            DeleteSelScriptListButton.Enabled = disableEditing;

            // -- MENU DISABLES
            TopMenuEdit.Enabled = disableEditing;
            TopMenuTemplate.Enabled = disableEditing;
        }

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
            // No highlighting enabled? Then just leave!
            if (!EnableSyntaxHighlighting.Checked) return;

            // We're currently highlighting, make sure the program knows that!
            ScriptBeingHighlighted = true;

            // Set status bar text, print to console!
            V3LauncherCore.AddDebugEntry($"Doing syntax highlighting for script, using {syntax} syntax", "QB Script Editor");
            StatusTextMain.Text = "Doing syntax highlighting...";

            // Input text. We want to scan over it!
            string inText = (sender as RichTextBox).Text;
            RichTextBox fctb = (sender as RichTextBox);

            // Original caret positioning.
            int originalIndex = fctb.SelectionStart;
            int originalLength = fctb.SelectionLength;
            Color originalColor = (Theme == Themes.Dark) ? Color.White : Color.Black;

            // Now we want to do some highlighting!
            // We'll use regular expressions to determine our highlighting.
            // This will be a little bit difficult to understand, but it
            // hopefully won't be too bad!

            switch (syntax) {
                // ROQ syntax. We will assume this is default.
                case QBFileSyntax.ROQ: default:

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
                    string roqOperators = "<=.*<.*>.*>=.*!=.*!==.*=.*\\+.*-.*\\*.*/.*AND.*OR.*NOT";
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
                    string roqTypes = @"\b(SectionInteger|SectionFloat|SectionString|SectionArray|SectionStruct|SectionQBKey|ArrayArray|ArrayInteger|ArrayFloat|ArrayQBKey|ArrayStruct|StructInt|StructQBKey|StructFloat|StructString|StructArray}StructStruct|StructHeader|Floats|SectionFloatsX2|StructFloatsX2|SectionFloatsX3|StructFloatsX3|SectionStringW|StructStringW|SectionQBStringQs|StructQBStringQs)\b";
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

                    // -------------------------
                    // GLOBAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    string roqGlobalVars = "~\\$([A-Za-z0-9]+(_[A-Za-z0-9]+)+)\\$";
                    MatchCollection roqGlobalVarMatches = Regex.Matches(inText, roqGlobalVars);

                    // -------------------------
                    // HEXADECIMAL HIGHLIGHTING
                    // -------------------------
                    string roqHexes = "0x.*[A-Fa-f0-9]+";
                    MatchCollection roqHexMatches = Regex.Matches(inText, roqHexes);

                    // - - - - - - - - - - - - - - - - - - - - - - - - - -

                    V3LauncherCore.AddDebugEntry("Adjusting text colors based on regex matches", "QB Script Editor");

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
                    Color roqStringCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.String : ROQLightColorTemplate.String;
                    HandleHighlighting(fctb, roqStringMatches, roqStringCol);

                    // -------------------------
                    // INTEGER HIGHLIGHTING
                    // -------------------------
                    Color roqIntegerCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Integer : ROQLightColorTemplate.Integer;
                    HandleHighlighting(fctb, roqIntegerMatches, roqIntegerCol);

                    // -------------------------
                    // FLOAT HIGHLIGHTING
                    // -------------------------
                    Color roqFloatCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Float : ROQLightColorTemplate.Float;
                    HandleHighlighting(fctb, roqFloatMatches, roqFloatCol);

                    // -------------------------
                    // HEXADECIMAL HIGHLIGHTING
                    // -------------------------
                    Color roqHexCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Hexadecimal : ROQLightColorTemplate.Hexadecimal;
                    HandleHighlighting(fctb, roqHexMatches, roqHexCol);

                    // -------------------------
                    // 2 POINT VECTOR HIGHLIGHTING
                    // -------------------------
                    Color roqVec2Col = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Vec2 : ROQLightColorTemplate.Vec2;
                    HandleHighlighting(fctb, roqVec2Matches, roqVec2Col);

                    // -------------------------
                    // 3 POINT VECTOR HIGHLIGHTING
                    // -------------------------
                    Color roqVec3Col = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Vec3 : ROQLightColorTemplate.Vec3;
                    HandleHighlighting(fctb, roqVec3Matches, roqVec3Col);

                    // -------------------------
                    // TYPE HIGHLIGHTING
                    // -------------------------
                    Color roqTypeCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Type : ROQLightColorTemplate.Type;
                    HandleHighlighting(fctb, roqTypeMatches, roqTypeCol);

                    // -------------------------
                    // VARIABLE HIGHLIGHTING
                    // -------------------------
                    Color roqVariableCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Variable : ROQLightColorTemplate.Variable;
                    HandleHighlighting(fctb, roqVariableMatches, roqVariableCol);

                    // -------------------------
                    // LOCAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    Color roqLocalVariableCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.LocalVariable : ROQLightColorTemplate.LocalVariable;
                    HandleHighlighting(fctb, roqLocalVarMatches, roqLocalVariableCol);

                    // -------------------------
                    // GLOBAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    Color roqGlobalVariableCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.GlobalVariable : ROQLightColorTemplate.GlobalVariable;
                    HandleHighlighting(fctb, roqGlobalVarMatches, roqGlobalVariableCol);

                    // -------------------------
                    // HEADER STUFF HIGHLIGHTING
                    // -------------------------
                    Color roqHeaderCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Header : ROQLightColorTemplate.Header;
                    HandleHighlighting(fctb, roqHeaderMatches, roqHeaderCol);

                    // -------------------------
                    // KEYWORDS HIGHLIGHTING
                    // -------------------------
                    Color roqKeywordCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Keyword : ROQLightColorTemplate.Keyword;
                    HandleHighlighting(fctb, roqKeywordMatches, roqKeywordCol);

                    // -------------------------
                    // LOGIC AND OPERATORS HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, roqOperatorMatches, Color.Blue);

                    // -------------------------
                    // COMMENT HIGHLIGHTING
                    //  (Inline and multi-line)
                    // -------------------------
                    Color roqCommentCol = (Theme == Themes.Dark) ? ROQDarkColorTemplate.Comment : ROQLightColorTemplate.Comment;
                    HandleHighlighting(fctb, roqCommentMatches, roqCommentCol);

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

                    // -------------------------
                    // KEYWORDS HIGHLIGHTING
                    // -------------------------
                    string qbcKeywords = @"\b(if|elseif|else|endif|switch|case|default|endswitch|begin|repeat|break|return|script|endscript)\b";
                    MatchCollection qbcKeywordMatches = Regex.Matches(inText, qbcKeywords);

                    // -------------------------
                    // COMMENT HIGHLIGHTING
                    //  (Inline and multi-line)
                    // -------------------------
                    string qbcComments = @"(\/\/.+?$|\/\*.+?\*\/)";
                    MatchCollection qbcCommentMatches = Regex.Matches(inText, qbcComments, RegexOptions.Multiline);

                    // -------------------------
                    // LOCAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    string qbcLocalVars = "<([A-Za-z0-9]+(_[A-Za-z0-9]+)+)>";
                    MatchCollection qbcLocalVarMatches = Regex.Matches(inText, qbcLocalVars);

                    // -------------------------
                    // GLOBAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    string qbcGlobalVars = "\\$([A-Za-z0-9]+(_[A-Za-z0-9]+)+)";
                    MatchCollection qbcGlobalVarMatches = Regex.Matches(inText, qbcGlobalVars);

                    // -------------------------
                    // GLOBAL AS LOCAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    string qbcGlobalAsLocalVars = "\\$<([A-Za-z0-9]+(_[A-Za-z0-9]+)+)>";
                    MatchCollection qbcGlobalAsLocalVarMatches = Regex.Matches(inText, qbcGlobalAsLocalVars);

                    // -------------------------
                    // INTEGER HIGHLIGHTING
                    // -------------------------
                    string qbcIntegers = "(%i\\([0-9]+\\)|[0-9]+)";
                    MatchCollection qbcIntegerMatches = Regex.Matches(inText, qbcIntegers);

                    // -------------------------
                    // FLOAT HIGHLIGHTING
                    // -------------------------
                    string qbcFloats = "(%f\\([0-9]*\\.[0-9]+\\)|[0-9]*\\.[0-9]+)";
                    MatchCollection qbcFloatMatches = Regex.Matches(inText, qbcFloats);

                    // -------------------------
                    // STRING HIGHLIGHTING
                    // -------------------------
                    string qbcStrings = "'(?:[^\\\\']|\\\\\\\\|\\\\')*'";
                    MatchCollection qbcStringMatches = Regex.Matches(inText, qbcStrings);

                    // -------------------------
                    // HEXADECIMAL HIGHLIGHTING
                    // -------------------------
                    string qbcHexes = "0x.*[A-Fa-f0-9]+";
                    MatchCollection qbcHexMatches = Regex.Matches(inText, qbcHexes);

                    // - - - - - - - - - - - - - - - - - - - - - - - - - -

                    V3LauncherCore.AddDebugEntry("Adjusting text colors based on regex matches", "QB Script Editor");

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
                    HandleHighlighting(fctb, qbcStringMatches, Color.Brown);

                    // -------------------------
                    // INTEGER HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, qbcIntegerMatches, Color.Red);

                    // -------------------------
                    // FLOAT HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, qbcFloatMatches, Color.Red);

                    // -------------------------
                    // HEXADECIMAL HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, qbcHexMatches, Color.FromArgb(255, 255, 128, 0));

                    // -------------------------
                    // LOCAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, qbcLocalVarMatches, Color.Brown);

                    // -------------------------
                    // GLOBAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, qbcGlobalVarMatches, Color.FromArgb(255, 96, 74, 123));

                    // -------------------------
                    // GLOBAL AS LOCAL VARIABLE HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, qbcGlobalAsLocalVarMatches, Color.FromArgb(255, 16, 119, 182));

                    // -------------------------
                    // KEYWORDS HIGHLIGHTING
                    // -------------------------
                    HandleHighlighting(fctb, qbcKeywordMatches, Color.Blue);

                    // -------------------------
                    // COMMENT HIGHLIGHTING
                    //  (Inline and multi-line)
                    // -------------------------
                    HandleHighlighting(fctb, qbcCommentMatches, Color.Green);

                    // - - - - - - - - - - - - - - - - - - - - - - - - - -

                    // Restore the original colors.
                    fctb.SelectionStart = originalIndex;
                    fctb.SelectionLength = originalLength;
                    fctb.SelectionColor = originalColor;

                    // Give the focus back!
                    fctb.Focus();

                    break;
            }

            // - - - - - - - - - - - - - - - - - - - - - - - - - -

            V3LauncherCore.AddDebugEntry("Script highlighting finished", "QB Script Editor");
            StatusTextMain.Text = "Script highlighting finished";

            // Done highlighting, let the program know!
            ScriptBeingHighlighted = false;
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
        ///  Compiles the current script in the text editor area!
        /// </summary>
        public void CompileCurrentScript() {

            // Save file dialog stuff! Ask where we want to save the QB file.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Compiled QB File";
            sfd.Filter = "QB Files|*.qb.xen";
            sfd.ShowDialog();

            string qbFilePath = sfd.FileName;

            // No file? Leave early!
            if (qbFilePath == "") return;

            // Update status bar!
            StatusTextMain.Text = $"Compiling script {qbFilePath}";
            Application.DoEvents();

            // So before we do anything, we need to save our current
            // source file to a TXT file so we can compile it.

            string txtFilePath = Helpers.ChangeFileExtension(qbFilePath, ".txt");

            File.WriteAllText(txtFilePath, QBScriptEditorArea.Text);

            // node sdk.js compile infile outfile
            string cmd = $"/C node {Path.Combine(SDKPath, "sdk.js")} compile {txtFilePath} {qbFilePath}";
            var process = Process.Start("cmd.exe", cmd);
            process.WaitForExit();

            // Update status bar!
            StatusTextMain.Text = "Script compile complete";
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Makes a new script file and adds it to the list(s).
        /// </summary>
        public void MakeNewScript(QBFileSyntax syntax = QBFileSyntax.ROQ, string content = ROQScriptTemplates.NewScriptDefault, string name = "NewQBScript") {
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
                ScriptExtensions.Add(".txt");

                UpdateControlStatus();

                QBFilesList.Items.Add(name);
                QBScriptNameTextBox.Text = name;
                QBScriptEditorArea.Text = content;                

            } else {
                // We DO have scripts already made.
                // In this case, we want to make sure to save our data first.

                string qbFileName = QBScriptNameTextBox.Text;
                string qbFileLines = QBScriptEditorArea.Text;

                // Next up, we need to make new, blank items.
                ScriptContents.Add(content);
                ScriptNames.Add(name);
                ScriptExtensions.Add(".txt");

                UpdateControlStatus();

                QBFilesList.Items.Add(name);
                QBScriptNameTextBox.Text = name;
                QBScriptEditorArea.Text = content;

                // So, we have our new items in place. Nice!
                // Next up, save our old contents to the current QB file index.
                int idx = QBFileIndex;
                ScriptNames[idx] = qbFileName;
                ScriptContents[idx] = qbFileLines;
            }

            // Now set our QBFileIndex field to be the last script.
            QBFileIndex = QBFilesList.Items.Count - 1;
            QBFilesList.SelectedIndex = QBFileIndex;

            // And finally, allow the editor to save data again!
            ScriptBeingChanged = false;
            JustDeletedScript = false;

            // And begin syntax highlighting if it's enabled!
            SetSyntaxColoring(QBFileSyntax.ROQ, QBScriptEditorArea);
        }

        private void newScriptToolStripMenuItem_Click(object sender, EventArgs e) {
            MakeNewScript();
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
            // We have also no longer just deleted a script, cool!
            QBFileIndex = selectedIdx;
            ScriptBeingChanged = false;
            JustDeletedScript = false;

            UpdateControlStatus();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Delete a script from memory and the QB file list!
        /// </summary>
        public void DeleteCurrentScript() {
            // Just in case anything may go wrong, let's just set
            // ScriptBeingChanged to true.
            // We SHOULD avoid data loss this way. Hopefully.
            ScriptBeingChanged = true;

            // Ask if we should delete!
            string deleteConfirm = "Are you sure you want to delete this script?";
            bool shouldDelete = MessageBox.Show(deleteConfirm, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

            // Are we going to delete this script?
            if (shouldDelete) {
                string saveConfirm = "Do you want to save your script before closing it?";
                bool shouldSave = MessageBox.Show(saveConfirm, "Save Script?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                // Do we want to save the currently loaded script?
                if (shouldSave) {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save QB Script Source";
                    sfd.Filter = "QB Script Source|*.txt;*.q|ROQ Source|*.txt|QBC Source|*.q";

                    sfd.ShowDialog();

                    if (sfd.FileName != "") {
                        File.WriteAllText(sfd.FileName, QBScriptEditorArea.Text);
                    }
                }

                // Now we need to CAREFULLY delete the script. Gently.
                // Don't do this rough. Or else there'll be consequences.
                // Like memory loss. And no one wants that; not even computers.

                // OK, jokes aside, let's acutally delete stuff.
                // But we DO need to be careful about this!

                // Index of the file we want to delete.
                int idxToDelete = QBFileIndex;

                // Delete all items from the memory lists!
                ScriptContents.RemoveAt(idxToDelete);
                ScriptNames.RemoveAt(idxToDelete);
                ScriptExtensions.RemoveAt(idxToDelete);
                QBFilesList.Items.RemoveAt(idxToDelete);

                // Reset the text areas, just in case.
                QBScriptEditorArea.Text = "";
                QBScriptNameTextBox.Text = "";
                ScriptFileExtension.SelectedIndex = 0;

                // Now update our controls' Enabled statuses!
                UpdateControlStatus();

                // Our stuff has been removed at this point. Great!
                // Now we need to reset QBFileIndex to be a different value.

                // Let's just make it be -1 for now.
                // If we do this, HOPEFULLY we don't lose anything by doing so.
                // This may cause errors, though. Hm...
                QBFileIndex = 0;
            }

            // And set ScriptBeingChanged back to false!
            ScriptBeingChanged = false;

            // We just deleted a script. Set our field for it!
            JustDeletedScript = true;
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

            bool isQBC = (ext == ".q");
            QBFileSyntax syntax = (isQBC) ? QBFileSyntax.QBC : QBFileSyntax.ROQ;

            ScriptFileExtension.SelectedIndex = (isQBC) ? 1 : 0;

            // Make the script and import it!
            MakeNewScript(syntax, text, name);

            if (!ScriptBeingHighlighted) SetSyntaxColoring(syntax, QBScriptEditorArea);
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

                        MakeNewScript(QBFileSyntax.ROQ, importedLines, fileName);
                        ScriptFileExtension.SelectedIndex = 0;
                    }

                    if (!ScriptBeingHighlighted) SetSyntaxColoring(QBFileSyntax.ROQ, QBScriptEditorArea);

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

                        MakeNewScript(QBFileSyntax.QBC, importedLines, fileName);
                        ScriptFileExtension.SelectedIndex = 1;
                    }

                    if (!ScriptBeingHighlighted) SetSyntaxColoring(QBFileSyntax.QBC, QBScriptEditorArea);

                    break;
            }
        }

        /// <summary>
        ///  Convert a QB file from one syntax to another! If the same syntax type is specified for
        ///  both arguments, no conversion is performed.
        /// </summary>
        /// <param name="inSyntax">
        ///  The input syntax type.
        /// </param>
        /// <param name="outSyntax">
        ///  The output syntax type.
        /// </param>
        public void ConvertQBFileSyntax(QBFileSyntax inSyntax, QBFileSyntax outSyntax) {
            // Same input syntaxes? Just return!
            if (inSyntax == outSyntax) return;

            // Ask the user if we want to convert this script.
            string convertConfirm = "Are you sure you want to convert this script?\n\nWarning: Your script comments will NOT be preserved!";
            bool convertScript = MessageBox.Show(convertConfirm, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

            // We don't want to convert the script, bail!
            if (!convertScript) return;

            // - - - - - - - - - - - - - - - - - - - - - - - - - -

            // Some boiler plate variables. We'll make use of these later!
            string tempQFile, qbcCmd, compiledQFile, roqDecompCmd, decompiledROQFile;
            string tempTxtFile, roqCmd, compiledTxtFile, qbcDecompCmd, decompiledQBCFile;
            string decompiledContent;
            Process process;

            // - - - - - - - - - - - - - - - - - - - - - - - - - -

            // Show status bar text!
            // Also update our status variables too.
            StatusTextMain.Text = "Converting script, please wait...";
            ScriptBeingChanged = true;

            // Now which kind of syntax do we want to convert to?
            switch (outSyntax) {

                // QBC -> ROQ (why would anyone do this?)
                case QBFileSyntax.ROQ:

                    // So first up, compile the file using QBC.
                    // We'll make this temporary, and we'll re-decompile using ROQ.

                    // Now, if you're actually going from QBC to ROQ, you might ought
                    // to ask yourself why you're doing that.
                    // But oh well, we'll at least honor the request.

                    tempQFile = "./TMP_ROQ_CONVERSION.q";
                    File.WriteAllText(tempQFile, QBScriptEditorArea.Text.Replace("\t", "    "));
                    qbcCmd = $"/C node {Path.Combine(SDKPath, "nodeqbc/QBC.js")} compile {tempQFile}";
                    process = Process.Start("cmd.exe", qbcCmd);
                    process.WaitForExit();

                    // ----------------

                    // Next, we want to re-decompile it using ROQ.
                    compiledQFile = "./TMP_ROQ_CONVERSION.qb.xen";
                    roqDecompCmd = $"/C node {Path.Combine(SDKPath, "sdk.js")} decompile {compiledQFile}";
                    process = Process.Start("cmd.exe", roqDecompCmd);
                    process.WaitForExit();

                    // ----------------

                    // Now let's read the converted file!
                    decompiledROQFile = "./TMP_ROQ_CONVERSION.txt";
                    decompiledContent = File.ReadAllText(decompiledROQFile);

                    // At this point, we have our content loaded into memory.
                    // Now we just need to clean up the files we made!
                    File.Delete(tempQFile);
                    File.Delete(compiledQFile);
                    File.Delete(decompiledROQFile);

                    // ----------------

                    QBScriptEditorArea.Text = decompiledContent;
                    SetSyntaxColoring(QBFileSyntax.ROQ, QBScriptEditorArea);

                    break;

                // - - - - - - - - - - - - - - - - - - - - - - - - - -

                // ROQ -> QBC (Wes would be jumping for joy (he already is))
                // Yay, you made the right decision! :D
                case QBFileSyntax.QBC:

                    // So we chose the more sane conversion. Awesome!
                    // So what we'll do is compile the file first using ROQ, then
                    // we'll re-decompile it as QBC.

                    tempTxtFile = "./TMP_QBC_CONVERSION.txt";
                    File.WriteAllText(tempTxtFile, QBScriptEditorArea.Text.Replace("\t", "    "));
                    roqCmd = $"/C node {Path.Combine(SDKPath, "sdk.js")} compile {tempTxtFile}";
                    process = Process.Start("cmd.exe", roqCmd);
                    process.WaitForExit();

                    // ----------------

                    // Next, we want to re-decompile it using QBC.
                    compiledTxtFile = "./TMP_QBC_CONVERSION.qb.xen";
                    qbcDecompCmd = $"/C node {Path.Combine(SDKPath, "nodeqbc/QBC.js")} decompile {compiledTxtFile}";
                    process = Process.Start("cmd.exe", qbcDecompCmd);
                    process.WaitForExit();

                    // ----------------

                    // Now let's read the converted file!
                    decompiledQBCFile = "./TMP_QBC_CONVERSION.q";
                    decompiledContent = File.ReadAllText(decompiledQBCFile);

                    // At this point, we have our content loaded into memory.
                    // Now we just need to clean up the files we made!
                    File.Delete(tempTxtFile);
                    File.Delete(compiledTxtFile);
                    File.Delete(decompiledQBCFile);

                    // ----------------

                    QBScriptEditorArea.Text = decompiledContent;
                    SetSyntaxColoring(QBFileSyntax.QBC, QBScriptEditorArea);

                    break;
            }

            // Update our status and status globals again!
            StatusTextMain.Text = "Script conversion complete";
            ScriptBeingChanged = false;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void QBScriptNameTextBox_TextChanged(object sender, EventArgs e) {
            if (ScriptBeingChanged || JustDeletedScript) return;

            QBFilesList.Items[QBFileIndex] = QBScriptNameTextBox.Text;
            ScriptNames[QBFileIndex] = QBScriptNameTextBox.Text;
        }

        private void QBFilesList_SelectedIndexChanged(object sender, EventArgs e) {
            if (ScriptBeingChanged || JustDeletedScript) return;

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

        private void fontStyleToolStripMenuItem_Click(object sender, EventArgs e) {
            FontDialog fnt = new FontDialog();
            fnt.Font = QBScriptEditorArea.Font;
            fnt.ShowDialog();
            QBScriptEditorArea.Font = fnt.Font;
            SetSyntaxColoring(CurrentSyntax, QBScriptEditorArea);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        // QB SCRIPT EDITOR AREA EVENTS
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        // -- TEXT CHANGED IN EDITOR
        private void QBScriptEditorArea_TextChanged(object sender, EventArgs e) {
            if (ScriptBeingChanged || JustDeletedScript || ScriptContents.Count <= 0 || ScriptNames.Count <= 0 || ScriptExtensions.Count <= 0) return;

            InjectSnippetFromCode();
            if (!ScriptBeingHighlighted) SetSyntaxColoring(QBFileSyntax.ROQ, sender);

            ScriptContents[QBFileIndex] = QBScriptEditorArea.Text.Replace("\t", "    ");
        }

        /// <summary>
        ///  Inject a code snippet from the code, if defined!
        /// </summary>
        public void InjectSnippetFromCode() {
            // The signaling string for a snippet insert is @snip:.
            // If we find this, insert a snippet!

            // Now, based on the given snippet shorthand, insert our text!

            // -- ROQ SNIPPETS
            if (CurrentSyntax == QBFileSyntax.ROQ) {
                InsertSnippetInCode("ifs", ROQScriptTemplates.IfStatement);
                InsertSnippetInCode("ifes", ROQScriptTemplates.IfElseStatement);
                InsertSnippetInCode("elif", ROQScriptTemplates.IfElseIfStatement);

                InsertSnippetInCode("while", ROQScriptTemplates.WhileLoopToStatement);
                InsertSnippetInCode("loop", ROQScriptTemplates.WhileLoopToStatement);
                InsertSnippetInCode("rwhile", ROQScriptTemplates.WhileLoopToInverseStatement);
                InsertSnippetInCode("rloop", ROQScriptTemplates.WhileLoopToInverseStatement);

                InsertSnippetInCode("switch", ROQScriptTemplates.SwitchStatement);

                InsertSnippetInCode("script", ROQScriptTemplates.ScriptTemplate);

                InsertSnippetInCode("noparam", ROQScriptTemplates.ParameterCheck);
                InsertSnippetInCode("arrit", ROQScriptTemplates.IterateOverArray);
                InsertSnippetInCode("strcont", ROQScriptTemplates.StructContainsElement);

                InsertSnippetInCode("iniv", ROQScriptTemplates.DEGetINIValue);
                InsertSnippetInCode("inis", ROQScriptTemplates.DEGetINIString);

            // -- QBC SNIPPETS
            } else if (CurrentSyntax == QBFileSyntax.QBC) {

            }
        }

        /// <summary>
        ///  Inserts a code snippet based if the QB script editor contains a certain snippet delimiter.
        /// </summary>
        /// <param name="delimiter">
        ///  The snippet delimiter.
        /// </param>
        /// <param name="templateToInsert">
        ///  The template string to insert.
        /// </param>
        private void InsertSnippetInCode(string delimiter, string templateToInsert) {
            if (QBScriptEditorArea.Text.Contains("@snip:" + delimiter)) {
                int oldCursorIdx = QBScriptEditorArea.SelectionStart;
                QBScriptEditorArea.Text = QBScriptEditorArea.Text.Replace("@snip:" + delimiter, templateToInsert);
                QBScriptEditorArea.SelectionStart = oldCursorIdx + delimiter.Length;
            }
        }

        // -- SCRIPT EXTENSION
        private void ScriptFileExtension_SelectedIndexChanged(object sender, EventArgs e) {
            switch (ScriptFileExtension.SelectedIndex) {
                // -- ROQ (default)
                case 0: default:
                    CurrentSyntax = QBFileSyntax.ROQ;
                    break;

                // -- QBC
                case 1:
                    CurrentSyntax = QBFileSyntax.QBC;
                    break;
            }

            // Re-apply syntax coloring to reflect our changes.
            SetSyntaxColoring(CurrentSyntax, QBScriptEditorArea);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Paste a template into the text editor area!
        /// </summary>
        /// <param name="text">
        ///  Text to paste.
        /// </param>
        public void PasteTemplate(string text) {
            QBScriptEditorArea.SelectedText += text;

            Application.DoEvents();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void NewScriptButton_Click(object sender, EventArgs e) {
            MakeNewScript();
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        // ROQ: GLOBAL DECLARATIONS
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        // -- INTEGER (SECTIONINTEGER)
        private void integerGlobalSectionIntegerToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.GlobalIntDeclaration);
        }

        // -- FLOAT (SECTIONFLOAT)
        private void floatSectionFloatToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.GlobalFloatDeclaration);
        }

        // -- STRING (SECTIONSTRING)
        private void stringSectionStringToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.GlobalStringDeclaration);
        }

        // -- QBKEY (SECTIONQBKEY)
        private void qBKeySectionQBKeyToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.GlobalQBKeyDeclaration);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        // ROQ: SCRIPT ELEMENTS
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        // -- DEFINE SCRIPT
        private void defineScriptToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.ScriptTemplate);
        }

        // - - - - - - - - - - - - - - - - -

        // -- IF STATEMENTS
        private void ifStatementToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.IfStatement);
        }

        // -- WHILE / LOOP_TO LOOP
        private void whileLoopToLoopToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.WhileLoopToStatement);
        }

        // -- SWITCH STATEMENT
        private void switchStatementToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.SwitchStatement);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        // ROQ: SCRIPT ELEMENTS: CODE SNIPPETS
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        // -- PARAMETER CHECK
        private void parameterCheckToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.ParameterCheck);
        }

        // -- ITERATE OVER ARRAY
        private void iterateOverArrayToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.IterateOverArray);
        }

        // -- STRUCT CONTAINS ELEMENT
        private void structContainsElementToolStripMenuItem_Click(object sender, EventArgs e) {
            PasteTemplate(ROQScriptTemplates.StructContainsElement);          
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        // QUICK ACTIONS MENU
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        // -- COMPILE SCRIPT
        //      This only compiles the CURRENT script
        private void compileScriptToolStripMenuItem_Click(object sender, EventArgs e) {
            CompileCurrentScript();
        }

        // -- CONVERT TO QBC
        private void qBCToolStripMenuItem1_Click(object sender, EventArgs e) {
            ConvertQBFileSyntax((ScriptFileExtension.Text == ".txt") ? QBFileSyntax.ROQ : QBFileSyntax.QBC, QBFileSyntax.QBC);
        }

        // -- CONVERT TO ROQ
        private void rOQToolStripMenuItem1_Click(object sender, EventArgs e) {
            ConvertQBFileSyntax((ScriptFileExtension.Text == ".q") ? QBFileSyntax.QBC : QBFileSyntax.ROQ, QBFileSyntax.ROQ);
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
        // QB FILE LIST BUTTON HELPERS
        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        private void AddNewScriptListButton_Click(object sender, EventArgs e) {
            MakeNewScript();
        }

        private void DeleteSelScriptListButton_Click(object sender, EventArgs e) {
            DeleteCurrentScript();
        }

        
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //    R O Q       S C R I P T       T E M P L A T E S
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    /// <summary>
    ///  Template class for ROQ script templates. Cannot be created.
    /// </summary>
    abstract public class ROQScriptTemplates {
        /// <summary>
        ///  Template for a global integer declaration.
        /// </summary>
        public const string GlobalIntDeclaration = "SectionInteger my_integer 0";

        /// <summary>
        ///  Template for a global string declaration.
        /// </summary>
        public const string GlobalStringDeclaration = "SectionString my_string \"\"";

        /// <summary>
        ///  Template for a global QBKey declaration.
        /// </summary>
        public const string GlobalQBKeyDeclaration = "SectionQBKey my_qbkey my_value";

        /// <summary>
        ///  Template for a global float declaration.
        /// </summary>
        public const string GlobalFloatDeclaration = "SectionFloat my_float 0.0";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template for an if statement. Only contains the if condition and endif.
        /// </summary>
        public const string IfStatement = ":i if ($true$)\n\t// If true\n:i endif";

        /// <summary>
        ///  Template for an if / else statement. Contains the if condition, else block, and endif.
        /// </summary>
        public const string IfElseStatement = ":i if ($true$)\n\t// If true\n:i else\n\t// If false\n:i endif";

        /// <summary>
        ///  Template for an if / elseif / else statement. Contains the if condition, elseif condition, else block, and endif.
        /// </summary>
        public const string IfElseIfStatement = ":i if ($true$)\n\t// If 1st condition is true\n:i elseif ($false$)\n\t// If 2nd condition is true\n:i else\n\t// If all above are false\n:i endif";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template for a while / loop_to loop.
        /// </summary>
        public const string WhileLoopToStatement = ":i $i$ = %i(0)\n:i while\n\t// Loop body\n\n\t:i $i$ = (%GLOBAL%$i$ + %i(1))\n:i loop_to %i(5)";

        /// <summary>
        ///  Template for an inverse while / loop_to loop.
        /// </summary>
        public const string WhileLoopToInverseStatement = ":i $i$ = %i(5)\n:i while\n\t// Loop body\n\n\t:i $i$ = (%GLOBAL%$i$ - %i(1))\n:i loop_to %i(5)";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template for a switch statement.
        /// </summary>
        public const string SwitchStatement = ":i switch (%GLOBAL%$variable$)\n\t:i case $value1$\n\t\t// Case 1 body\n\t\t:i endcase\n\n\tcase $value2$\n\t\t// Case 2 body\n\t\t:i endcase\n\n\tdefault\n\t\t// Default case\n:i end_switch";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template for a script declaration.
        /// </summary>
        public const string ScriptTemplate = "Script script_name [\n\n\t:i endfunction\n]";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template for a parameter check using GotParam.
        /// </summary>
        public const string ParameterCheck = ":i if NOT $GotParam$ $PARAM_NAME$\n\t// Parameter was not found\n\t:i return\n:i endif";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template to iterate over an array with a while / loop_to loop.
        /// </summary>
        public const string IterateOverArray = ":i $array_name$ = $INPUT_ARRAY_HERE$\n" +
                                               ":i $GetArraySize$ %GLOBAL%$array_name$\n" +
                                               ":i $i$ = %i(0)\n\n" +
                                               ":i while\n" +
                                                   "\t:i $element$ = (%GLOBAL%$array_name$ :a{ %GLOBAL%$i$ :a})\n\n" +
                                                   "\t// Loop body here\n\n" +
                                                   "\t:i $i$ = (%GLOBAL%$i$ + %i(1))\n" +
                                               ":i loop_to %GLOBAL%$array_size$";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template for checking if a given item exists in a struct.
        /// </summary>
        public const string StructContainsElement = ":i $struct$ = $INPUT_STRUCT_HERE$\n" +
                                                    ":i if $StructureContains$ $structure$ = %GLOBAL%$struct$ $STRUCT_ELEMENT_HERE$\n" +
                                                    "\t// Struct did contain the element\n" +
                                                    ":i else\n" +
                                                    "\t// Struct did NOT contain the element\n" +
                                                    ":i endif";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Template for reading a value from GHWTDE.ini. This uses any non-string value.
        /// </summary>
        public const string DEGetINIValue = ":i $DE_GetINIValue$ $section$ = %s(\"SECTION_NAME_HERE\") $key$ = %s(\"KEY_NAME_HERE\") $default$ = %i(1)\n" +
                                            ":i if (%GLOBAL%$value$ = %i(1))\n" +
                                            "\t// If value is 1\n" +
                                            ":i endif";

        /// <summary>
        ///  Template for reading a value from GHWTDE.ini. This uses string values.
        /// </summary>
        public const string DEGetINIString = ":i $DE_GetINIString$ $section$ = %s(\"SECTION_NAME_HERE\") $key$ = %s(\"KEY_NAME_HERE\") $default$ = %s(\"DEFAULT\")\n" +
                                             ":i if NOT (%GLOBAL%$string_value$ = %s(\"DEFAULT\"))\n" +
                                             "\t// If value is 1\n" +
                                             ":i endif";

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The new script defaults that will be pasted in.
        /// </summary>
        public const string NewScriptDefault = "// For more help, visit the wiki for a brief guide on QB scripting:\n" +
                                               "//  https://ghwt.de/wiki/#/sdk/\n" +
                                               "// \n" +
                                               "// Ask for help on our Discord server for more!\n" +
                                               "//  https://discord.gg/HVECPzkV4u\n\n" +
                                               "Unknown [GHWT_HEADER]\n\n" +
                                               "Script NewQBScript_Load [\n" +
                                               "\t:i $printf$ %s(\"Hello World!\")\n" +
                                               "\t:i endfunction\n" +
                                               "]\n";
    }

    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    //    S Y N T A X       C O L O R I N G       T E M P L A T E S
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    /// <summary>
    ///  Template class for ROQ's syntax highlighting for the light theme.
    /// </summary>
    abstract public class ROQLightColorTemplate {
        /// <summary>
        ///  Color for strings. <code>%s("") | ""</code>
        /// </summary>
        public static Color String = Color.Brown;

        /// <summary>
        ///  Color for integers. <code>%i(7) | 12</code>
        /// </summary>
        public static Color Integer = Color.Red;

        /// <summary>
        ///  Color for floats. <code>%f(3.6) | 8.5</code>
        /// </summary>
        public static Color Float = Color.Red;

        /// <summary>
        ///  Color for hexadecimal values, such as QBKeys. <code>0x1234ABCD</code>
        /// </summary>
        public static Color Hexadecimal = Color.FromArgb(255, 255, 128, 0);

        /// <summary>
        ///  Color for 2 point vectors. <code>%vec2(1.0, 1.0)</code>
        /// </summary>
        public static Color Vec2 = Color.Red;

        /// <summary>
        ///  Color for 3 point vectors. <code>%vec3(1.0, 1.0, 1.0)</code>
        /// </summary>
        public static Color Vec3 = Color.Red;

        /// <summary>
        ///  Color for data types. <code>SectionInteger | StructInt | SectionQBKey | StructQBKey | ArrayStruct</code>
        /// </summary>
        public static Color Type = Color.DarkCyan;

        /// <summary>
        ///  Color for local variables. <code>:i $variable$ = %i(20)</code>
        /// </summary>
        public static Color Variable = Color.FromArgb(255, 96, 74, 123);

        /// <summary>
        ///  Color for the "%GLOBAL%" modifier in front of local variables.
        ///  <code>
        ///   :i $variable$ = %i(10)
        ///   :i $variable$ = (%GLOBAL%$variable$ * %i(2))
        ///  </code>
        /// </summary>
        public static Color LocalVariable = Color.Brown;

        /// <summary>
        ///  Color for globally defined variables.
        ///  <code>
        ///   SectionInteger my_number 172
        ///  </code>
        /// </summary>
        public static Color GlobalVariable = Color.FromArgb(255, 16, 119, 182);

        /// <summary>
        ///  Color for the header of an ROQ script. <code>Unknown [GHWT_HEADER]</code>
        /// </summary>
        public static Color Header = Color.Blue;

        /// <summary>
        ///  Color for keywords in scripts. <code>if | else | elseif | endif | switch | end_switch | while | loop_to</code>
        /// </summary>
        public static Color Keyword = Color.Blue;

        /// <summary>
        ///  Color for comments in scripts. <code>// This is a comment</code>
        /// </summary>
        public static Color Comment = Color.Green;
    }

    /// <summary>
    ///  Template class for ROQ's syntax highlighting for the dark theme.
    /// </summary>
    abstract public class ROQDarkColorTemplate {
        /// <summary>
        ///  Color for strings. <code>%s("") | ""</code>
        /// </summary>
        public static Color String = Color.Purple;

        /// <summary>
        ///  Color for integers. <code>%i(7) | 12</code>
        /// </summary>
        public static Color Integer = Color.Red;

        /// <summary>
        ///  Color for floats. <code>%f(3.6) | 8.5</code>
        /// </summary>
        public static Color Float = Color.Red;

        /// <summary>
        ///  Color for hexadecimal values, such as QBKeys. <code>0x1234ABCD</code>
        /// </summary>
        public static Color Hexadecimal = Color.FromArgb(255, 255, 128, 0);

        /// <summary>
        ///  Color for 2 point vectors. <code>%vec2(1.0, 1.0)</code>
        /// </summary>
        public static Color Vec2 = Color.Red;

        /// <summary>
        ///  Color for 3 point vectors. <code>%vec3(1.0, 1.0, 1.0)</code>
        /// </summary>
        public static Color Vec3 = Color.Red;

        /// <summary>
        ///  Color for data types. <code>SectionInteger | StructInt | SectionQBKey | StructQBKey | ArrayStruct</code>
        /// </summary>
        public static Color Type = Color.DarkCyan;

        /// <summary>
        ///  Color for local variables. <code>:i $variable$ = %i(20)</code>
        /// </summary>
        public static Color Variable = Color.LightSlateGray;

        /// <summary>
        ///  Color for the "%GLOBAL%" modifier in front of local variables.
        ///  <code>
        ///   :i $variable$ = %i(10)
        ///   :i $variable$ = (%GLOBAL%$variable$ * %i(2))
        ///  </code>
        /// </summary>
        public static Color LocalVariable = Color.LightGray;

        /// <summary>
        ///  Color for globally defined variables.
        ///  <code>
        ///   SectionInteger my_number 172
        ///  </code>
        /// </summary>
        public static Color GlobalVariable = Color.FromArgb(255, 255, 109, 124);

        /// <summary>
        ///  Color for the header of an ROQ script. <code>Unknown [GHWT_HEADER]</code>
        /// </summary>
        public static Color Header = Color.FromArgb(255, 51, 119, 153);

        /// <summary>
        ///  Color for keywords in scripts. <code>if | else | elseif | endif | switch | end_switch | while | loop_to</code>
        /// </summary>
        public static Color Keyword = Color.FromArgb(255, 51, 119, 153);

        /// <summary>
        ///  Color for comments in scripts. <code>// This is a comment</code>
        /// </summary>
        public static Color Comment = Color.FromArgb(255, 128, 255, 204);

    }
}
