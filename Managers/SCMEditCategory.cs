// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//          E D I T       C A T E G O R Y       D A T A
//
//    The Mod Manager's song and song category mod manager's dialog for editing
//    pre-existing category mods.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.IO;
using WTDE_Launcher_V3.NX;

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
using System.Drawing.Imaging;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's song and song category mod manager's dialog for editing
    ///  pre-existing category mods.
    /// </summary>
    public partial class SCMEditCategory : Form {
        /// <summary>
        ///  The path to the currently active category. THIS CAN'T BE CHANGED AFTER SETTING IT!
        /// </summary>
        public string ActiveCategoryPath { get; }

        /// <summary>
        ///  The original array of PNG data bytes. If these match, then we didn't change the image.
        /// </summary>
        public byte[] PNGDataArray { get; }

        /// <summary>
        ///  The name of the category when the dialog was first opened.
        /// </summary>
        public string OldCategoryName { get; }

        /// <summary>
        ///  The checksum of the category when the dialog was first opened.
        /// </summary>
        public string OldCategoryChecksum { get; }

        /// <summary>
        ///  The Mod Manager's song and song category mod manager's dialog for editing
        ///  pre-existing category mods.
        /// </summary>
        /// <param name="path"></param>
        public SCMEditCategory(string path, string cateName, string cateChecksum, Image image) {
            InitializeComponent();

            ActiveCategoryPath = path;

            NewName.Text = cateName;
            NewChecksum.Text = cateChecksum;
            PathLabelRO.Text = path;
            LogoImageBox.Image = image;

            OldCategoryName = cateName;
            OldCategoryChecksum = cateChecksum;

            Console.WriteLine($"Path selected: {ActiveCategoryPath}");

            using (MemoryStream ms = new MemoryStream()) {
                image.Save(ms, image.RawFormat);
                PNGDataArray = ms.ToArray();
            }

            //~ Console.WriteLine($"Debug: Actual image size in box:\nw: {LogoImageBox.Image.Width}\nh: {LogoImageBox.Image.Height}");
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void ReplaceImage_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image File for Category";
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg";

            ofd.ShowDialog();

            // Update the image and resize it to 256 X 256.
            if (ofd.FileName != "") {
                Bitmap image = new Bitmap(ofd.FileName);
                Bitmap resizedImage = new Bitmap(image, 256, 256);
                LogoImageBox.Image = resizedImage;
            }
        }

        private void ExtractImage_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Category Image as PNG";
            sfd.Filter = "Portable Network Graphics Image|*.png";

            sfd.ShowDialog();

            if (sfd.FileName != "") {
                using (MemoryStream ms = new MemoryStream()) {
                    LogoImageBox.Image.Save(sfd.FileName, ImageFormat.Png);
                }
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e) {
            // SANITY CHECKS!
            if (NewName.Text == "" || NewChecksum.Text == "") {
                MessageBox.Show("You're missing required fields!", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Make sure we're OK with moving forward!
            string ensureConfirm = "Do you really wish to apply all changes? If your checksum has changed, " +
                                   "the program will ATTEMPT to fix all instances of the old checksum with " +
                                   "the new one, but this is not a guarantee and should not be relied upon.\n\n" +
                                   "Are you sure you want to continue?";
            if (MessageBox.Show(ensureConfirm, "Are You Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            // 1st task: Rename the category if we changed the name.
            string newCategoryName = NewName.Text;
            string iniPath = Path.Combine(ActiveCategoryPath, "category.ini");

            if (newCategoryName != OldCategoryName) {

                IniFile iFile1 = new IniFile();
                iFile1.Load(iniPath);

                iFile1.Sections["CategoryInfo"].Keys["Name"].Value = newCategoryName;

                iFile1.Save(iniPath);
            }

            // 2nd task: Update the image if we changed it.
            byte[] currentPNGData = null;
            using (MemoryStream ms = new MemoryStream()) {
                LogoImageBox.Image.Save(ms, ImageFormat.Png);
                currentPNGData = ms.ToArray();
            }

            if (currentPNGData != PNGDataArray) {
                Console.WriteLine("Image PNG data changed, updating...");
                NXImage nxImg = new NXImage(LogoImageBox.Image);

                // Let's also get the path we need.
                IniFile file = new IniFile();
                file.Load(Path.Combine(ActiveCategoryPath, "category.ini"));

                string imageName = file.Sections["CategoryInfo"].Keys["Logo"].Value;

                string imageFileName = Path.Combine(ActiveCategoryPath, $"{imageName}.img.xen");

                nxImg.CompileImage(imageFileName);
            }

            // 3rd task: Mass rename category checksums to the new one if the
            // category checksum changed.
            string newChecksum = NewChecksum.Text;

            if (newChecksum != OldCategoryChecksum) {
                // So... We did change it. Lovely...
                // This is going to require careful iteration, so let's do a similar thing to the
                // ReadAttachedSongs() method in the main manager code.

                // Well, before we start getting ahead of ourselves, let's alter
                // the checksum in the original category.ini file.
                IniFile originalCatINI = new IniFile();
                originalCatINI.Load(iniPath);

                originalCatINI.Sections["CategoryInfo"].Keys["Checksum"].Value = newChecksum;
                originalCatINI.Save(iniPath);

                // - - - - - - - - - - - - - - - - - - - - - - -

                // OK, so the category checksum has been changed in the original mod file,
                // so now, let's begin mass renaming checksums.
                // First off, we're going to change directories into the MODS folder.
                var owd = Directory.GetCurrentDirectory();
                ModHandler.UseUpdaterINIDirectory();

                // - - - - - - - - - - - - - - - - - - - - - - -

                // Now, we want ALL INI FILES.
                string[] files = Directory.GetFiles("DATA/MODS", "*.ini", SearchOption.AllDirectories);

                // Now comes the hardest part, fixing the tied songs' category checksums.
                foreach (string file in files) {
                    // There's 2 files we want to change in: song.ini and folder.ini.
                    // The former, we HAVE to be careful with.

                    // All right, so let's open up the INI file we're reading.
                    IniFile iFile = new IniFile();
                    iFile.Load(file);

                    // Now, is this a song.ini file or a folder.ini file?
                    switch (Path.GetFileName(file)) {
                        case "song.ini":
                            // Is this song even tied to a category?
                            // Ideal way to check for it is to see if we have the GameCategory
                            // option in the file.
                            if (iFile.Sections["SongInfo"].Keys.Contains("GameCategory")) {
                                // WE CANNOT CHECK THE CHECKSUM DIRECTLY AGAINST THE NEW ONE,
                                // OTHERWISE A CATASTROPHE WILL ENSUE.
                                // Rather, is this song's category checksum the one we want to change?
                                if (iFile.Sections["SongInfo"].Keys["GameCategory"].Value == OldCategoryChecksum) {
                                    // Yes it is, so let's change it!
                                    iFile.Sections["SongInfo"].Keys["GameCategory"].Value = newChecksum;
                                    iFile.Save(file);
                                }
                            }
                            break;

                        case "folder.ini":
                            // Is this even a validly formatted file?
                            if (iFile.Sections.Contains("SongInfo")) {
                                // Do we have a category assigned in this file?
                                if (iFile.Sections["SongInfo"].Keys.Contains("GameCategory")) {
                                    // We do, now is it the right one?
                                    if (iFile.Sections["SongInfo"].Keys["GameCategory"].Value == OldCategoryChecksum) {
                                        // Yup, so let's change it!
                                        iFile.Sections["SongInfo"].Keys["GameCategory"].Value = newChecksum;
                                        iFile.Save(file);
                                    }
                                }
                            }
                            break;
                    }
                }

                // - - - - - - - - - - - - - - - - - - - - - - -

                Directory.SetCurrentDirectory(owd);
            }

            this.Close();
        }

        /// <summary>
        ///  Writes a PC formatted Neversoft image file.
        /// </summary>
        public void WriteNXImage() {
            // Image dimensions and PNG data.
            ushort imgW = (ushort) LogoImageBox.Width;
            ushort imgH = (ushort) LogoImageBox.Height;

            byte[] pngData = null;

            using (MemoryStream ms = new MemoryStream()) {
                LogoImageBox.Image.Save(ms, ImageFormat.Png);
                pngData = ms.ToArray();
            }

            uint pngDataSize = (uint)pngData.Length;

            // Let's also get the path we need.
            IniFile file = new IniFile();
            file.Load(Path.Combine(ActiveCategoryPath, "category.ini"));

            string imageName = file.Sections["CategoryInfo"].Keys["Logo"].Value;

            string imageFileName = Path.Combine(ActiveCategoryPath, $"{imageName}.img.xen");

            Console.WriteLine($"image file name: {imageFileName}");

            // Now let's make the image file itself!
            using (BinaryWriter writer = new BinaryWriter(new FileStream(imageFileName, FileMode.Create))) {
                byte[] firstConstBytes = new byte[] { 0x0A, 0x28, 0x13, 0x00, 0x00, 0x00, 0x00, 0x00 };
                writer.Write(firstConstBytes);

                WriteU16(writer, imgW);
                WriteU16(writer, imgH);
                WriteU16(writer, 1);
                WriteU16(writer, imgW);
                WriteU16(writer, imgH);
                WriteU16(writer, 1);

                byte[] secondConstBytes = new byte[] { 0x01, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x28 };
                writer.Write(secondConstBytes);

                WriteU32(writer, pngDataSize);

                WriteU32(writer, 0);

                writer.Write(pngData);
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Takes an input piece of data and flips it to big endian.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public dynamic ToBigEndian(dynamic value) {
            var valueReversed = BitConverter.GetBytes(value);
            Array.Reverse(valueReversed);
            return valueReversed;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Write a value to a BinaryWriter instance as an unsigned short (UInt16).
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        public void WriteU16(BinaryWriter writer, UInt16 value) {
            // Flip this to big endian.
            var outValue = BitConverter.ToUInt16(ToBigEndian(value), 0);
            writer.Write(outValue);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Write a value to a BinaryWriter instance as an unsigned integer (UInt32).
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        public void WriteU32(BinaryWriter writer, UInt32 value) {
            // Flip this to big endian.
            var outValue = BitConverter.ToUInt32(ToBigEndian(value), 0);
            writer.Write(outValue);
        }
    }
}
