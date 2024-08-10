// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       N E V E R S O F T       I M A G E
//
//    Class for creating and writing Neversoft image files.
// ----------------------------------------------------------------------------
// V3 launcher imports.
using WTDE_Launcher_V3.Core;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pfim;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using MadMilkman.Ini;

namespace WTDE_Launcher_V3.NX {
    /// <summary>
    ///  Class for creating and writing Neversoft image files.
    /// </summary>
    public class NXImage {
        /// <summary>
        ///  Construct a new Neversoft image file from a given file path.
        /// </summary>
        /// <param name="imagePath">
        ///  
        /// </param>
        public NXImage(string imagePath) {
            string ext = Path.GetExtension(imagePath);
            if (ext == ".xen") {
                this.Image = ConstructImageFromFile(imagePath);
            } else {
                Image newImg = new Bitmap(imagePath);
                this.Image = newImg;
            }
        }

        /// <summary>
        ///  Construct a new Neversoft image file from a given Image.
        /// </summary>
        /// <param name="image"></param>
        public NXImage(Image image) {
            this.Image = image;
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  The bitmap image itself.
        /// </summary>
        public Image Image { get; set; }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Internal function meant to decompile a Neversoft image.
        /// </summary>
        /// <param name="path">
        ///  The path to the *.img.xen file.
        /// </param>
        /// <returns>
        ///  A bitmap image from the *.img.xen file.
        /// </returns>
        private static Image ConstructImageFromFile(string imageDir) {
            // Interpret the image file into something we can export and make usable.
            // Credit: Wesley / donnaken15
            V3LauncherCore.AddDebugEntry("Decompiling image...", "NXImage");

            // Read all of the file's bytes.
            byte[] img = File.ReadAllBytes(imageDir);

            // Is this even an image file?
            if ((img[0] != 0x0A || img[1] != 0x28 || img[2] != 0x13 || img[3] != 0x00) &&
                (img[0] != 0x0A || img[1] != 0x28 || img[2] != 0x11 || img[3] != 0x00)) {
                V3LauncherCore.AddDebugEntry("Invalid Neversoft image", "NXImage");
                throw new Exception("Invalid Neversoft image file was provided.");
            }

            // A bunch of complicated stuff... Wes didn't document this.
            // But whatever, let's just roll with it.
            // Dody seems to tell me this is endian swapping, which makes sense.
            uint off = BitConverter.ToUInt32(img, 0x1C);
            uint len = BitConverter.ToUInt32(img, 0x20);
            if (BitConverter.IsLittleEndian) {
                V3LauncherCore.AddDebugEntry("Is little endian, swapping stuff", "NXImage");
                off = ESwap(off);
                len = ESwap(len);
            }

            byte[] outData = new byte[len];
            Array.Copy(img, off, outData, 0, len);

            // Assuming DDS texture by default?
            string ext = ".dds";
            byte[] magic = new byte[4];

            Array.Copy(outData, magic, 4);

            // Let's figure out what type of image this is.
            V3LauncherCore.AddDebugEntry("Reading image format", "NXImage");
            byte[][] magics = new byte[4][] {
                // DDS
                new byte[4] { 0x44, 0x44, 0x53, 0x20 },
                // PNG
                new byte[4] { 0x89, 0x50, 0x4E, 0x47 },
                // JPG
                new byte[4] { 0xFF, 0xD8, 0xFF, 0xE1 },
                // BMP
                new byte[4] { 0x42, 0x4D, 0x36, 0x16 },
            };
            string[] exts = { ".dds", ".png", ".jpg", ".bmp" };
            for (var i = 0; i < magics.Length; i++) {
                if (magic[0] == magics[i][0] && magic[1] == magics[i][1] && magic[2] == magics[i][2]) {
                    ext = exts[i];
                    V3LauncherCore.AddDebugEntry($"image format is type {ext}", "NXImage");
                    break;
                }
            }

            V3LauncherCore.AddDebugEntry($"Image data length: {outData.Length}", "NXImage");

            // Image has been decompiled, let's go!
            Image extractedImage;
            using (var ms = new MemoryStream(outData)) {
                // PNG, JPG, or BMP image? Turn it into an image from the
                // memory stream, and we're good to go!
                if (ext == ".png" || ext == ".jpg" || ext == ".bmp") {
                    extractedImage = Image.FromStream(ms);

                // This is a DDS image, oh boy
                // This requires a bit of work to convert it to a supported bitmap format.
                // Using Pfim, we'll take it from DDS and convert it to PNG.
                } else {
                    using (IImage image = Pfimage.FromStream(ms)) {
                        PixelFormat format;

                        // Go from Pfim image format to GDI+.
                        switch (image.Format) {
                            case Pfim.ImageFormat.Rgba32:
                                format = PixelFormat.Format32bppArgb;
                                break;

                            default:
                                throw new NotImplementedException();
                                break;
                        }

                        // This is specifically for DDS images.
                        var handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                        var data = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);

                        // Now turn this new data into something we can display!
                        extractedImage = new Bitmap(image.Width, image.Height, image.Stride, format, data);

                        handle.Free();
                    }
                }
            }

            V3LauncherCore.AddDebugEntry("Image decompiled!", "NXImage");

            return extractedImage;
        }

        /// <summary>
        ///  Does some magic to convert a UInt32 to big endian... I think.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static uint ESwap(uint value) {
            return ((value & 0xFF) << 24) |
                   ((value & 0xFF00) << 8) |
                   ((value & 0xFF0000) >> 8) |
                   ((value & 0xFF000000) >> 24);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Writes a PC formatted Neversoft image file to the disk.
        /// </summary>
        private void WriteNXImage(string outDir) {
            // Image dimensions and PNG data.
            ushort imgW = (ushort) this.Image.Width;
            ushort imgH = (ushort) this.Image.Height;

            byte[] pngData = null;

            using (MemoryStream ms = new MemoryStream()) {
                this.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                pngData = ms.ToArray();
            }

            uint pngDataSize = (uint) pngData.Length;

            // Now let's make the image file itself!
            using (BinaryWriter writer = new BinaryWriter(new FileStream(outDir, FileMode.Create))) {
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
        private static dynamic ToBigEndian(dynamic value) {
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
        private static void WriteU16(BinaryWriter writer, UInt16 value) {
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
        private static void WriteU32(BinaryWriter writer, UInt32 value) {
            // Flip this to big endian.
            var outValue = BitConverter.ToUInt32(ToBigEndian(value), 0);
            writer.Write(outValue);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Extract a Neversoft image file into a Bitmap!
        /// </summary>
        /// <param name="path">
        ///  The file path to extract from.
        /// </param>
        /// <returns>
        ///  The image bitmap from the compiled Neversoft image.
        /// </returns>
        public static Image ExtractImage(string path) {
            return ConstructImageFromFile(path);
        }

        // - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Compile the current image of this object into a PC formatted Neversoft image.
        /// </summary>
        /// <param name="path">
        ///  File path to write the image to.
        /// </param>
        public void CompileImage(string path) {
            WriteNXImage(path);
        }
    }
}
