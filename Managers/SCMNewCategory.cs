// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       S O N G       A N D       C A T E G O R Y       M A N A G E R
//          N E W       C A T E G O R Y       M O D
//
//    The Mod Manager's song and song category mod manager's dialog for making
//    new category mods.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;
using WTDE_Launcher_V3.IO;

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTDE_Launcher_V3.Managers {
    /// <summary>
    ///  The Mod Manager's song and song category mod manager's dialog for making
    ///  new category mods.
    /// </summary>
    public partial class SCMNewCategory : Form {
        public SCMNewCategory() {
            InitializeComponent();

            NewCategoryPath.Text = $"{V3LauncherCore.GetUpdaterINIDirectory()}/DATA/MODS";
            ImagePathLabel.Text = "";
        }

        private void SelectPathButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Path.Combine(V3LauncherCore.GetUpdaterINIDirectory(), "DATA/MODS");
            fbd.ShowDialog();

            if (fbd.SelectedPath != "") {
                NewCategoryPath.Text = fbd.SelectedPath;
            }
        }

        private void SelectImageButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image File for Category";
            ofd.Filter = "Image Files|*.png;*.jpg;*.jpeg";

            ofd.ShowDialog();

            // Update the image and resize it to 256 X 256.
            if (ofd.FileName != "") {
                Bitmap image = new Bitmap(ofd.FileName);
                Bitmap resizedImage = new Bitmap(image, 256, 256);
                ImagePreviewBox.Image = resizedImage;

                ImagePathLabel.Text = ofd.FileName;
            }
        }

        private void MakeNewCategory_Click(object sender, EventArgs e) {
            // SANITY CHECKS!
            if (NewCategoryPath.Text == "" || NewChecksum.Text == "" || NewName.Text == "" || ImagePathLabel.Text == "") {
                MessageBox.Show("You have missing data fields! Make sure you populate everything in red.", "Missing Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3 tasks: Make a new folder, make a category.ini file,
            // and create an NX image file.
            
            // First up: Make a new folder and make sure it exists.
            if (!Directory.Exists(NewCategoryPath.Text)) {
                Directory.CreateDirectory(NewCategoryPath.Text);
            }

            var owd = Directory.GetCurrentDirectory();

            // Now let's go into this folder.
            Directory.SetCurrentDirectory(NewCategoryPath.Text);

            // Next up: Let's make a category.ini file.
            string authorName = (XMLFunctions.AspyrGetString("Username", "") != "") ? XMLFunctions.AspyrGetString("Username") : "WTDE Launcher V3";
            string categoryINIContent = "[ModInfo]\n" +
                                       $"Name={NewName.Text}\n" +
                                       $"Author={authorName}\n" +
                                       $"Description={NewName.Text} category\n" +
                                        "Version=1.0\n\n" +
                                        "[CategoryInfo]\n" +
                                       $"Name={NewName.Text}\n" +
                                       $"Checksum={NewChecksum.Text}\n" +
                                       $"Logo={Path.GetFileNameWithoutExtension(ImagePathLabel.Text)}";

            using (StreamWriter sw = new StreamWriter("category.ini")) {
                sw.Write(categoryINIContent);
            }

            // Final task: Write an NX image.
            WriteNXImage();

            // - - - - - - - - - - - - - - - - - - - - - - -

            // Back to the original directory, and close the dialog box.
            Directory.SetCurrentDirectory(owd);
            this.Close();
        }

        /// <summary>
        ///  Writes a PC formatted Neversoft image file.
        /// </summary>
        public void WriteNXImage() {
            // Image dimensions and PNG data.
            ushort imgW = (ushort) ImagePreviewBox.Width;
            ushort imgH = (ushort) ImagePreviewBox.Height;

            byte[] pngData = null;

            using (MemoryStream ms = new MemoryStream()) { 
                ImagePreviewBox.Image.Save(ms, ImageFormat.Png);
                pngData = ms.ToArray();
            }

            uint pngDataSize = (uint) pngData.Length;

            // Let's also get the path we need.
            string imageFileName = $"{Path.GetFileNameWithoutExtension(ImagePathLabel.Text)}.img.xen";

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

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
