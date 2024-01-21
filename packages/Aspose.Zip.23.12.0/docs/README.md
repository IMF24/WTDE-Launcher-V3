# Archive Processing .NET API

[![banner](https://raw.githubusercontent.com/Aspose/aspose.github.io/master/img/banners/aspose_zip-for-net-banner.png)](https://releases.aspose.com/zip/net/)

[Product Page](https://products.aspose.com/zip/) | [Docs](https://docs.aspose.com/zip/) | [API Reference](https://apireference.aspose.com/zip) | [Examples](https://github.com/aspose-zip/Aspose.ZIP-for-.NET) | [Blog](https://blog.aspose.com/category/zip/) | [Search](https://search.aspose.com/) | [Free Support](https://forum.aspose.com/c/zip) | [Temporary License](https://purchase.aspose.com/temporary-license)

[Aspose.ZIP for .NET](https://products.aspose.com/zip/net/) is a class library that can be used by .NET developers for a variety of archive-processing tasks. It supports ZIP, GZIP, BZIP2, TAR, CPIO, LZIP, 7Z, LZMA, XZ and Z formats. It allows you to encrypt and decrypt files, create self-extracting archives and extract RAR, CAB, WIM formats as well. The API is easy to use, robust and written in managed code entirely to be used in .NET applications.

Aspose.ZIP for .NET is implemented using managed C# and can be used with any .NET language: C#, VB.NET, F#. It can be integrated with any kind of application, from ASP.NET web applications to forms applications within any OS: Windows/Linux/MacOS.


## Functionality

- Compress files and folders to standard ZIP format using standard or enhanced Deflate, Bzip2, LZMA, XZ or PPMd compression algorithm.
- Decompress files and folders
- Detect archive format basing on its content
- [Password protect](https://docs.aspose.com/zip/net/password-protecting-archives/) ZIP archives with AES or ZipCrypto
- Apply different protection scheme to each file in an archive
- Append files to zipped archive
- [Use parallelism](https://dev.to/panchenkodmaspose/zip-files-in-c-using-aspose-zip-parallel-compression-31e) to achieve efficient ZIP, Lzip, Xz and Bzip2 compression
- Pack files and folders to tar or cpio archive and compress it with gzip or bzip2
- Compose self-extracted and [multi-volume](https://docs.aspose.com/zip/net/multi-volume-archives/) archives
- Compose and extract lzip, z and xz archives
- Compose 7z archives with LZMA, LZMA2, PPMd or Bzip2 compression and optional encryption
- Extract simple 7z archives with LZMA, LZMA2, PPMd, BZip2 and Store compression and without encryption
- Extract RAR4 and RAR5 archives, with and without encryption.

To become familiar with the most popular Aspose.ZIP functionality, please have a look at our [free online applications](https://products.aspose.app/zip/family).

## Supported Formats
**Typical for Windows:** ZIP, RAR, 7Z, CAB, WIM

**Typical for Unix/Linux:** TAR, CPIO, SHAR; GZ, BZ2, LZ, XZ, LZMA, XAR, Z

[Full list](https://docs.aspose.com/zip/net/supported-file-formats/)

## Getting Started

So, you probably want to jump up and start coding your archive manipulatio on C#, F# or Visual Basic right away? Let us show you how to do it in a few easy steps.

Run ```Install-Package Aspose.Zip``` from the Package Manager Console in Visual Studio to fetch the NuGet package.
If you want to upgrade to the latest package version, please run ```Update-Package Aspose.Zip```.

You can run the following code snippets in C# to see how our library works. Also feel free to check out the [GitHub Repository](https://github.com/aspose-zip/Aspose.ZIP-for-.NET) for other common use cases.

### Create ZIP archive from a file
The usage of Aspose.ZIP is simple for common scenarios.
```C#
using (var archive = new Archive()) // Instantiate an archive
{
   archive.CreateEntry("first_entry.dat", "data.bin"); // Add an entry from file
   archive.Save("archive.zip"); // Save composed archive to file
}
```

### Extract RAR to a folder
```C#
using (var archive = new RarArchive("archive.rar")))
{
    archive.ExtractToDirectory("extracted");
}
```
### Create 7z archive with LZMA compression and AES Encryption
```C#
// Instantiate an archive, providing compression and encryption settings
using (var archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMACompressionSettings(), new SevenZipAESEncryptionSettings("p@s$"))))
{
   archive.CreateEntry("first_entry.dat", "data.bin");
   archive.Save("archive.7z");
}
```